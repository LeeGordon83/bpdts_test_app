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

        public APIService()
        {

        }
        public async Task<List<User>> GetUserData(string parameter)
        {
            string configBase = ConfigurationManager.AppSettings["APILocation"];
            List<User> userList = new List<User>();
            
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(string.Format("{0}/{1}", configBase, parameter)))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        userList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("bpdts API unavailable: {0}", ex);
            }

            return userList;

        }
    }
}