

using Application.Dto.Auth;
using Infrastructure.Entities;

namespace Application.Services.Interfaces.AccountService
{
    public interface IAccountService
    {
        /// <summary>
        /// Phone Number Exist
        /// if Exist Return true
        /// </summary>
        public Task<bool> PhoneNumberExist(string phoneNnumber);
        /// <summary>
        /// bind to CreateUser Service
        /// if Created, return True
        /// </summary>
        public Task<bool> CreateUser(UserRegisterDto userRegisterDto);
        /// <summary>
        /// Check PhoneNumber and Password 
        /// if Matched , return Just Username and PhoneNumber in User object
        /// </summary>
        public Task<User> UserCanLogin(UserLoginDto userLoginDto);
    }
}