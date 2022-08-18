using Application.Dto.Finance;
using Application.Services.Interfaces.FinanceService;
using MediatR;

namespace Application.Mediator.Services.FinanceService
{
    public class FinanceService
    {
        public class AddDeposite : IRequest<bool>
        {
            public DipositeDto depositDto { get; set; }
            public string PhoneNumber { get; set; }
        }
        public class AddWithdrow : IRequest<bool>
        {
            public WithdrowDto withdrowDto { get; set; }
            public string PhoneNumber { get; set; }
        }

        public class HandleAddDeposite : IRequestHandler<AddDeposite, bool>
        {
            private readonly IFinanceService _dipositeService;

            public HandleAddDeposite(IFinanceService dipositeService)
            {
                _dipositeService = dipositeService;
            }

            public async Task<bool> Handle(AddDeposite request, CancellationToken cancellationToken)
            {
                return await _dipositeService.AddDeposite(request.depositDto, request.PhoneNumber);
            }
        }

        public class HandleAddWithdrow : IRequestHandler<AddWithdrow, bool>
        {
            private readonly IFinanceService _dipositeService;

            public HandleAddWithdrow(IFinanceService dipositeService)
            {
                _dipositeService = dipositeService;
            }
            public async Task<bool> Handle(AddWithdrow request, CancellationToken cancellationToken)
            {
                return await _dipositeService.AddWithdrow(request.withdrowDto, request.PhoneNumber);
            }
        }
    }
}