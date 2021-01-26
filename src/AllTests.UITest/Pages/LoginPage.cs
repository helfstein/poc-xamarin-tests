using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest.Queries;

namespace AllTests.UITest.Pages {
    public class LoginPage : BasePage {

        protected override PlatformQuery Trait => new PlatformQuery {
            Android = x => x.Marked("LoginPage"),
            iOS = x => x.Marked("LoginPage")
        };

        public LoginPage ConfirmLogin() {
            app.WaitForElement(x => x.Marked("LoginBtn"));
            app.Tap(x => x.Marked("LoginBtn"));
            return this;
        }

        #region Asserts

        public LoginPage AssertContentShown() {
            app.AsserElementExists(x => x.Marked("LoginBtn"));
            return this;

        }



        #endregion




    }
}
