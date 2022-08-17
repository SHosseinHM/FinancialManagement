using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dto.Auth
{
    public class UserAuthDto
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
    }
}