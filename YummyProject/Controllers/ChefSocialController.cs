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
    public class ChefSocialController : Controller
    {
        YummyContext context = new YummyContext();

        // Belirli bir şefin sosyal medya hesaplarını listele
        public ActionResult Index(int id)
        {
            var values = context.Chefsocials.Where(x => x.Chef.ChefId == id).ToList();
            ViewBag.ChefId = id;
            var chef = context.Chefs.Find(id);
            ViewBag.ChefName = chef.Name;
            return View(values);
        }

        public ActionResult DeleteChefSocial(int id)
        {
            var value = context.Chefsocials.Find(id);
            if (value != null)
            {
                int chefId = value.Chef.ChefId;
                context.Chefsocials.Remove(value);
                context.SaveChanges();
                return RedirectToAction("Index", new { id = chefId });
            }
            return RedirectToAction("Index", "Chef");
        }

        [HttpGet]
        public ActionResult AddChefSocial(int id)
        {
            ViewBag.ChefId = id;
            var chef = context.Chefs.Find(id);
            ViewBag.ChefName = chef.Name;
            return View();
        }

        [HttpPost]
        public ActionResult AddChefSocial(ChefSocial chefSocial)
        {
            context.Chefsocials.Add(chefSocial);
            context.SaveChanges();
            return RedirectToAction("Index", new { id = chefSocial.Chef.ChefId });
        }

        [HttpGet]
        public ActionResult UpdateChefSocial(int id)
        {
            var value = context.Chefsocials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateChefSocial(ChefSocial chefSocial)
        {
            var value = context.Chefsocials.Find(chefSocial.Id);
            if (value != null)
            {
                value.ImageUrl = chefSocial.ImageUrl;
                value.Name = chefSocial.Name;
                value.Description = chefSocial.Description;
                value.Title = chefSocial.Title;
                context.SaveChanges();
                return RedirectToAction("Index", new { id = value.Chef.ChefId });
            }
            return RedirectToAction("Index", "Chef");
        }
    }
}