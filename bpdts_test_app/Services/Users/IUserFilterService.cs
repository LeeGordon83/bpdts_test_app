using bpdts_test_app.Models;
using System.Collections.Generic;

namespace bpdts_test_app.Services.Users
{
    public interface IUserFilterService
    {
        List<User> FilterUsers(string city, int? distance);
    }
}