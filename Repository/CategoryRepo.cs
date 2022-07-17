using Gifts.Models;
using Gifts.DBHelper;
using Dapper;
using System.Data;
using System;
using System.Collections.Generic;

namespace Gifts.Repository
{
    public class CategoryRepo
    {
        public IEnumerable<CategoryModel> GetLists()
        {
            try
            {
                using (IDbConnection connection = DBManager.DbConnect())
                {
                    var list = connection.Query<CategoryModel>("[ItemsCategory.ListAllCategory]", commandType: CommandType.StoredProcedure);
                    return list;
                }

            }catch (Exception ex)
            {
                return null;
            }
        }
        public int Add(CategoryModel categoryModel)
        {
            try
            {
                using (IDbConnection connection = DBManager.DbConnect())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Title", categoryModel.Title);
                    connection.Execute("[ItemsCategory.AddCategory]", param, commandType: CommandType.StoredProcedure);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public int Update(CategoryModel categoryModel)
        {
            try
            {
                using(IDbConnection connection= DBManager.DbConnect())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id", categoryModel.Cat_Id);
                    param.Add("@title",categoryModel.Title);
                    connection.Execute("[ItemsCategory.UpdateCategory]", param, commandType: CommandType.StoredProcedure);
                    return 1;
                }
            }catch(Exception ex)
            {
                return -1;
            }
        }
        public int Delete(int id)
        {
            try
            {
                using(IDbConnection connection = DBManager.DbConnect())
                {
                    DynamicParameters param=new DynamicParameters();
                    param.Add("@id", id);
                    connection.Execute("[ItemsCategory.DeleteCategory]", param, commandType: CommandType.StoredProcedure);
                    return 1;
                }
            }catch(Exception ex)
            {
                return -1;
            }
        }
    }
}