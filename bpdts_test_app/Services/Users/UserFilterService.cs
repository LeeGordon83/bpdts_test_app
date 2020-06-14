using bpdts_test_app.Models;
using bpdts_test_app.Services.Utilities;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace bpdts_test_app.Services.Users
{
    public class UserFilterService : IUserFilterService
    {
        IAPIService apiService;
        IDistanceCalculationService distanceCalculationService;

        public UserFilterService(IAPIService apiService, IDistanceCalculationService distanceCalculationService)
        {
            this.apiService = apiService;
            this.distanceCalculationService = distanceCalculationService;

        }

        public List<User> FilterUsers(string city, int? distance)
        {
            List<User> combinedList = new List<User>();

            string londonLat = ConfigurationManager.AppSettings["LondonLat"];
            string londonLng = ConfigurationManager.AppSettings["LondonLng"];

            //Get specified city based users
            List<User> userListCity = Task.Run(() => apiService.GetUserData("/city/London/users")).Result;

            //Get Users within specified miles
            List<User> allUsers = Task.Run(() => apiService.GetUserData("users")).Result;

            LatLng londonLatLng = new LatLng
            {
                Latitude = double.Parse(londonLat),
                Longitude = double.Parse(londonLng)
            };

            foreach (var user in allUsers)
            {
                LatLng userLatLng = new LatLng
                {
                    Latitude = user.latitude,
                    Longitude = user.longitude
                };

                double distanceBetween = distanceCalculationService.DistanceCalculator(londonLatLng, userLatLng);

                if (distanceBetween <= 50)
                {
                    user.distance = distanceBetween;
                    combinedList.Add(user);
                }
            }

            foreach (var user in userListCity)
            {
                combinedList.Add(user);
            }


            return combinedList;
        }
    }
} 