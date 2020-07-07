using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System;

namespace MakeableCMS.Models
{
    public class Category
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Function Icon")]
        public string ImagePath { get; set; }

        [Required]
        [Display(Name = "Function Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }


        
        public Area Area { get; set; }

        [Display(Name = "Area Name")]
        public int AreaId { get; set; }

        public ICollection<Application> Applications { get; set; }

    }
}