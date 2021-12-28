using MediatR;
using System.IdentityModel.Tokens.Jwt;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Infrastructure.Vmodels;

namespace Utils.Services.Mediator.Identity
{
    public class LoginUserCommand : IRequest<JwtSecurityToken>
    {
        public LoginModel Model { get; set; }
    }
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, JwtSecurityToken>
    {
        public LoginUserCommandHandler(IuserIdentityService service)
        {
            Service = service;
        }

        public IuserIdentityService Service { get; }
        public async Task<JwtSecurityToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await Service.LoginAsync(request.Model);
        }
    }
}
