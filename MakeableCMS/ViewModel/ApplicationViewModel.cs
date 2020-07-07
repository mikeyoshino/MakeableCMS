using MakeableCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace MakeableCMS.ViewModel
{
    public class ApplicationViewModel
    {
        public Application Application { get; set; }
        public IEnumerable<Area> Areas { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public Article Article { get; set; }
        public IEnumerable<AppOs> AppOses { get; set; }
    }
}