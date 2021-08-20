using Flunt.Notifications;
using System.Threading.Tasks;

namespace Domain.Models.Commands.Requests
{
    public abstract class ValidateCommand : Notifiable<Notification>
    {
        public abstract Task Validate();
    }
}