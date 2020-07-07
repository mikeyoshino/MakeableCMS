using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakeableCMS.Models
{
    public class AppOs
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}