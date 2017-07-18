using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using System.Diagnostics;

class AzureIoTHub
{


    private static DeviceClient deviceClient;
    //public string deviceID = "";
    //public string iotHubUri = "";
    //public string deviceKey = "";

    public AzureIoTHub()
    {

    }

    /// <summary>
    /// Attempt to connect with a valid connection string
    /// </summary>
    /// <param name="connectionstring"></param>
    /// <returns> true if connection is successful, false otherwise</returns>
    public bool ConnectToReceive(string connectionstring, string deviceId)
    {
        try
        {
            deviceClient = DeviceClient.CreateFromConnectionString(connectionstring, deviceId, TransportType.Mqtt);
            deviceClient.CloseAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
    public bool ConnectToSend(string iotHubUri, string deviceID, string deviceKey)
    {
        try
        {
            deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(deviceID, deviceKey), TransportType.Mqtt);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }


    /// <summary>
    /// send a message to the cloud
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public async Task SendDeviceToCloudMessageAsync(string msg)
    {
        var message = new Message(Encoding.UTF8.GetBytes(msg));
        await deviceClient.SendEventAsync(message);
    }

    /// <summary>
    /// receive messages from the cloud
    /// </summary>
    /// <returns></returns>
    public async Task<string> ReceiveCloudToDeviceMessageAsync(string connectionstring, string deviceId)
    {

        deviceClient = DeviceClient.CreateFromConnectionString(connectionstring,deviceId, TransportType.Mqtt);
        await deviceClient.OpenAsync();
        while (true)
        {
            var receivedMessage = await deviceClient.ReceiveAsync();
            if (receivedMessage != null)
            {
                var messageData = Encoding.UTF8.GetString(receivedMessage.GetBytes());
                await deviceClient.CompleteAsync(receivedMessage);
                return messageData;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            else
            {
              continue;
            }
        }

    }

}
