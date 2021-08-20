using MediatR;

namespace Application.Notifications
{
    public class LogNotification : INotification
    {
        public string Message { get; init; }

        public LogNotification(string message)
        {
            Message = message;
        }
    }
}