using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YummyProject.Models
{
    public class ChefSocial
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }    

        public string Description { get; set; } 

        public string Title{ get; set; }

        public virtual Chef Chef { get; set; }

    }
}