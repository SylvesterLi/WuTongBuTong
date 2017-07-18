namespace AzureIoTReconnect
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.AuthenticBtn = new System.Windows.Forms.Button();
            this.tb_deviceid = new System.Windows.Forms.TextBox();
            this.tb_iotHubUri = new System.Windows.Forms.TextBox();
            this.tb_devicekey = new System.Windows.Forms.TextBox();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.send_btn = new System.Windows.Forms.Button();
            this.tb_ConnectString = new System.Windows.Forms.TextBox();
            this.AuthID = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.messageRec = new System.Windows.Forms.TextBox();
            this.sendState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AuthenticBtn
            // 
            this.AuthenticBtn.Location = new System.Drawing.Point(274, 193);
            this.AuthenticBtn.Name = "AuthenticBtn";
            this.AuthenticBtn.Size = new System.Drawing.Size(75, 38);
            this.AuthenticBtn.TabIndex = 0;
            this.AuthenticBtn.Text = "验证身份";
            this.AuthenticBtn.UseVisualStyleBackColor = true;
            this.AuthenticBtn.Click += new System.EventHandler(this.AuthenticBtn_Click);
            // 
            // tb_deviceid
            // 
            this.tb_deviceid.Location = new System.Drawing.Point(28, 45);
            this.tb_deviceid.Name = "tb_deviceid";
            this.tb_deviceid.Size = new System.Drawing.Size(321, 21);
            this.tb_deviceid.TabIndex = 1;
            // 
            // tb_iotHubUri
            // 
            this.tb_iotHubUri.Location = new System.Drawing.Point(30, 161);
            this.tb_iotHubUri.Name = "tb_iotHubUri";
            this.tb_iotHubUri.Size = new System.Drawing.Size(321, 21);
            this.tb_iotHubUri.TabIndex = 2;
            // 
            // tb_devicekey
            // 
            this.tb_devicekey.Location = new System.Drawing.Point(28, 100);
            this.tb_devicekey.Name = "tb_devicekey";
            this.tb_devicekey.Size = new System.Drawing.Size(321, 21);
            this.tb_devicekey.TabIndex = 3;
            // 
            // tb_message
            // 
            this.tb_message.Location = new System.Drawing.Point(28, 237);
            this.tb_message.Multiline = true;
            this.tb_message.Name = "tb_message";
            this.tb_message.Size = new System.Drawing.Size(321, 110);
            this.tb_message.TabIndex = 4;
            this.tb_message.Text = "Device To Cloud\r\n输入你发送的消息";
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(276, 353);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(75, 36);
            this.send_btn.TabIndex = 5;
            this.send_btn.Text = "发送";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // tb_ConnectString
            // 
            this.tb_ConnectString.Location = new System.Drawing.Point(451, 53);
            this.tb_ConnectString.Name = "tb_ConnectString";
            this.tb_ConnectString.Size = new System.Drawing.Size(234, 21);
            this.tb_ConnectString.TabIndex = 6;
            // 
            // AuthID
            // 
            this.AuthID.Location = new System.Drawing.Point(453, 100);
            this.AuthID.Name = "AuthID";
            this.AuthID.Size = new System.Drawing.Size(232, 45);
            this.AuthID.TabIndex = 8;
            this.AuthID.Text = "验证身份检测连接密钥可用性";
            this.AuthID.UseVisualStyleBackColor = true;
            this.AuthID.Click += new System.EventHandler(this.AuthID_ClickAsync);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "输入Device ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "输入Device Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "输入IoTHubUri";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "输入Connection String";
            // 
            // messageRec
            // 
            this.messageRec.Location = new System.Drawing.Point(451, 161);
            this.messageRec.Multiline = true;
            this.messageRec.Name = "messageRec";
            this.messageRec.Size = new System.Drawing.Size(234, 133);
            this.messageRec.TabIndex = 9;
            this.messageRec.Text = "身份验证状态";
            // 
            // sendState
            // 
            this.sendState.AutoSize = true;
            this.sendState.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.sendState.Location = new System.Drawing.Point(29, 391);
            this.sendState.Name = "sendState";
            this.sendState.Size = new System.Drawing.Size(0, 12);
            this.sendState.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 469);
            this.Controls.Add(this.sendState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageRec);
            this.Controls.Add(this.AuthID);
            this.Controls.Add(this.tb_ConnectString);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.tb_message);
            this.Controls.Add(this.tb_devicekey);
            this.Controls.Add(this.tb_iotHubUri);
            this.Controls.Add(this.tb_deviceid);
            this.Controls.Add(this.AuthenticBtn);
            this.Name = "Form1";
            this.Text = "梧桐不同：IoT Connector Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AuthenticBtn;
        private System.Windows.Forms.TextBox tb_deviceid;
        private System.Windows.Forms.TextBox tb_iotHubUri;
        private System.Windows.Forms.TextBox tb_devicekey;
        private System.Windows.Forms.TextBox tb_message;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.TextBox tb_ConnectString;
        private System.Windows.Forms.Button AuthID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox messageRec;
        private System.Windows.Forms.Label sendState;
    }
}

