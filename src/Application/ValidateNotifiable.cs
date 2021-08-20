using Flunt.Notifications;
using System.Threading.Tasks;

namespace Application
{
    public abstract class ValidateNotifiable : Notifiable<Notification>
    {
        public abstract Task Validate();
    }
}