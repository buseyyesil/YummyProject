using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }

        public ActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            if (value != null)
            {
                context.Products.Remove(value);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;

            var value = context.Products.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            var value = context.Products.Find(product.ProductId);
            if (value != null)
            {
                value.ImageUrl = product.ImageUrl;
                value.ProductName = product.ProductName;
                value.Ingredients = product.Ingredients;
                value.Price = product.Price;
                value.CategoryId = product.CategoryId;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}