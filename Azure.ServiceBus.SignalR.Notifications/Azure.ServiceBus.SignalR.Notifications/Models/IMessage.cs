using System;

namespace Azure.ServiceBus.SignalR.Notifications.Models
{
    interface IMessage
    {
        Guid Id { get; set; }
        string Body { get; set; }
    }
}
