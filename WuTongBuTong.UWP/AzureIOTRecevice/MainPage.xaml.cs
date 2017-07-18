using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;

using Microsoft.Azure.Devices.Client;
using System.Threading.Tasks;
using System.Text;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace AzureIOTRecevice
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        AzureIoTHub az = new AzureIoTHub();
        public MainPage()
        {
            this.InitializeComponent();
            initializeBackground.BackgroundInt(rootGrid);
        }

        /// <summary>
        /// 发送的验证身份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void send_click(object sender, RoutedEventArgs e)
        {
            //此时已经通过身份验证
            //发送消息
            var messageData =  tblock.Text;
            var message =new Message(Encoding.ASCII.GetBytes(messageData));
            await az.SendDeviceToCloudMessageAsync(tblock.Text);
        }
        /// <summary>
        /// 接收的验证身份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void receAuth_click(object sender, RoutedEventArgs e)
        {

            bool result =az.ConnectToReceive((string)tb_connectionString.Text,tb2_deviceId.Text);
            if (result)
            {
                receiveMe.Text = "验证通过";
                //开始后台接收
                //receiveMe.Text=await az.ReceiveCloudToDeviceMessageAsync(tb_connectionString.Text,tb2_deviceId.Text);
            }
            else
            {
                receiveMe.Text = "身份验证未通过呢";
                
            }
        }

        private void sendAuth_click(object sender, RoutedEventArgs e)
        {
            reBtn.IsEnabled = true;
            string iotHubUri = tb_IOTHubUri.Text;
            string deviceID = tb_deviceId.Text;
            string deviceKey = tb_deviceKey.Text;
            var result = az.ConnectToSend(iotHubUri, deviceID, deviceKey);
            if (result)
            {
                tblock.Text = "验证通过,可以点击此处发送消息";
            }
            else
            {
                tblock.Text = "身份验证未通过";
            }
        }

        private async void receiveStart_click(object sender, RoutedEventArgs e)
        {
            reBtn.IsEnabled = !reBtn.IsEnabled;
            receiveMe.Text = "正在等待并接收消息";
            //开始后台接收
            receiveMe.Text = await az.ReceiveCloudToDeviceMessageAsync(tb_connectionString.Text, tb2_deviceId.Text);
        }
    }
}
