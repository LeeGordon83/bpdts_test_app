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

            //Get specified city based users
            List<User> userListCity = GetCityUsers(city);

            //Get Users within specified miles
            List<User> allUsers = GetAllUsers();

            combinedList.AddRange(FindUserByDistance(allUsers, distance));

            //Add users in specified city to combined list
            combinedList.AddRange(userListCity);

            return combinedList;
        }

        public List<User> GetCityUsers(string city)
        {
            List<User> userListCity = Task.Run(async () => await apiService.GetUserData("/city/" + city + "/users")).Result;

            return userListCity;
        }

        public List<User> GetAllUsers()
        {
            List<User> allUsers = Task.Run(async () => await apiService.GetUserData("users")).Result;

            return allUsers;
        }

        public List<User> FindUserByDistance(List<User> allUsers, int? distance) 
        {
            //Retrieve London LatLng values
            string londonLat = ConfigurationManager.AppSettings["LondonLat"];
            string londonLng = ConfigurationManager.AppSettings["LondonLng"];

            //Parse London Lat/Lng values to doubles and assign to object
            LatLng londonLatLng = new LatLng
            {
                Latitude = double.Parse(londonLat),
                Longitude = double.Parse(londonLng)
            };

            List<User> usersInRange = new List<User>();

            //Check each User to see if withing designated distance
            foreach (var user in allUsers)
            {
                LatLng userLatLng = new LatLng
                {
                    Latitude = user.Latitude,
                    Longitude = user.Longitude
                };

                double distanceBetween = distanceCalculationService.DistanceCalculator(londonLatLng, userLatLng);

                if (distanceBetween <= distance)
                {
                    user.Distance = distanceBetween;
                    usersInRange.Add(user);
                }
            }

            return usersInRange;

        }


    }

    }

 