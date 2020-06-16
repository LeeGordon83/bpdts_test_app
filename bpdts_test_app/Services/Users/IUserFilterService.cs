using bpdts_test_app.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bpdts_test_app.Services.Users
{
    public interface IUserFilterService
    {
        List<User> FilterUsers(string city, int? distance);

        List<User> GetCityUsers(string city);

        List<User> GetAllUsers();

        List<User> FindUserByDistance(List<User> allUsers, int? distance);

    }
}