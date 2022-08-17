

using Application.Dto.Auth;
using Infrastructure.Entities;

namespace Application.Services.Interfaces.AccountService
{
    public interface IAccountService
    {
        public Task<bool> PhoneNumberExist(string phoneNnumber);
        public Task<bool> CreateUser(UserRegisterDto userRegisterDto);
        public Task<User> UserCanLogin(UserLoginDto userLoginDto);
    }
}