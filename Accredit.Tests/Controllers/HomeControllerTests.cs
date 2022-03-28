using Microsoft.VisualStudio.TestTools.UnitTesting;
using Accredit.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Accredit.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {

        [TestMethod()]
        public void SearchUserTest()
        {
            var controller = new HomeController();
            var result = controller.SearchUser("robconery");
            //Task<ActionResult> result = controller.SearchUser("robconery");


            if (result.GetType() == typeof(ActionResult))
            {
                Assert.IsNotNull(result);
            }

                Assert.AreEqual(typeof(ActionResult), result.GetType());
            //var result = controller.SearchUser("") as ViewResult;
            //Assert.AreEqual("Details", result.);
            //throw new NotImplementedException();
        }
    }
}