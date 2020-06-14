using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bpdts_test_app.Models
{
    public class User
    {
        public int id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }

        public string ip_address { get; set; }

        public double latitude { get; set; }

        public double longitude { get; set; }

        [Display(Name = "Distance")]
        public double distance { get; set; }

        public string Fullname { get { return string.Format("{0} {1}", first_name, last_name); } }
    }
}