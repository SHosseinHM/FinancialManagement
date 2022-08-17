using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Auth
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Username is Required!"),
        MaxLength(50, ErrorMessage = "UserName is Long")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "PhoneNumber is Required!"),
        MaxLength(12, ErrorMessage = "PhoneNumber is Long")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is Required!"),
        MaxLength(50, ErrorMessage = "Password is Long")]
        public string Password { get; set; }
    }
}