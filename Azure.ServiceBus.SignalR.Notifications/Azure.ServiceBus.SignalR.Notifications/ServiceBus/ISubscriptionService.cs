using Microsoft.ServiceBus.Messaging;

namespace Azure.ServiceBus.SignalR.Notifications.ServiceBus
{
    public interface ISubscriptionService
    {
        SubscriptionClient Client { get; }
    }
}