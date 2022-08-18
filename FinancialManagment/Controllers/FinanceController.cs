using System.Security.Claims;
using Application.Dto.Finance;
using Application.Mediator.Services.FinanceService;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManagment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("Diposite")]
        public async Task<ActionResult> AddDiposite(DipositeDto dipositeDto)
        {
            if (ModelState.IsValid)
            {
                var phone = User.FindFirst(ClaimTypes.MobilePhone).Value;
                if (String.IsNullOrEmpty(phone))
                {
                    return BadRequest(new { Title = "Your Identity is Wrong !" });
                }
                var addDiposite = new FinanceService.AddDeposite
                {
                    depositDto = dipositeDto,
                    PhoneNumber = phone
                };
                if (await _mediator.Send(addDiposite))
                {
                    return Ok(new { Title = "Diposite, Added !" });
                }
                return BadRequest(new { Title = "Please fill all Input Correctly !" });
            }
            return BadRequest(new { Title = "Please fill all Input Correctly !" });
        }

        [Authorize]
        [HttpPost("Withdrow")]
        public async Task<ActionResult> AddWithdrow(WithdrowDto withdrowDto)
        {
            if (ModelState.IsValid)
            {
                var phone = User.FindFirst(ClaimTypes.MobilePhone).Value;
                if (String.IsNullOrEmpty(phone))
                {
                    return BadRequest(new { Title = "Your Identity is Wrong !" });
                }
                var addWithdrow = new FinanceService.AddWithdrow
                {
                    withdrowDto = withdrowDto,
                    PhoneNumber = phone
                };
                if (await _mediator.Send(addWithdrow))
                {
                    return Ok(new { Title = "Diposite, Added !" });
                }
                return BadRequest(new { Title = "Please fill all Input Correctly !" });
            }
            return BadRequest(new { Title = "Please fill all Input Correctly !" });
        }
    }
}