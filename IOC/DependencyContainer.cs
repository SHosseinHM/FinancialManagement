using Application.Security;
using Application.Services.Interfaces.AccountService;
using Application.Services.Services.AccountService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Repository.Commands;
using Repository.Queries;

namespace IOC
{
    /// <summary>
    /// This class will use in Program.cs file in WebAPI Application as Injected Services
    /// </summary>
    public class DependencyContainer
    {
        public static void Container(IServiceCollection services)
        {
            /// <summary>
            /// Inject Command and Query Repository
            /// </summary>
            services.AddScoped(typeof(ICommandRepository), typeof(CommandRepository));
            services.AddScoped(typeof(IQueryRepository), typeof(QueryRepository));
            /// <summary>
            /// MediatR Service
            /// </summary>
            services.AddMediatR(typeof(Application.Mediator.Services.AccountService.AccountService).Assembly);
            /// <summary>
            /// Services in ApplicationLayer and Inject Them to Controller
            /// </summary>
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<TokenService>();
        }
    }
}