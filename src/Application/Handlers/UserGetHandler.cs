using Domain.Interfaces.Repository;
using Domain.Models;
using Domain.Models.Commands.Requests;
using Domain.Models.Commands.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class UserGetHandler : IRequestHandler<UserGetCommand, UserResponse<User>>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public UserGetHandler(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<UserResponse<User>> Handle(UserGetCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.UserId);

            if (user == null)
                return new UserResponse<User>(false, "User not found");
            else
                return new UserResponse<User>(user);
        }
    }
}