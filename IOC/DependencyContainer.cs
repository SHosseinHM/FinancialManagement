using Application.Security;
using Application.Services.Interfaces.AccountService;
using Application.Services.Services.AccountService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Repository.Commands;
using Repository.Queries;

namespace IOC
{
    public class DependencyContainer
    {
        public static void Container(IServiceCollection services)
        {
            services.AddScoped(typeof(ICommandRepository), typeof(CommandRepository));
            services.AddScoped(typeof(IQueryRepository), typeof(QueryRepository));
            services.AddMediatR(typeof(Application.Mediator.Services.AccountService.AccountService).Assembly);
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<TokenService>();
        }
    }
}