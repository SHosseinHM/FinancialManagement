using Application.Dto.Auth;
using Application.Services.Interfaces.AccountService;
using Infrastructure.Entities;
using MediatR;

namespace Application.Mediator.Services.AccountService
{
    public class AccountService
    {
        #region Models
        /// <summary>
        /// Phone Number Exist
        /// if Exist Return true
        /// </summary>
        public class PhoneNumberExist : IRequest<bool>
        {
            public string PhoneNumber { get; set; }
        }
        /// <summary>
        /// bind to CreateUser Service
        /// if Created, return True
        /// </summary>
        public class CreateUser : IRequest<bool>
        {
            public UserRegisterDto userRegisterDto { get; set; }
        }
        /// <summary>
        /// Check PhoneNumber and Password 
        /// if Matched , return Just Username and PhoneNumber in User object
        /// </summary>
        public class UserCanLogin : IRequest<User>
        {
            public UserLoginDto userLoginDto { get; set; }
        }

        #endregion
        public class HandlePhoneNumberExist : IRequestHandler<PhoneNumberExist, bool>
        {
            private readonly IAccountService _accountService;

            public HandlePhoneNumberExist(IAccountService accountService)
            {
                _accountService = accountService;
            }

            public async Task<bool> Handle(PhoneNumberExist request, CancellationToken cancellationToken)
            {
                return await _accountService.PhoneNumberExist(request.PhoneNumber);
            }
        }

        public class HandleCreateUser : IRequestHandler<CreateUser, bool>
        {
            private readonly IAccountService _accountService;

            public HandleCreateUser(IAccountService accountService)
            {
                _accountService = accountService;
            }

            public async Task<bool> Handle(CreateUser request, CancellationToken cancellationToken)
            {
                return await _accountService.CreateUser(request.userRegisterDto);
            }
        }

        public class HandleUserCanLogin : IRequestHandler<UserCanLogin, User>
        {
            private readonly IAccountService _accountService;

            public HandleUserCanLogin(IAccountService accountService)
            {
                _accountService = accountService;
            }

            public async Task<User> Handle(UserCanLogin request, CancellationToken cancellationToken)
            {
                return await _accountService.UserCanLogin(request.userLoginDto);
            }
        }
    }
}