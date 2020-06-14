using bpdts_test_app.Extensions;
using bpdts_test_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bpdts_test_app.Services.Utilities
{
    public class DistanceCalculationService : IDistanceCalculationService
    {

        public double DistanceCalculator(LatLng pos1, LatLng pos2)
        {

            var lat = (pos2.Latitude - pos1.Latitude).ToRadians();
            var lng = (pos2.Longitude - pos1.Longitude).ToRadians();
            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                          Math.Cos(pos1.Latitude.ToRadians()) * Math.Cos(pos2.Latitude.ToRadians()) *
                          Math.Sin(lng / 2) * Math.Sin(lng / 2);
            var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));
            return 3960 * h2;
        }

    }

}