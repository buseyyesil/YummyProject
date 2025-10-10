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
    public class PhotoGalleryController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            var values = context.PhotoGalleries.ToList();
            return View(values);
        }

        public ActionResult DeletePhotoGallery(int id)
        {
            var value = context.PhotoGalleries.Find(id);
            if (value != null)
            {
                context.PhotoGalleries.Remove(value);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddPhotoGallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPhotoGallery(PhotoGallery photoGallery)
        {
            context.PhotoGalleries.Add(photoGallery);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdatePhotoGallery(int id)
        {
            var value = context.PhotoGalleries.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdatePhotoGallery(PhotoGallery photoGallery)
        {
            var value = context.PhotoGalleries.Find(photoGallery.PhotoGalleryId);
            if (value != null)
            {
                value.ImageUrl = photoGallery.ImageUrl;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}