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
    public class ContactInfoController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            var values = context.ContactsInfos.ToList();
            return View(values);
        }

        public ActionResult DeleteContactInfo(int id)
        {
            var value = context.ContactsInfos.Find(id);
            if (value != null)
            {
                context.ContactsInfos.Remove(value);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddContactInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContactInfo(ContactInfo contactInfo)
        {
            context.ContactsInfos.Add(contactInfo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContactInfo(int id)
        {
            var value = context.ContactsInfos.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContactInfo(ContactInfo contactInfo)
        {
            var value = context.ContactsInfos.Find(contactInfo.ContactInfoId);
            if (value != null)
            {
                value.Address = contactInfo.Address;
                value.Email = contactInfo.Email;
                value.PhoneNumber = contactInfo.PhoneNumber;
                value.MapUrl = contactInfo.MapUrl;
                value.OpenHours = contactInfo.OpenHours;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}