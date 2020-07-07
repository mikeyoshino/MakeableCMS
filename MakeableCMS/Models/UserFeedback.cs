using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeableCMS.Models
{
    public class UserFeedback
    {
        public int Id { get; set; }
        public Application Application { get; set; }
        public int ApplicationId { get; set; }
        public string Comments { get; set; }
        public int UserRating { get; set; }
    }
}