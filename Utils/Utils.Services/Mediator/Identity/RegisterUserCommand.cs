using MediatR;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Infrastructure.Vmodels;

namespace Utils.Services.Mediator.Identity
{
    public class RegisterUserCommand : IRequest<int>
    {
        public RegisterModel Model { get; set; }
    }
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        public RegisterUserCommandHandler(IuserIdentityService service)
        {
            Service = service;
        }

        public IuserIdentityService Service { get; }
        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await Service.RegisterAsync(request.Model);
        }
    }
}
