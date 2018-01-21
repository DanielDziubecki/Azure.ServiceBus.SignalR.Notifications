using System;
using Azure.ServiceBus.SignalR.Notifications.Hub;
using Azure.ServiceBus.SignalR.Notifications.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;

namespace Azure.ServiceBus.SignalR.Notifications.ServiceBus
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly string conString = Environment.GetEnvironmentVariable("azure_con_string");
        private readonly string subName = "signalrsub";

        public SubscriptionClient Client { get; }

        public SubscriptionService()
        {
            Client = SubscriptionClient.CreateFromConnectionString(conString, "signalrtest", subName);
            Start();
        }

        private void Start()
        {
            try
            {
                var options = new OnMessageOptions
                {
                    AutoComplete = false,
                    AutoRenewTimeout = TimeSpan.FromMinutes(1)
                };
                options.ExceptionReceived += LogErrors;

                Client.OnMessageAsync(async brokerMessage =>
                {
                    try
                    {
                        var body = brokerMessage.GetBody<string>();
                        var obj = JsonConvert.DeserializeObject<Message>(body);
                        var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                        await context.Clients.All.SendMessage(obj.Body);
                        brokerMessage.Complete();
                    }
                    catch (Exception ex)
                    {
                        brokerMessage.Abandon();
                    }
                }, options);
            }
            catch
            {
                Start();
            }
        }

        private void LogErrors(object sender, ExceptionReceivedEventArgs e)
        {
            //logErrors
        }
    }
}