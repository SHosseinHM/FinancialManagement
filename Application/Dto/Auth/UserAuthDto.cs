/// <summary>
///  Return Whene User Logedin
/// </summary>

namespace Application.Dto.Auth
{
    public class UserAuthDto
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
    }
}
