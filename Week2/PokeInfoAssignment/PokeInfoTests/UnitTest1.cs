using System;
using Xunit;
using PokeInfo;
using PokeInfo.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace PokeInfoTests
{
    public class UnitTest1
    {
        HomeController _hc;

        public UnitTest1()
        {
            _hc = new HomeController();
        }

        [Fact]
        public void IndexReturnsView()
        {
            var result = _hc.Index();
            Assert.IsType<ViewResult>(result);
        }
    }
}
