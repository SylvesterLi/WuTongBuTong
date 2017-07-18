using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;


namespace CreateDeviceIdentity
{
    class Program
    {
        static RegistryManager registryManager;
        static string connectionString = "";
        static string deviceId = "";
        private static async Task AddDeviceAsync()
        {
            
            Device device;
            try
            {
                device = await registryManager.AddDeviceAsync(new Device(deviceId));
                
            }
            catch (DeviceAlreadyExistsException)
            {
                device = await registryManager.GetDeviceAsync(deviceId);
                
            }
            Console.WriteLine("\nGenerated device key: {0}", device.Authentication.SymmetricKey.PrimaryKey);

        }
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Use this Console App and generate your device key!");
            Console.WriteLine("\n Step 1.Paste your ConnectionString here..\n");
            connectionString = Convert.ToString(Console.ReadLine());
            Console.WriteLine("\n Step 2.Now paste your device id.\n");
            deviceId= Convert.ToString(Console.ReadLine());
            Console.WriteLine("\nOk,wait a second\n");
            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
            AddDeviceAsync().Wait();
            Console.ReadKey();
        }
    }
}
