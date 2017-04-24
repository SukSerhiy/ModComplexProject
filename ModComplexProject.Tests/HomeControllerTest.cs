using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModComplexProject.Controllers;
using WorkWithDb;
using System.Collections.Generic;

namespace ModComplexProject.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        // Arrange
        HomeController controller = new HomeController();

        [TestMethod]
        public void headersNotNull()
        {
            Select s = new Select("Sprav_acva");
            IEnumerable<string> headers = s.getHeaders();
            IEnumerable<IEnumerable<string>> data = s.getData();

            Assert.IsNotNull(headers);
        }
    }
}
