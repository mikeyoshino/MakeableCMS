using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakeableCMS.Models
{
    public class Area
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Area Icon")]
        public string ImagePath { get; set; }

        [Display(Name = "Area Name")]
        [Required]
        public string AreaName { get; set; }

        public string Description { get; set; }

        public ICollection<Category> Categories { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}