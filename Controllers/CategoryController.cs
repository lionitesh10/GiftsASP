using Gifts.Models;
using Gifts.Repository;
using System.Web.Mvc;

namespace Gifts.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CategoryRepo categoryRepo = new CategoryRepo();
            var list=categoryRepo.GetLists();
            return View(list);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryModel categoryModel)
        {
            try
            {
                CategoryRepo categoryRepo = new CategoryRepo(); 
                categoryRepo.Add(categoryModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            CategoryRepo repo=new CategoryRepo();
            CategoryModel category1=new CategoryModel();
            var categories = repo.GetLists();
            foreach(var category in categories)
            {
                if (category.Cat_Id == id)
                {
                    category1 = category;
                    break;
                }
            }
            return View(category1);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,CategoryModel category)
        {
            try
            {
                category.Cat_Id = id;
                CategoryRepo catRepo = new CategoryRepo();
                catRepo.Update(category);
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            CategoryRepo categoryRepo=new CategoryRepo();
            categoryRepo.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
