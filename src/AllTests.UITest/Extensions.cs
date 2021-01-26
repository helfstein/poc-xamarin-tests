using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace AllTests.UITest {
    public static class Extensions {

        public static void AsserElementExists(this IApp app, Func<AppQuery, AppQuery> func) {
            var res = app.Query(func);
            Assert.IsTrue(res.Any());            
        }


    }
}
