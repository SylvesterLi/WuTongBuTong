using Microsoft.Azure.Devices.Client;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureIoTReconnect
{
    class CommunicationSolution
    {
        static DeviceClient deviceClient;

        #region SendModule发送模块
        /// <summary>
        /// 发送身份验证
        /// </summary>
        /// <param name="iotHubUri"></param>
        /// <param name="deviceID"></param>
        /// <param name="deviceKey"></param>
        /// <returns></returns>
        public static bool ConnectToSend(string iotHubUri, string deviceID, string deviceKey)
        {
            try
            {
                deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(deviceID, deviceKey), Microsoft.Azure.Devices.Client.TransportType.Mqtt);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 正式发送信息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static async Task SendDeviceToCloudMessageAsync(string msg)
        {
            var message = new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(msg));
            await deviceClient.SendEventAsync(message);
        }
        #endregion

        
    }
}
