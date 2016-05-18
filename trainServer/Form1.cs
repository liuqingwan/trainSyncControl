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

namespace trainServer
{
    public partial class ServerWin : Form
    {
        private static byte[] result = new byte[1024];
        private static int myProt = 8885;   //端口
        private static Socket serverSocket;
        private IPAddress ip;
        private bool socktClosed = false;

        public ServerWin()
        {
            InitializeComponent();

            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipe.AddressList[2];
            this.ip = ipAddress;
            this.Text += " IP: " + ipAddress + "";

            CheckForIllegalCrossThreadCalls = false;
        }

        private void ServerWin_Load(object sender, EventArgs e)
        {

        }

        /// <summary>  
        /// 监听客户端连接  
        /// </summary>  
        private void ListenClientConnect()
        {
            while (true && !socktClosed)
            {
                try
                {
                    Socket clientSocket = serverSocket.Accept();
                    Thread receiveThread = new Thread(ReceiveMessage);
                    receiveThread.IsBackground = true;
                    receiveThread.Start(clientSocket);
                }
                catch (Exception ex)
                {
                    console.AppendText(ex.Message + "\n");
                }
            }
        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private void ReceiveMessage(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;
            while (true && !socktClosed)
            {
                try
                {
                    //通过clientSocket接收数据  
                    int receiveNumber = myClientSocket.Receive(result);
                    string reveiveMessage = Encoding.UTF8.GetString(result, 0,
                        receiveNumber);
                    console.AppendText(myClientSocket.RemoteEndPoint.ToString()
                        + ": " + reveiveMessage + "\n");

                    String backMessage = messageHandler(reveiveMessage);
                    if (backMessage != null)
                    {
                        myClientSocket.Send(Encoding.UTF8.GetBytes(backMessage));
                        console.AppendText(backMessage + " to " +
                            myClientSocket.RemoteEndPoint.ToString());
                    }
                }
                catch (Exception ex)
                {
                    console.AppendText(ex.Message + "\n");
                    myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();
                    break;
                }
            }
        }


        private void startServer_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(this.ip + "");
                serverSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ip, myProt));  //绑定IP地址：端口
                serverSocket.Listen(10);    //设定最多10个排队连接请求 
                console.AppendText("启动监听" + serverSocket.LocalEndPoint.ToString()
                    + "成功\n");
                socktClosed = false;
                Thread myThread = new Thread(ListenClientConnect);
                myThread.IsBackground = true;
                myThread.Start();
            }
            catch (Exception ex)
            {
                console.AppendText(ex.Message + "\n");
            }
        }

        private void shutServer_Click(object sender, EventArgs e)
        {
            serverSocket.Close();
            socktClosed = true;
            console.AppendText("关闭服务成功\n");
        }

        //处理从OCU接收到的消息
        private string messageHandler(string receiveMessage)
        {
            Console.WriteLine("pmm pmm " + receiveMessage);
            string result = "OK";
            string key = receiveMessage;
            switch (key)
            {

                default:
                    result = "ERROR";
                    break;
            }

            return result;
        }

        //处理注册请求
        private string registerHandler(string agrs)
        {

            return "1";
        }
        //处理注销请求
        private string logoutHandler(string agrs)
        {

            return "0";
        }
        //返回主车ip
        private string mainIPHandler(string args)
        {

            return "";
        }
        //返回从车列表
        private string followIPHandler(string args)
        {

            return "";
        }

        private void console_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
