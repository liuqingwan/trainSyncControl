using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace trainOCU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            startListenChuan();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            string backMessage = sendMessage(serverIP.Text, testSendText.Text, true);
            console.AppendText("收到服务器返回： " + backMessage + "\n");
        }

        //发送消息函数
        private string sendMessage(String ipa, String message, bool needBackMessage)
        {
            //设定服务器IP地址  
            IPAddress ip = IPAddress.Parse(ipa);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 8885)); //配置服务器IP与端口  
                console.AppendText("连接目标计算机成功" + "\n");
            }
            catch
            {
                console.AppendText("连接目标计算机失败" + "\n");
                return null;
            }
            try
            {
                string sendMessage = message + DateTime.Now;
                clientSocket.Send(Encoding.UTF8.GetBytes(sendMessage));
                console.AppendText("向服务器发送消息：" + sendMessage + "\n");

                if (needBackMessage)
                {
                    byte[] receiveBuf = new byte[1024];
                    int num = clientSocket.Receive(receiveBuf);
                    string backMessage = Encoding.UTF8.GetString(receiveBuf, 0, num);
                    return backMessage;
                }
                return null;
            }
            catch
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                return null;
            }
        }

        //监听串口函数
        private void startListenChuan()
        {
            string num = chuanNum.Text;


        }

        //向服务器发送注册消息
        private string register(string message)
        {

            return "";
        }
        //向服务器发送注销消息
        private string logout(string message)
        {

            return "";
        }
        //向服务器请求主车的ip
        private string askMainIP(string message)
        {

            return "";
        }
        //向服务器请求所有从车IP
        private string askFollowIP(string message)
        {

            return "";
        }
    }
}
