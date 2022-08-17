using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dto.Auth
{
    public class UserLoginDto
    {
        [Required , MaxLength(11)]
        public string PhoneNumber { get; set; }

        [Required , MaxLength(30)]
        public string Password { get; set; }

    }
}