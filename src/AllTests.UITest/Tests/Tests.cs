using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace AllTests.UITest.Tests {
    public class Tests : BaseTestFixture {


        public Tests(Platform platform)
            : base(platform) {
        }

        [Test]
        public void Repl() {
            if (TestEnvironment.IsTestCloud)
                Assert.Ignore("Local only");

            app.Repl();
        }


    }
}
