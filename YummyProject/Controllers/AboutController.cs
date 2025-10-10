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
    public class AboutController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = context.Abouts.Find(id);
            context.Abouts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            context.Abouts.Add(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.Abouts.Find(about.AboutId);
            value.ImageUrl = about.ImageUrl;
            value.ImageUrl2 = about.ImageUrl2;
            value.Item1 = about.Item1;
            value.Item2 = about.Item2;
            value.Item3 = about.Item3;
            value.Description = about.Description;
            value.VideoUrl = about.VideoUrl;
            value.PhoneNumber = about.PhoneNumber;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}