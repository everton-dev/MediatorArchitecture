using Domain.Enums;
using Domain.Interfaces.Repository;
using Domain.Models;
using Domain.Models.Commands.Requests;
using Domain.Models.Commands.Responses;
using Domain.Models.ValueObject;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class UserUpdateHandler : IRequestHandler<UserUpdateCommand, UserResponse>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public UserUpdateHandler(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var document = new Document((EnumTypeDocument)request.TypeDocument, request.DocumentNumber);
            var name = new Name(request.InitialName, request.MiddleName, request.LastName);
            var user = new User(request.UserId, document, name, request.DateBirth, request.Email);

            await _userRepository.Update(user, cancellationToken);

            return UserResponse.OK;
        }
    }
}