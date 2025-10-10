using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;
using System.Data.Entity;

namespace YummyProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        YummyContext context=new YummyContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultFeature()
        {
            var values=context.Features.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultAbout()
        {
            var values=context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultProduct()
        {
            var values=context.Categories.ToList(); 
            return PartialView(values);
        }
        // Rezervasyon
        [HttpGet]
        public PartialViewResult DefaultBooking()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult DefaultBooking(Booking booking)
        {
            booking.IsApproved = false;
            context.Bookings.Add(booking);
            context.SaveChanges();
            return PartialView();
        }
        public PartialViewResult DefaultContactInfo()
        {
            var values = context.ContactsInfos.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTestimonial()
        {
            var values = context.TestMonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultEvent()
        {
            var values = context.Events.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultChef()
        {
            var values = context.Chefs.Include("ChefSocials").ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultPhotoGallery()
        {
            var values = context.PhotoGalleries.ToList();
            return PartialView(values);
        }
    }
}