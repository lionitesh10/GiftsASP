using Gifts.Models;
using Gifts.DBHelper;
using System.Data;
using System;
using Dapper;
using System.Collections.Generic;

namespace Gifts.Repository
{
    public class ItemsRepo
    {
        public int Add(ItemInventoryModel Item)
        {
            try
            {
                using(IDbConnection connection = DBManager.DbConnect())
                {
                    DynamicParameters param=new DynamicParameters();
                    param.Add("@Title", Item.Title);
                    param.Add("@Description", Item.Description);
                    param.Add("@Buying_rate", Item.Buying_Rate);
                    param.Add("@Selling_rate", Item.Selling_Rate);
                    param.Add("@Quantity",Item.Quantity);
                    param.Add("@Category_id", Item.Category_Id);
                    param.Add("@Image_Path", Item.Image_Path);
                    connection.Execute("[ItemsInventory.AddItem]",param,commandType:CommandType.StoredProcedure);
                }
                return 1;
            }catch(Exception ex)
            {
                return -1;
            }
        }
        public IEnumerable<ItemInventoryModel> GetLists()
        {
            try
            {
                using(IDbConnection connection = DBManager.DbConnect())
                {
                    var list = connection.Query<ItemInventoryModel>("[ItemsInventory.GetLists]",commandType:CommandType.StoredProcedure);
                    return list;
                }
            }catch(Exception ex)
            {
                return null;
            }
        }

        public int CheckOutRepo(List<CartItemModel> CartItems)
        {
            try
            {
                using(IDbConnection connection = DBManager.DbConnect())
                {
                    var OId = connection.Query<int>("[ItemsCheckout.CreateOrder]", commandType: CommandType.StoredProcedure);
                    int OrdId = 0;
                    foreach(int i in OId)
                    {
                        OrdId = i;
                    }

                    //@ItemId int,
                    //@Order_Id int,
                    //@Qty int,
                    //@Rate float
                    foreach(var item in CartItems)
                    {
                        DynamicParameters param = new DynamicParameters();
                        param.Add("@ItemId", item.ItemId);
                        param.Add("@Order_Id", OrdId);
                        param.Add("@Qty", item.ItemQtyOrder);
                        param.Add("@Rate", item.ItemRate);
                        try
                        {
                            var Result = connection.Execute("[ItemsCheckout.CreateItemsOrder]", param, commandType: CommandType.StoredProcedure);
                        }
                        catch (Exception ex)
                        {

                        }    
                    }
                }
            }catch(Exception ex)
            {

            }
            return 1;
        }
    }
}