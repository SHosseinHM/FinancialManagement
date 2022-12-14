using Application.Dto.Auth;
using Application.Mediator.Services.AccountService;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManagment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Registration Users and Save Them to DataBase
        /// </summary>
        /// <param name="userRegisterDto"></param>
        /// <returns>Ok result</returns>
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

                return BadRequest(new { Title = "Can't Register Now, Please try later" });
                #endregion
            }
            return BadRequest(new { Title = "Please fill all inputs" });

        }
        /// <summary>
        /// Login Users
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns>an object {Username , PhoneNumber , JWT Token}</returns>
        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _mediator.Send(new AccountService.UserCanLogin { userLoginDto = userLoginDto });
                #region LoginProcess
                if (user != null)
                {
                    var generateToken = new Application.Mediator.Services.AccountService.TokenService.GenerateToken
                    {
                        user = user
                    };
                    var token = await _mediator.Send(generateToken);
                    var auth = new UserAuthDto
                    {
                        PhoneNumber = user.PhoneNumber,
                        Username = user.Username,
                        Token = token
                    };
                    return Ok(auth);
                }
                #endregion
                return BadRequest(new { Title = "PhoneNumber or Password is Incorrect" });
            }
            return BadRequest(new { Title = "Please fill inputs" });
        }

    }
}