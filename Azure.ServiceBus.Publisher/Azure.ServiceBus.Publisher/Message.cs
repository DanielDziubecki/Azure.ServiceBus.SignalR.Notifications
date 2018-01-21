using System;

namespace Azure.ServiceBus.Publisher
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