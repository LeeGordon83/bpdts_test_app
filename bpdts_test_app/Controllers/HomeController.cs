using bpdts_test_app.Models;
using bpdts_test_app.Services;
using bpdts_test_app.Services.Users;
using bpdts_test_app.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bpdts_test_app.Controllers
{
    public class HomeController : Controller
    {

        IAPIService apiService;
        IUserFilterService userFilterService;
        IDistanceCalculationService distanceCalculationService;

        public HomeController()
        {
            apiService = new APIService();
            distanceCalculationService = new DistanceCalculationService();
            userFilterService = new UserFilterService(apiService, distanceCalculationService);
        }

        public HomeController(IAPIService apiService, IUserFilterService peopleFilterService, IDistanceCalculationService distanceCalculationService)
        {
            this.apiService = apiService;
            this.userFilterService = peopleFilterService;
            this.distanceCalculationService = distanceCalculationService;
        }
        public ActionResult Index(string city, int? distance)
        {


            List<User> userList = userFilterService.FilterUsers(city, distance);

            return View(userList);
        }

    }
}