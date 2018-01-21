using System;

namespace Azure.ServiceBus.Publisher
{
    public interface IMessage
    {
        Guid Id { get; set; }
        string Body { get; set; }
    }
}
