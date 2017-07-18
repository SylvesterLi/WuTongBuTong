using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using Microsoft.ServiceBus.Messaging;
using System.Threading;
using System.Diagnostics;

namespace AzureIoTReconnect
{
    public partial class Form1 : Form
    {

        static string iotHubD2cEndpoint = "messages/events";
        static EventHubClient eventHubClient;


        public Form1()
        {
            InitializeComponent();
        }

        #region SendPart发送消息部分
        /// <summary>
        /// 发送消息验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthenticBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var result = CommunicationSolution.ConnectToSend(tb_iotHubUri.Text, tb_deviceid.Text, tb_devicekey.Text);
                if (result)
                {
                    MessageBox.Show("验证通过,可以发送消息");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("身份验证信息错误：" + ex.Message);
            }
        }

        /// <summary>
        /// 正式发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void send_btn_Click(object sender, EventArgs e)
        {
            try
            {
                //此时已经通过身份验证
                //发送消息
                var messageData = tb_message.Text;
                var message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageData));
                await CommunicationSolution.SendDeviceToCloudMessageAsync(tb_message.Text);
                sendState.Text = "发送成功，UTC时间：" + DateTime.UtcNow+".当前时间："+DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送消息错误：" + ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// 接收消息身份验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AuthID_ClickAsync(object sender, EventArgs e)
        {
            eventHubClient = EventHubClient.CreateFromConnectionString(tb_ConnectString.Text, iotHubD2cEndpoint);

            if (eventHubClient != null)
            {
                messageRec.Text = "身份验证通过,连接可用";
            }
            else
            {
                messageRec.Text = "身份验证未通过";
            }

        }

    }
}
