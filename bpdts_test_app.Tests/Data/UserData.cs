using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bpdts_test_app.Tests.Data
{
    public class UserData
    {
        public static string UserDataString()
        {
            string UserDataString =

                "[" +
                "{\"id\": 1, \"first_name\": \"Test\", \"last_name\": \"Testman\", \"email\": \"test@thetest.co.uk\", \"ip_address\": \"113.71.242.187\", \"latitude\": -6.5115909, \"longitude\": 105.652983}," +
                "{\"id\": 2, \"first_name\": \"Test\", \"last_name\": \"NearLondon\", \"email\": \"test@thetest2.co.uk\", \"ip_address\": \"113.71.242.188\", \"latitude\": 51.6553959, \"longitude\": 0.0572553}," +
                 "{\"id\": 2, \"first_name\": \"Test\", \"last_name\": \"NotNearLondon\", \"email\": \"test@thetest3.co.uk\", \"ip_address\": \"113.71.242.188\", \"latitude\": 41.1086264, \"longitude\": -7.6901721}" +
                "]";

            return UserDataString;
        }
    }
}
