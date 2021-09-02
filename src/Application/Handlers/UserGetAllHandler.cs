using Domain.Interfaces.Repository;
using Domain.Models;
using Domain.Models.Commands.Requests;
using Domain.Models.Commands.Responses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class UserGetAllHandler : IRequestHandler<UserGetAllCommand, UserResponse<IEnumerable<User>>>
    {
        private readonly IUserRepository _userRepository;

        public UserGetAllHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse<IEnumerable<User>>> Handle(UserGetAllCommand request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();

            if (users != null && users.Count() > 0)
                return new UserResponse<IEnumerable<User>>(users);
            else
                return new UserResponse<IEnumerable<User>>(false, "Users not found");
        }
    }
}