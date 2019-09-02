using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts;
using WebApi.Controllers;
using WebApi.Model;
using Xunit;

namespace WebApi.Tests.ShoppingCartControllerTest
{
    public class GetTests
    {
        ShoppingCartController _controller;
        IShoppingCartService _service;

        public GetTests()
        {
            _service = new ShoppingCartServiceFake();
            _controller = new ShoppingCartController(_service);
        }

        [Fact]
        public void WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<ShoppingItem>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
    }
}
