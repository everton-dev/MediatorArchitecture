using Domain.Models.Commands.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Models.Commands.Requests
{
    public class UserGetAllCommand : ValidateCommand, IRequest<UserResponse<IEnumerable<User>>>
    {
        public UserGetAllCommand() { }

        public override async Task Validate() => await Task.Delay(1);
    }
}