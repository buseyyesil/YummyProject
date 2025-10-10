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
    public class BookingController : Controller
    {
        YummyContext context = new YummyContext();

        // Onay Bekleyen Rezervasyonlar
        public ActionResult Index()
        {
            var values = context.Bookings.Where(x => x.IsApproved == false).ToList();
            return View(values);
        }

        // Onaylanmış Rezervasyonlar
        public ActionResult ApprovedBookings()
        {
            var values = context.Bookings.Where(x => x.IsApproved == true).ToList();
            return View(values);
        }

        // Rezervasyon Detayı
        public ActionResult BookingDetails(int id)
        {
            var value = context.Bookings.Find(id);
            return View(value);
        }

        // Rezervasyonu Onayla
        public ActionResult ApproveBooking(int id)
        {
            var value = context.Bookings.Find(id);
            value.IsApproved = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Onaylanmış Rezervasyonu Geri Al
        public ActionResult CancelApproval(int id)
        {
            var value = context.Bookings.Find(id);
            value.IsApproved = false;
            context.SaveChanges();
            return RedirectToAction("ApprovedBookings");
        }

        // Onay Bekleyen Rezervasyonu Sil
        public ActionResult DeleteBooking(int id)
        {
            var value = context.Bookings.Find(id);
            context.Bookings.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Onaylı Rezervasyonu Sil
        public ActionResult DeleteApprovedBooking(int id)
        {
            var value = context.Bookings.Find(id);
            context.Bookings.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ApprovedBookings");
        }
    }
}