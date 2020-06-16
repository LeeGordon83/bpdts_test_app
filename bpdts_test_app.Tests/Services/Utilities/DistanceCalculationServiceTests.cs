using bpdts_test_app.Models;
using bpdts_test_app.Services.Utilities;
using Newtonsoft.Json.Bson;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bpdts_test_app.Tests.Services.Utilities
{
    [TestFixture]
    public class DistanceCalculationServiceTests
    {
        IDistanceCalculationService mockDistanceCalculationService;

        [SetUp]

        public void Setup()
        {
            mockDistanceCalculationService = new DistanceCalculationService();
        }

        [Test]
        //data obtained from Google 
        public void Test_Distance_Between_Newcastle_and_London()
        {
            // Arrange
            LatLng london = new LatLng
            {
                Latitude = 51.613780,
                Longitude = -0.11348
            };
            LatLng newcastle = new LatLng
            {
                Latitude = 54.982656,
                Longitude = -1.618393
            };

            // Act
            var result = mockDistanceCalculationService.DistanceCalculator(london, newcastle);

            // Assert
            Assert.AreEqual(240.98, Math.Round(result, 2));
        }
    }
}
