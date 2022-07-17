using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Gifts.Models;
using Gifts.Repository;
using System.Collections.Generic;

namespace Gifts.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        public ActionResult Index()
        {
            ItemsRepo ItemsRepo=new ItemsRepo();
            var Items=ItemsRepo.GetLists();
            return View(Items);
        }

        // GET: Items/Details/5
        public ActionResult Details(int id)
        {
            var Items = new ItemsRepo().GetLists();
            ItemInventoryModel Item = null;
            foreach(var item in Items)
            {
                if (item.Id == id)
                {
                    Item = item;
                    break;
                }
            }
            
            return View(Item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            CategoryRepo categoryRepo = new CategoryRepo();
            var categories=categoryRepo.GetLists();
            ViewData["Categories"]=categories;
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(ItemInventoryModel Item,HttpPostedFileBase Item_Pic)
        {
            try
            {
                if (Item_Pic != null)
                {
                    string Pic = Path.GetFileName(Item_Pic.FileName);
                    string Extension=Path.GetExtension(Pic).ToLower();
                    if (Extension.Equals(".jpg") || Extension.Equals(".jpeg") || Extension.Equals(".png"))
                    {
                        string PicName = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss")+ "-" + Pic;
                        string Pic_Path = Path.Combine(Server.MapPath("../../ItemPictures/"),PicName);
                        Item_Pic.SaveAs(Pic_Path);
                        Item.Image_Path = PicName;
                        ItemsRepo itemsRepo = new ItemsRepo();
                        itemsRepo.Add(Item);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Items/Delete/5
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

        public ActionResult MyCart()
        {
            return View();
        }

        public ActionResult CheckOut()
        {
            ViewBag.OutOfStockMessage = "";
            return View();
        }
        [HttpPost]
        public ActionResult CheckOut(List<CartItemModel> CartsArray)
        {
            ItemsRepo ItemsRepo = new ItemsRepo();
            var Items = ItemsRepo.GetLists();

            foreach(var CartItem in CartsArray)
            {
                foreach(var Item in Items)
                {
                    if (CartItem.ItemId == Item.Id && CartItem.ItemQtyOrder > Item.Quantity)
                    {
                        ViewBag.OutOfStockMessage= CartItem.ItemTitle+"Out of Stock";
                        break;
                    }
                }
                break;
            }

            ItemsRepo.CheckOutRepo(CartsArray);

            return View();
        }
    }
}
