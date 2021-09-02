using Domain.Models.Commands.Responses;
using MediatR;
using System.Threading.Tasks;

namespace Domain.Models.Commands.Requests
{
    public class UserGetCommand : ValidateCommand, IRequest<UserResponse<User>>
    {
        public int UserId { get; set; }

        public UserGetCommand(int userId) => UserId = userId;

        public override async Task Validate()
        {
            await Task.Run(() =>
            {
                if (UserId <= 0)
                    AddNotification("UserId", "UserId is required.");
            });
        }
    }
}