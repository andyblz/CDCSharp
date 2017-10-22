using System;
using Xunit;
using System.Collections.Generic;
using CallingCardAssignment;
using CallingCardAssignment.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CallingCardTests
{
    public class UnitTest1
    {
        // QUES: Does this even correctly test if Index() is in HomeController()?
        [Fact]
        public void TestHomeController()
        {
            dynamic controller = new HomeController();

            var result = controller.Index();
            
            Assert.NotNull(result);
        }

        // Should test whether given arguments will return correct URL route.
        [Fact]
        public void TestExpectedRouteWithGivenArguments()
        {
            dynamic controller = new HomeController();

            dynamic result = controller.Index("testFirstName", "testLastName") as JsonResult;

            Assert.Equal("{'firstName':'testFirstName', 'lastName':'testLastName'}", result);
        }

        // Check test to see if testing works.
        [Fact]
        public void TestPractice()
        {
            int number = 2;
            int actual = 2;

            Assert.Equal(number, actual);
        }
    }
}
