using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Mvc;

namespace bpdts_test_app
{
    [ExcludeFromCodeCoverage]
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
