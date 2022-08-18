using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Dto.Auth;
using Application.Mediator.Services.AccountService;
using FinancialManagment.Controllers;
using FluentAssertions;
using Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Tests.FinancialManagment.Controllers
{
    [TestFixture]
    public class AuthControllerTest_Login
    {
        private Mock<IMediator> _mediator;
        private User user;
        private AuthController _controller;
        [SetUp]
        public void Setup()
        {
            _mediator = new Mock<IMediator>();
        }
        [Test]
        public async Task Login_UserIsNull_ReturnsBadRequest()
        {
            user = null;
            _mediator.Setup(p => p.Send(It.IsAny<AccountService.UserCanLogin>(), It.IsAny<CancellationToken>()))
           .ReturnsAsync(user);

            var send = await _mediator.Object.Send(new AccountService.UserCanLogin());

            _controller = new AuthController(_mediator.Object);
            var loginDto = new Mock<UserLoginDto>();
            var result = await _controller.Login(loginDto.Object);

            Assert.NotNull(result);
            send.Should().BeNull();
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public async Task Login_UserIsNotNull_ReturnsOkResult()
        {
            user = new User
            {
                Username = "Username",
                PhoneNumber = "PhoneNumber"
            };
            _mediator.Setup(p => p.Send(It.IsAny<AccountService.UserCanLogin>(), It.IsAny<CancellationToken>()))
           .ReturnsAsync(user);

            var send = await _mediator.Object.Send(new AccountService.UserCanLogin());

            _controller = new AuthController(_mediator.Object);
            var loginDto = new Mock<UserLoginDto>();
            var result = await _controller.Login(loginDto.Object);

            Assert.NotNull(result);
            send.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}