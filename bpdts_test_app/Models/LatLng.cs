using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace bpdts_test_app.Models
{

    [ExcludeFromCodeCoverage]
    public class LatLng
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public LatLng()
        {
        }

        public LatLng(double lat, double lng)
        {
            this.Latitude = lat;
            this.Longitude = lng;
        }
    }
}