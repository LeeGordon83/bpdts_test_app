using bpdts_test_app.Services;
using bpdts_test_app.Services.Users;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using bpdts_test_app.Tests.Data;
using Moq.Protected;
using System.Threading;
using Moq;
using bpdts_test_app.Services.Utilities;
using bpdts_test_app.Models;

namespace bpdts_test_app.Tests.Services.Users
{
    public class UserFilterServiceTests
    {
    
        IAPIService mockAPIService;
        IUserFilterService mockUserFilterService;
        IDistanceCalculationService mockdistanceCalculationService;

        [SetUp]

        public void Setup()
        {
            //Mock HttpMessageHandler of HttpClient

            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(UserData.UserDataString()),
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/"),
            };

            mockAPIService = new APIService(httpClient);

            mockdistanceCalculationService = new DistanceCalculationService();

            mockUserFilterService = new UserFilterService(mockAPIService, mockdistanceCalculationService);

        }

        [Test]

        public void Test_UserFilterService_Returns_Data()
        {
            // Arrange


            // Act
            var result = mockUserFilterService.FilterUsers("London", 50);

            // Assert
            Assert.IsNotNull(result);

        }

        [Test]

        public void Test_GetAllUsers_Gets_All_Users()
        {
            // Arrange


            // Act
            var result = mockUserFilterService.GetAllUsers();

            // Assert
            Assert.AreEqual(3, result.Count);
        }

        [Test]

        public void Test_Altered_Distance_Finds_Correct_Amount_Of_Users()
        {
            // Arrange
            List<User> userList = new List<User>
            {
                new User
                {
                    Id =1,
                    Latitude = 41.1086264,
                    Longitude = -7.6901721
                },
                new User
                {
                    Id =2,
                    Latitude = 51.509865,
                    Longitude = -0.118092
                }
            };

            // Act
            var result = mockUserFilterService.FindUserByDistance(userList, 5);

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]

        public void Test_User_Distance_Populated_On_Return()
        {
            // Arrange
            List<User> userList = new List<User>
            {
                new User
                {
                    Id =1,
                    Latitude = 41.1086264,
                    Longitude = -7.6901721
                },
                new User
                {
                    Id =2,
                    Latitude = 51.509865,
                    Longitude = -0.118092
                }
            };

            // Act
            var result = mockUserFilterService.FindUserByDistance(userList, 1000);

            // Assert
            Assert.IsNotNull(result.Where(x => x.Id == 1).Select(p => p.Distance).FirstOrDefault());
        }

    }
}
