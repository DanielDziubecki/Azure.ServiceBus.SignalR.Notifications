using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;

namespace Azure.ServiceBus.SignalR.Notifications.Hub
{
    [HubName("notificationhub")]
    public class NotificationHub : Microsoft.AspNet.SignalR.Hub
    {

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
    }
}