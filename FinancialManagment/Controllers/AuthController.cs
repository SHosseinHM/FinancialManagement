using Application.Dto.Auth;
using Application.Mediator.Services.AccountService;
using Application.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManagment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly TokenService _tokenService;

        public AuthController(IMediator mediator, TokenService tokenService)
        {
            _mediator = mediator;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserRegisterDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                #region GenerateMediatorObjects
                var phoneNumberExist = new AccountService.PhoneNumberExist
                {
                    PhoneNumber = userRegisterDto.PhoneNumber
                };
                var createUser = new AccountService.CreateUser
                {
                    userRegisterDto = userRegisterDto
                };
                #endregion

                #region Problem Occured
                if (await _mediator.Send(phoneNumberExist))
                {
                    return BadRequest(new { Titel = "PhoneNumber Already Exist" });
                }
                #endregion

                #region CreateUser

                if (await _mediator.Send(createUser))
                {
                    return Ok(new { Title = "Completed Successfuly !, Now You Can Login" });
                }

                return BadRequest(new { Titel = "Can't Register Now, Please try later" });
                #endregion
            }
            return BadRequest(new { Titel = "Please fill all inputs" });

        }

        public async Task<ActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _mediator.Send(new AccountService.UserCanLogin { userLoginDto = userLoginDto });
                #region LoginProcess
                if (user != null)
                {
                    var token = _tokenService.GenerateToken(user);
                    var auth = new UserAuthDto
                    {
                        PhoneNumber = user.PhoneNumber,
                        Username = user.Username,
                        Token = token
                    };
                    return Ok(auth);
                }
                #endregion
                return BadRequest(new { Title = "Please fill inputs" });
            }
            return BadRequest(new { Title = "Please fill inputs" });
        }
    }
}