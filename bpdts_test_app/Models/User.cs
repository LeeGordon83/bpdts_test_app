using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace bpdts_test_app.Models
{

    [ExcludeFromCodeCoverage]
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [Display(Name = "Distance in Miles")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double Distance { get; set; }

        [Display(Name = "Full Name")]
        public string Fullname { get { return string.Format("{0} {1}", FirstName, LastName); } }
    }
}