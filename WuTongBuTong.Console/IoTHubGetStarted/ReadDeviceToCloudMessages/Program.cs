using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using System.Threading;
using System.Diagnostics;

namespace ReadDeviceToCloudMessages
{
    class Program
    {

        static string connectionString = "";
        static string iotHubD2cEndpoint = "messages/events";
        static EventHubClient eventHubClient;
        private static async Task ReceiveMessagesFromDeviceAsync(string partition, CancellationToken ct)
        {
            var eventHubReceiver = eventHubClient.GetDefaultConsumerGroup().CreateReceiver(partition, DateTime.UtcNow);
            while (true)
            {
                if (ct.IsCancellationRequested) break;
                EventData eventData = await eventHubReceiver.ReceiveAsync();
                if (eventData == null) continue;

                string data = Encoding.UTF8.GetString(eventData.GetBytes());
                Console.WriteLine("Message received. Partition: {0} Data: '{1}'", partition, data);
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Receive messages mode. Ctrl-C to exit.\n");
            Console.WriteLine("Paste your ConnectionString here");
            try
            {
                connectionString = Convert.ToString(Console.ReadLine());
                eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, iotHubD2cEndpoint);
                if (eventHubClient != null) Console.WriteLine("Connect Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oooops,something goes wrong.See the EX:\n" + ex.Message);
                Console.WriteLine("\nPress any key to quit");
                Console.ReadKey();
                return;
            }


            var d2cPartitions = eventHubClient.GetRuntimeInformation().PartitionIds;

            CancellationTokenSource cts = new CancellationTokenSource();

            System.Console.CancelKeyPress += (s, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
                Console.WriteLine("Exiting...");
            };

            var tasks = new List<Task>();
            foreach (string partition in d2cPartitions)
            {
                tasks.Add(ReceiveMessagesFromDeviceAsync(partition, cts.Token));
            }
            Task.WaitAll(tasks.ToArray());


        }
    }
}
