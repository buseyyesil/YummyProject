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
    public class MessageController : Controller
    {
        YummyContext context = new YummyContext();

        // Okunmamış Mesajlar
        public ActionResult Index()
        {
            var values = context.Messages.Where(x => x.IsRead == false).ToList();
            return View(values);
        }

        // Okunmuş Mesajlar
        public ActionResult ReadMessages()
        {
            var values = context.Messages.Where(x => x.IsRead == true).ToList();
            return View(values);
        }

        // Mesaj Detayı
        public ActionResult MessageDetails(int id)
        {
            var value = context.Messages.Find(id);
            if (value != null)
            {
                value.IsRead = true;
                context.SaveChanges();
            }
            return View(value);
        }

        // Mesajı Sil
        public ActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            if (value != null)
            {
                context.Messages.Remove(value);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Okundu İşaretle
        public ActionResult MarkAsRead(int id)
        {
            var value = context.Messages.Find(id);
            if (value != null)
            {
                value.IsRead = true;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}