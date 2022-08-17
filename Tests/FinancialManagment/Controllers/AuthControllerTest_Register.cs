using System.Threading;
using System.Threading.Tasks;
using Application.Mediator.Services.AccountService;
using FinancialManagment.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using FluentAssertions;
using Application.Dto.Auth;
using Application.Security;

namespace Tests.FinancialManagment.Controllers
{
    [TestFixture]
    public class AuthControllerTest_Register
    {
        private Mock<IMediator> _mediator;
        private AuthController _controller;
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public async Task Register_PhoneNumberAlreadyExist_ReturnsBadRequest()
        {
            _mediator = new Mock<IMediator>();
            var token = new Mock<TokenService>();
            _mediator.Setup(p => p.Send(It.IsAny<AccountService.PhoneNumberExist>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

            var send = await _mediator.Object.Send(new AccountService.PhoneNumberExist());

            _controller = new AuthController(_mediator.Object, token.Object);
            var dto = new Mock<UserRegisterDto>();
            var result = await _controller.Register(dto.Object);

            Assert.NotNull(result);
            Assert.NotNull(send);
            result.Should().BeOfType<BadRequestObjectResult>();

        }



        [Test]
        public async Task Register_CreateingUser_ReturnsOkResult()
        {
            _mediator = new Mock<IMediator>();
            var token = new Mock<TokenService>();
            _mediator.Setup(p => p.Send(It.IsAny<AccountService.CreateUser>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

            var send = await _mediator.Object.Send(new AccountService.CreateUser());

            _controller = new AuthController(_mediator.Object, token.Object);
            var dto = new Mock<UserRegisterDto>();
            var result = await _controller.Register(dto.Object);

            Assert.NotNull(result);
            Assert.NotNull(send);
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}