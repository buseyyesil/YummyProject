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
    public class TestimonialController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            var values = context.TestMonials.ToList();
            return View(values);
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.TestMonials.Find(id);
            if (value != null)
            {
                context.TestMonials.Remove(value);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TestMonial testimonial)
        {
            context.TestMonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.TestMonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TestMonial testimonial)
        {
            var value = context.TestMonials.Find(testimonial.TestMonialId);
            if (value != null)
            {
                value.ImageUrl = testimonial.ImageUrl;
                value.NameSurname = testimonial.NameSurname;
                value.Title = testimonial.Title;
                value.Comment = testimonial.Comment;
                value.Rating = testimonial.Rating;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}