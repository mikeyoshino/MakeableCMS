using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace MakeableCMS.Models
{
    public class Application
    {

        public int Id { get; set; }

        [Display(Name = "App Icon")]
        public string ImagePath { get; set; }


        [Display(Name = "App Name")]
        [Required]
        [MaxLength(120), MinLength(4)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "App Description")]
        public string Description { get; set; }

        [Display(Name = "App Store Rating (Rate from 1 to 5)")]
        [Range(1, 5)]
        public double AppStoreRating { get; set; }

        public AppOs AppOs { get; set; }
        [Required]
        [Display(Name = "Choose Application Operation System")]
        public int AppOsId { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }

        public bool IsLastUpdate { get; set; }

        [Display(Name = "User Rate (Rate from 1 to 5)")]
        [Range(1, 5)]
        public double UserfulRate { get; set; }

        [Display(Name = "App URL link")]
        [Required]
        [MaxLength(200), MinLength(4)]
        public string AppUrl { get; set; }


        public Category Category { get; set; }
        [Display(Name = "Choose Function of application")]
        public int CategoryId { get; set; }

        public ICollection<UserFeedback> UserFeedbacks { get; set; }
    }
}