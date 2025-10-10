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
    public class ChefController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            var values = context.Chefs.ToList();
            return View(values);
        }

        public ActionResult DeleteChef(int id)
        {
            var value = context.Chefs.Find(id);
            if (value != null)
            {
                context.Chefs.Remove(value);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddChef()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddChef(Chef chef)
        {
            context.Chefs.Add(chef);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var value = context.Chefs.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateChef(Chef chef)
        {
            var value = context.Chefs.Find(chef.ChefId);
            if (value != null)
            {
                value.ImageUrl = chef.ImageUrl;
                value.Name = chef.Name;
                value.Title = chef.Title;
                value.Description = chef.Description;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}