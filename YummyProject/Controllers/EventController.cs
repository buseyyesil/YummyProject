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
    public class EventController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            var values = context.Events.ToList();
            return View(values);
        }

        public ActionResult DeleteEvent(int id)
        {
            var value = context.Events.Find(id);
            if (value != null)
            {
                context.Events.Remove(value);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEvent(Event eventItem)
        {
            context.Events.Add(eventItem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEvent(int id)
        {
            var value = context.Events.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateEvent(Event eventItem)
        {
            var value = context.Events.Find(eventItem.EventId);
            if (value != null)
            {
                value.ImageUrl = eventItem.ImageUrl;
                value.Title = eventItem.Title;
                value.Description = eventItem.Description;
                value.Price = eventItem.Price;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}