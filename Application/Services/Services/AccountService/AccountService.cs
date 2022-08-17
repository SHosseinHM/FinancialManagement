using Application.Dto.Auth;
using Application.Security;
using Application.Services.Interfaces.AccountService;
using Infrastructure.Entities;
using Repository.Commands;
using Repository.Queries;

namespace Application.Services.Services.AccountService
{

    public class AccountService : IAccountService
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IQueryRepository _queryRepository;

        public AccountService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        public async Task<bool> CreateUser(UserRegisterDto userRegisterDto)
        {
            var user = new User
            {
                Username = userRegisterDto.UserName,
                PhoneNumber = userRegisterDto.PhoneNumber,
                PasswordHash = userRegisterDto.Password.Hash(),
                CreateDate = DateTime.Now
            };
            var addedUser = await _commandRepository.AddSaveAsync(user);
            if (addedUser != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> PhoneNumberExist(string phoneNnumber)
        {
            var sql = "select PhoneNumber as PhoneNumber from Users where PhoneNumber=@PhoneNumber";
            var value = new
            {
                PhoneNumber = phoneNnumber
            };
            return await _queryRepository.QueryExist<User>(sql, value);
        }

        public async Task<User> UserCanLogin(UserLoginDto userLoginDto)
        {
            var sql = "select PhoneNumber as PhoneNumber " +
                            "Username as Username" +
                            "from Users where PhoneNumber=@PhoneNumber AND PasswordHash=@Password";
            var values = new
            {
                PhoneNumber = userLoginDto.PhoneNumber,
                Password = userLoginDto.Password.Hash()
            };
            var user = await _queryRepository.QuerySingle<User>(sql, values);
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}