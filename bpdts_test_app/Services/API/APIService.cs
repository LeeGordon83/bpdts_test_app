using bpdts_test_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace bpdts_test_app.Services
{
    public class APIService : IAPIService
    {
        private readonly HttpClient httpClient;
        public APIService(HttpClient httpClient)
        {
           this.httpClient = httpClient;

        }


        public async Task<List<User>> GetUserData(string searchstring)
        {
            string configBase = ConfigurationManager.AppSettings["APILocation"];
            List<User> userList = new List<User>();

            try
            {
                    var response = await httpClient.GetAsync(string.Format("{0}/{1}", configBase, searchstring));
                        
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    List<User> usersFound = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                    userList.AddRange(usersFound);
                
            }


            catch (Exception ex)
            {
                Console.WriteLine("bpdts API unavailable: {0}", ex);
            }

            return userList;

        }
    }
}