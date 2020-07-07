using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakeableCMS.Models;

namespace MakeableCMS.ViewModel
{
    public class CategoryViewModel
    {
        public IEnumerable<Area> Areas { get; set; }
        public Category Category { get; set; }
    }
}