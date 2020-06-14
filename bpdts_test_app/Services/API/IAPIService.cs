using bpdts_test_app.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bpdts_test_app.Services
{
    public interface IAPIService
    {
        Task<List<User>> GetUserData(string parameter);
    }
}