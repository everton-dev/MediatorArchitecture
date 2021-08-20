using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Notifications.Handlers
{
    public class LogNotificationHandler : INotificationHandler<LogNotification>
    {
        public async Task Handle(LogNotification notification, CancellationToken cancellationToken) =>
            await Task.Run(() => System.Diagnostics.Debug.WriteLine($"=>{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} | {notification.Message}"));
    }
}