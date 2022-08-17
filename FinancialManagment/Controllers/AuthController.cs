using Microsoft.AspNetCore.Mvc;

namespace FinancialManagment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        [HttpPost("Register")]
        public ActionResult Register()
        {
            return Ok();
        }

    }
}