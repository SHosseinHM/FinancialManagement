using Application.Dto.Finance;
using Application.Services.Interfaces.FinanceService;
using Infrastructure.Entities;
using Repository.Commands;
using Repository.Queries;

namespace Application.Services.Services.FinanceService
{
    public class FinanceService : IFinanceService
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IQueryRepository _queryRepository;
        public async Task<bool> AddDeposite(DipositeDto dipositeDto, string phoneNumber)
        {
            #region UserExist
            var sql = "select UserId as UserId from Users where PhoneNumber=@PhoneNumber";
            var value = new
            {
                PhoneNumber = phoneNumber
            };
            var user = await _queryRepository.QuerySingle<User>(sql, value);
            #endregion
            #region Add Diposit
            if (user != null)
            {
                var diposite = new Infrastructure.Entities.Diposite
                {
                    Amount = dipositeDto.Amount,
                    CreateDate = DateTime.Now,
                    Description = dipositeDto.Description,
                    UserId = user.UserId
                };
                var success = await _commandRepository.AddSaveAsync(diposite);
                if (success != null)
                {
                    return true;
                }
                return false;
            }
            return false;
            #endregion
        }

        public async Task<bool> AddWithdrow(WithdrowDto withdrowDto, string phoneNumber)
        {
            #region UserExist
            var sql = "select UserId as UserId from Users where PhoneNumber=@PhoneNumber";
            var value = new
            {
                PhoneNumber = phoneNumber
            };
            var user = await _queryRepository.QuerySingle<User>(sql, value);
            #endregion
            #region Add Diposit
            if (user != null)
            {
                var withdrow = new Infrastructure.Entities.Withdrow
                {
                    Amount = withdrowDto.Amount,
                    CreateDate = DateTime.Now,
                    Description = withdrowDto.Description,
                    UserId = user.UserId
                };
                var success = await _commandRepository.AddSaveAsync(withdrow);
                if (success != null)
                {
                    return true;
                }
                return false;
            }
            return false;
            #endregion
        }
    }
}