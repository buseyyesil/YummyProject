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
    public class ServiceController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            var values = context.Services.ToList();
            return View(values);
        }

        public ActionResult DeleteService(int id)
        {
            var value = context.Services.Find(id);
            if (value != null)
            {
                context.Services.Remove(value);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = context.Services.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var value = context.Services.Find(service.ServiceId);
            if (value != null)
            {
                value.Title = service.Title;
                value.Description = service.Description;
                value.Icon = service.Icon;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}