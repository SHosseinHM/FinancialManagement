using Application.Dto.Finance;

namespace Application.Services.Interfaces.FinanceService
{
    public interface IFinanceService
    {
        public Task<bool> AddDeposite(DipositeDto dipositeDto, string phoneNumber);
        
        public Task<bool> AddWithdrow(WithdrowDto withdrowDto, string phoneNumber);
    }
}