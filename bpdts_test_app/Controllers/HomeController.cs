using bpdts_test_app.Models;
using bpdts_test_app.Services;
using bpdts_test_app.Services.Users;
using bpdts_test_app.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace bpdts_test_app.Controllers
{
    public class HomeController : Controller
    {

        IAPIService apiService;
        IUserFilterService userFilterService;
        IDistanceCalculationService distanceCalculationService;
        private static HttpClient Client = new HttpClient();

        public HomeController()
        {
            apiService = new APIService(Client);
            distanceCalculationService = new DistanceCalculationService();
            userFilterService = new UserFilterService(apiService, distanceCalculationService);
        }

        public HomeController(IAPIService apiService, IUserFilterService userFilterService, IDistanceCalculationService distanceCalculationService)
        {
            this.apiService = apiService;
            this.userFilterService = userFilterService;
            this.distanceCalculationService = distanceCalculationService;
        }
        public ActionResult Index(string city = "London", int? distance = 50)
        {

            ViewBag.City = city;
            ViewBag.Distance = distance;

            try
            {

                List<User> userList = userFilterService.FilterUsers(city, distance);

                return View(userList);
            }
            catch (Exception Ex)
            {
                return View("Error");
            }
        }

    }
}