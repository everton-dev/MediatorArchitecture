using Application.Notifications;
using Domain.Enums;
using Domain.Interfaces.Repository;
using Domain.Models;
using Domain.Models.Commands.Requests;
using Domain.Models.Commands.Responses;
using Domain.Models.ValueObject;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class UserCreateHandler : IRequestHandler<UserCreateCommand, UserResponse>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public UserCreateHandler(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var document = new Document((EnumTypeDocument)request.TypeDocument, request.DocumentNumber);
            var name = new Name(request.InitialName, request.MiddleName, request.LastName);
            var user = new User(document, name, request.DateBirth, request.Email);

            user.Register(request.UserEntry, DateTime.Now);

            await _userRepository.Create(user, cancellationToken);

            await _mediator.Publish(new LogNotification($"User was created by user {request.UserEntry}."), cancellationToken);

            return UserResponse.OK;
        }
    }
}