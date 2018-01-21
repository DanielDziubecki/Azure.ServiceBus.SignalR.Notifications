using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;

namespace Azure.ServiceBus.Publisher
{
    class Program
    {
        private static TopicClient client;

        public Program()
        {
            var conString = Environment.GetEnvironmentVariable("azure_con_string");
            client =TopicClient.CreateFromConnectionString(conString, "signalrtest");
        }
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var program = new Program();
            while (true)
            {
                var message = Console.ReadLine();

                await SendMessagesAsync(new Message(Guid.NewGuid(), message));
                Console.WriteLine("Successfully published.");

                var exit = Console.ReadKey();
                if (exit.Key == ConsoleKey.Escape)
                    break;
            }

            await client.CloseAsync();
        }

        static async Task SendMessagesAsync(IMessage message)
        {
            try
            {
                var brokeredMessage = new BrokeredMessage(JsonConvert.SerializeObject(message)) { ContentType = "application/json" }; ;
                Console.WriteLine($"Sending message: {brokeredMessage}");
                await client.SendAsync(brokeredMessage);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }
    }
}
