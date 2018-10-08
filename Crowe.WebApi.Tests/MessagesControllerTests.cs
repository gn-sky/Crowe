using Crowe.Core.Interfaces;
using Crowe.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Net;
using Xunit;

namespace Crowe.WebApi.Tests
{
    public class MessagesControllerTests
    {
        [Fact]
        public void Get_Returns_HelloWorld()
        {
            var expected = "Hello World!";
            var _messageSvc = new Mock<IMessageService>();
            _messageSvc.Setup(svc => svc.GetMessage())
                        .Returns(expected);

            var _sut = new MessagesController(_messageSvc.Object);

            var actual = (ObjectResult)_sut.Get();

            Assert.Equal((int)HttpStatusCode.OK, actual.StatusCode);
            Assert.Equal(expected, actual.Value);
        }

        [Fact]
        public void Get_Exception_Returns_500()
        {
            var expected = "error";
            var _messageSvc = new Mock<IMessageService>();
            _messageSvc.Setup(svc => svc.GetMessage()).Throws(new Exception("Error"));

            var _sut = new MessagesController(_messageSvc.Object);
            var actual = (ObjectResult)_sut.Get();

            Assert.Equal((int)HttpStatusCode.InternalServerError, actual.StatusCode);
            Assert.Contains(expected, actual.Value?.ToString().ToLower());
        }
    }
}
