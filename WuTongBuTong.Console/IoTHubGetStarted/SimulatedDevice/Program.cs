using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;


namespace SimulatedDevice
{
    class Program
    {

        static DeviceClient deviceClient;
        static string iotHubUri = "";
        static string deviceKey = "";
        static string deviceIdd = "";

        private static async void SendDeviceToCloudMessagesAsync()
        {
            double minTemperature = 20;
            double minHumidity = 60;
            Random rand = new Random();

            while (true)
            {
                double currentTemperature = minTemperature + rand.NextDouble() * 15;
                double currentHumidity = minHumidity + rand.NextDouble() * 20;

                var telemetryDataPoint = new
                {
                    deviceId = deviceIdd,
                    temperature = currentTemperature,
                    humidity = currentHumidity
                };
                var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
                var message = new Message(Encoding.UTF8.GetBytes(messageString));
                message.Properties.Add("temperatureAlert", (currentTemperature > 30) ? "true" : "false");

                await deviceClient.SendEventAsync(message);
                Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);

                await Task.Delay(1000);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Simulated device\n");
            Console.WriteLine("\n Step 1.Now paste your device IoTHubUri.\n");
            iotHubUri = Convert.ToString(Console.ReadLine());
            Console.WriteLine("\n Step 2.Paste your Device Key here..\n");
            deviceKey = Convert.ToString(Console.ReadLine());
           
            Console.WriteLine("\n Step 3.Paste your device id here..\n ");
            deviceIdd = Convert.ToString(Console.ReadLine());
            Console.WriteLine("\nOk,wait a second\n");
            deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey("myFirstDevice", deviceKey), TransportType.Mqtt);
            SendDeviceToCloudMessagesAsync();
            Console.ReadKey();

        }
    }
}
