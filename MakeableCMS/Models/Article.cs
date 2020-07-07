using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeableCMS.Models
{
    public class Article
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Article Name")]
        [MaxLength(120), MinLength(4)]
        public string Name { get; set; }

        [Display(Name = "Poted on")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateTime { get; set; }

        [AllowHtml]
        public string Description { get; set; }
        public string Url { get; set; }


        public Area Area { get; set; }
        [Display(Name = "Area Name")]
        public int AreaId { get; set; }
    }
}