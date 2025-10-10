using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using YummyProject.Models;

namespace YummyProject.Context
{
    public class YummyContext : DbContext
    {
        // Connection string adını belirtin ve database initializer ekleyin
        public YummyContext() : base("YummyContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<YummyContext>());
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<ChefSocial> Chefsocials { get; set; }
        public DbSet<ContactInfo> ContactsInfos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PhotoGallery> PhotoGalleries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TestMonial> TestMonials { get; set; }
        public DbSet<Admin> Admins{ get; set; }
        public DbSet<SocialMedia> SocialMedias{ get; set; }
    }
}