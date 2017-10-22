using System;
using Xunit;
using Portfolio;
using Portfolio.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void Test()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            // var model = result.Model as AboutViewModel;

            Assert.NotNull(result);
            // Assert.Equal("Hello", model.Title);
        }
    }
}
