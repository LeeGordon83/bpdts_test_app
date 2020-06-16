using bpdts_test_app.Services;
using bpdts_test_app.Tests.Data;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bpdts_test_app.Tests.Services.API
{
    public class APIServiceTests
    {
        IAPIService mockAPIService;

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

        }

        [Test]

        public void Test_API_Returns_Data()
        {

            var result = mockAPIService.GetUserData("Test");

            Assert.IsNotNull(result);
        }

        [Test]

        public void Test_API_Returns_All_Data()
        {

            var result = mockAPIService.GetUserData("Test").Result;

            Assert.AreEqual(3, result.Count);
        }


    }
}
