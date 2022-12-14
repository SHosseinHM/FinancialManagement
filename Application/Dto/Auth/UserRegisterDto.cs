using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dto.Auth
{
    public class UserRegisterDto
    {
        [MaxLength(11) , Required]
        public string PhoneNumber { get; set; }
        [MaxLength(50) , Required]
        public string UserName { get; set; }
        [MaxLength(30) , Required]
        public string Password { get; set; }
    }
}