using BaliServer.Controllers;
using CARO_X.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BaliServer
{
    public partial class BaliServer : Form
    {
        /// <summary>
        /// Dùng để truy xuất CSDL
        /// </summary>
        private UserController userController;
        
        /// <summary>
        /// Dùng để kết nối Socket
        /// </summary>
        private Socket serverSocket;
        private Dictionary<string, Socket> clientList;
        private IPEndPoint ip;
        public BaliServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            clientList = new Dictionary<string, Socket>();
            userController = new UserController();
        }

        //FUNCTION DEFINE
        public void Connect()
        {
            ip = new IPEndPoint(IPAddress.Any, ConfigServer.PORT);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(ip);
            serverSocket.Listen(100);
            Thread listen = new Thread(()=>
            {
                try
                {
                    while (true)
                    {
                        Console.WriteLine("Listening Client to Connect");
                        Socket client = serverSocket.Accept();
                        Console.WriteLine("Connection Successful For New Client");
                        Thread receive = new Thread(()=> { 
                            while (true)
                            {
                                try
                                {
                                    // Receive Data
                                    Console.WriteLine("Waiting to receive message of Client on New Socket");
                                    byte[] receiveData = new byte[1024 * 10000];
                                    client.Receive(receiveData); // nghẽn
                                    MemoryStream ms = new MemoryStream(receiveData);
                                    BinaryFormatter bf = new BinaryFormatter();
                                    ProcessRequest(bf.Deserialize(ms) as string, client);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error -Connect- "+ex.Message);
                                    // Khi client tắt
                                    client.Close();
                                    break;
                                }
                            }
                        });
                        receive.IsBackground = true;
                        receive.Start();
                    }
                }
                catch
                {
                    ip = new IPEndPoint(IPAddress.Any, ConfigServer.PORT);
                    serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
                
            });
            listen.IsBackground = true;
            listen.Start();
        }
        public void CloseConnection()
        {
            serverSocket.Close();
            MessageBox.Show("Connection is Closed");
        }

        /// <summary>
        /// Hàm xử lý tất cả các loại Request
        /// </summary>
        /// <param name="msg"></param>
        public void ProcessRequest(string msg, Socket client)
        {
            string signal = msg.Substring(0,msg.IndexOf("/"));
            string content = msg.Substring(msg.IndexOf("/")+1);
            switch (signal)
            {
                case "login":
                    {
                        // người dùng muốn đăng nhập
                        string username = content.Substring(0,content.IndexOf("/"));
                        string password = content.Substring(content.IndexOf("/")+1);
                        // Kiến trúc để lấy dữ liệu về mô phỏng Json
                        //Dictionary<string, Object> data = new Dictionary<string, object>();
                        //bool check = userController.Login(username,password,data);
                        bool check = true;
                        string sendData = "login/";
                        byte[] sendCode = null;
                        if (check)
                        {
                            sendCode = StaticController.Encoding(sendData + "true");
                            clientList.Add(username, client);
                        }
                        else
                        {
                            sendCode = StaticController.Encoding(sendData + "false");
                        }
                        client.Send(sendCode);
                        break;
                    }
                case "online": // Yêu cầu gửi danh sách người dùng đang online
                    {
                        string msg1 = "online/" + clientList.Count+"/";
                        foreach (var kvp in clientList)
                        {
                            string username = kvp.Key;
                            if (client != kvp.Value)
                            {
                                msg1 += username + "/";
                            }
                        }
                        msg1 = msg1.Substring(0, msg1.LastIndexOf("/"));
                        byte[] data = StaticController.Encoding(msg1);
                        try
                        {
                            try
                            {
                                client.Send(data);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine("Exception "+ ex.ToString());
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Can't send to all Client -BaliServer-");
                        }
                        Console.WriteLine("Send List All User online Successful -BaliServer-");
                        break;
                    }
                case "play":
                    {
                        string msg1 = content;
                        string userCh = content.Substring(0,content.IndexOf("/"));
                        string userBeCh = content.Substring(content.IndexOf("/")+1);
                        Socket cli = this.clientList[userBeCh];
                        msg1 = "play/" + userCh + "/" + userBeCh;
                        try
                        {
                            byte[] data = StaticController.Encoding(msg1);
                            cli.Send(data);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error -ProcessRequest- "+ex.ToString());
                        }
                        break;
                    }
                case "canplay":
                    {
                        string msg1 = "canplay/" + content;
                        content = content.Substring(content.IndexOf("/") + 1);
                        string userCh = content.Substring(0, content.IndexOf("/"));
                        string userBeCh = content.Substring(content.IndexOf("/") + 1);
                        Socket cli = this.clientList[userCh];
                        try
                        {
                            byte[] data = StaticController.Encoding(msg1);
                            cli.Send(data);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error -ProcessRequest- " + ex.ToString());
                        }
                        break;
                    }
                case "tick":
                    {
                        string msg1 = content;
                        Console.WriteLine(msg1);
                        string userCh = content.Substring(0,content.IndexOf("/"));
                        content = content.Substring(content.IndexOf("/")+1);
                        string userBeCh = content.Substring(0, content.IndexOf("/"));
                        content = content.Substring(content.IndexOf("/")+1);
                        msg1 = "tick/" + userCh + "/" + userBeCh + "/" + content;
                        Socket cli = this.clientList[userBeCh];
                        try
                        {
                            byte[] data = StaticController.Encoding(msg1);
                            cli.Send(data);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error -ProcessRequest- tick " + ex.ToString());
                        }
                        break;
                    }
                case "winner":
                    {
                        string msg1 = content;
                        string userCh = content.Substring(0,content.IndexOf("/"));
                        string userBeCh = content.Substring(content.IndexOf("/")+1);
                        Socket cli = clientList[userBeCh];
                        msg1 = "winner/" + content;
                        byte[] data = StaticController.Encoding(msg1);
                        try
                        {
                            cli.Send(data);
                        }catch(Exception ex)
                        {
                            Console.WriteLine("Error -ProcessRequest- "+ex.ToString());
                        }
                        break;
                    }
                case "drawwin":
                    {
                        string msg1 = content;
                        string userCh = content.Substring(0, content.IndexOf("/"));
                        content = content.Substring(content.IndexOf("/")+1);
                        string userBeCh = content.Substring(0, content.IndexOf("/"));
                        content = content.Substring(content.IndexOf("/") + 1);
                        Socket cli = clientList[userBeCh];
                        msg1 = "drawwin/" + userCh + "/" + userBeCh + "/" + content;
                        byte[] data = StaticController.Encoding(msg1);
                        try
                        {
                            cli.Send(data);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error -ProcessRequest- " + ex.ToString());
                        }
                        break;
                    }
            }
        }

        

        // DRAG FORM
        [DllImport("user32")]
        private static extern bool ReleaseCapture();

        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wp, int lp);

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 161, 2, 0);
            }
        }

        //EVENT
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConnect_MouseEnter(object sender, EventArgs e)
        {
            this.btnConnect.ForeColor = Color.FromArgb(8, 200, 204);
        }

        private void btnConnect_MouseLeave(object sender, EventArgs e)
        {
            this.btnConnect.ForeColor = Color.FromArgb(54, 124, 138);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.Connect();
        }

        private void btnStop_MouseEnter(object sender, EventArgs e)
        {
            this.btnStop.ForeColor = Color.FromArgb(8, 200, 204);
        }

        private void btnStop_MouseLeave(object sender, EventArgs e)
        {
            this.btnStop.ForeColor = Color.FromArgb(54, 124, 138);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.CloseConnection();
        }

        
    }
}
