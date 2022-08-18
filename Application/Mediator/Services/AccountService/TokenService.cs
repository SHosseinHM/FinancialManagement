using Infrastructure.Entities;
using MediatR;

namespace Application.Mediator.Services.AccountService
{
    public class TokenService
    {
        /// <summary>
        /// and Handler for Returning Generate Token Service
        /// return an JWT Token
        /// </summary>
        public class GenerateToken : IRequest<string>
        {
            public User user { get; set; }
        }

        public class HandleGenerateToken : IRequestHandler<GenerateToken, string>
        {
            private readonly Security.TokenService _tokenService;
            public HandleGenerateToken(Security.TokenService tokenService)
            {
                _tokenService = tokenService;
            }

            public Task<string> Handle(GenerateToken request, CancellationToken cancellationToken)
            {
                var token = _tokenService.GenerateToken(request.user);
                return Task.FromResult(token);
            }
        }

    }
}