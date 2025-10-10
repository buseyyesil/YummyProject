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
    public class CategoryController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            var values = context.Categories.ToList();
            return View(values);
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);

            if (value == null)
            {
                return RedirectToAction("Index");
            }

            // Kategoriye bağlı ürün var mı kontrol et
            var hasProducts = context.Products.Any(x => x.CategoryId == id);

            if (hasProducts)
            {
                TempData["ErrorMessage"] = "Bu kategoriye bağlı ürünler var. Önce ürünleri silmelisiniz.";
                return RedirectToAction("Index");
            }

            context.Categories.Remove(value);
            context.SaveChanges();
            TempData["SuccessMessage"] = "Kategori başarıyla silindi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.CategoryId);
            if (value != null)
            {
                value.CategoryName = category.CategoryName;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}