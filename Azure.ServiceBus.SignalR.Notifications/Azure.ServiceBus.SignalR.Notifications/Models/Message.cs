using System;

namespace Azure.ServiceBus.SignalR.Notifications.Models
{
    public class Message : IMessage
    {
        public Message(Guid id, string message)
        {
            Id = id;
            Body = message;
        }

        public Guid Id { get; set; }
        public string Body { get; set; }
    }
}