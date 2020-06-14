using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bpdts_test_app.Extensions
{
    public static class NumericExtensions
    {
            public static double ToRadians(this double val)
            {
                return (Math.PI / 180) * val;
            }
        
    }
}