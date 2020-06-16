using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using bpdts_test_app;
using bpdts_test_app.Controllers;
using bpdts_test_app.Services;
using bpdts_test_app.Services.Users;
using bpdts_test_app.Services.Utilities;
using Moq;
using NUnit.Framework;

namespace bpdts_test_app.Tests.Controllers
{

    [TestFixture]
    public class HomeControllerTest
    {
        
        HomeController mockHomeController;
        Mock<IAPIService> mockAPIService;
        Mock<IUserFilterService> mockUserFilterService;
        Mock<IDistanceCalculationService> mockDistanceCalculationService;
        


        [SetUp]
        public void Setup()
        {
            mockAPIService = new Mock<IAPIService>();
            mockUserFilterService = new Mock<IUserFilterService>();
            mockDistanceCalculationService = new Mock<IDistanceCalculationService>();

            mockHomeController = new HomeController(mockAPIService.Object, mockUserFilterService.Object, mockDistanceCalculationService.Object);
        }

        

        [Test]
        public void Test_Index_Returns_Value()
        {
            // Arrange


            // Act
            ViewResult result = mockHomeController.Index("", 50) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
