using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CARO_X.Controllers;

namespace CARO_X
{
    public partial class LoginView : Form
    {
        private Socket loginSocket;
        private IPEndPoint loginIP;
        public MenuView menu;
        public MultiplayerView multiplayerView;

        public LoginView()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.CenterToScreen();
            this.Connect();
        }
        // DEFINE

        public void Connect()
        {
            loginIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"),Config.PORT);
            loginSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            Thread connection = new Thread(()=> {
                try
                {
                    loginSocket.Connect(loginIP);
                    Thread receive = new Thread(()=> { 
                        while (true)
                        {
                            try
                            {
                                byte[] receiveData = new byte[1024 * 5000];
                                loginSocket.Receive(receiveData);
                                MemoryStream ms = new MemoryStream(receiveData);
                                BinaryFormatter bf = new BinaryFormatter();
                                ProccessRespond(bf.Deserialize(ms) as string);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error -Connect- "+ex.Message);
                                break;
                                CloseConnection();
                            }
                        }
                    });
                    receive.IsBackground = true;
                    receive.Start();
                }
                catch
                {
                    CloseConnection();
                }
            });
            connection.IsBackground = true;
            connection.Start();
        }

        public void CloseConnection()
        {
            loginSocket.Close();
            Console.WriteLine("Connection Be Closed or Can't Connect");
        }

        /// <summary>
        /// Hàm xử lý các respond từ server cho các View khác luôn 
        /// </summary>
        /// <param name="msg"></param>
        public void ProccessRespond(string msg)
        {
            string signal = msg.Substring(0, msg.IndexOf("/"));
            string content = msg.Substring(msg.IndexOf("/") + 1);
            switch (signal)
            {
                case "login":
                    {
                        if (content == "true")
                        {
                            this.multiplayerView = new MultiplayerView();
                            this.multiplayerView.login = this;
                            this.multiplayerView.playerSocket = loginSocket;
                            this.multiplayerView.playerName = txtUsername.Text;
                            
                            this.multiplayerView.SetNamePlayer();
                            this.Invoke((MethodInvoker)delegate {
                                this.multiplayerView.SetCenterForm();
                                this.multiplayerView.Show();
                                this.Hide();
                            });
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai! Vui lòng nhập lại");
                        }
                        break;
                    }
                case "play":
                    {
                        // Xác định là có chơi hay không
                        string userCh = content.Substring(0,content.IndexOf("/"));
                        string userBeCh = content.Substring(content.IndexOf("/") + 1);
                        string msg1 = "";
                        DialogResult dialogResult = MessageBox.Show("Do you want to play with "+userCh, "CARO-X MESSAGE", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            msg1 = "canplay/true/" + content;
                            // Unlock bàn cờ
                            
                            // Set turn
                            this.multiplayerView.SetTurn(true);
                            // Khóa các nút lại --> Mời bạn
                            this.multiplayerView.BlockButton(false);
                            // Nhớ tên người đấu
                            this.multiplayerView.playerBeCh = userCh; 
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            msg1 = "canplay/false/" + content;
                        }
                        byte[] data = StaticController.Encoding(msg1);
                        try
                        {
                            loginSocket.Send(data);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error -ProccessRespond- "+ex.ToString());
                        }
                        break;
                    }
                case "canplay":
                    {
                        // Xác định là có chơi hay không --> trả lời
                        string check = content.Substring(0, content.IndexOf("/"));
                        content = content.Substring(content.IndexOf("/")+1);
                        string userCh = content.Substring(0, content.IndexOf("/"));
                        string userBeCh = content.Substring(content.IndexOf("/") + 1);
                        string msg1 = "";
                        if (check == "true")
                        {
                            MessageBox.Show(userBeCh + " said: OK. Both can play together right now! Have fun!");
                            // Unlock bàn cờ
                            
                            // Set turn
                            this.multiplayerView.SetTurn(true);
                            // Khóa các nút lại --> Mời bạn
                            this.multiplayerView.BlockButton(false);
                            // Nhớ người đánh
                            this.multiplayerView.playerBeCh = userBeCh;
                        }
                        else
                        {
                            MessageBox.Show(userBeCh+" can't play right now! Please choose anthor friend");
                        }
                        break;
                    }
                case "online":
                    {
                        // Xác định bao nhiêu người online server gửi đến
                        string temp = content;
                        // Số nguời online
                        int amount = Convert.ToInt32(temp.Substring(0, temp.IndexOf("/")));
                        temp = temp.Substring(temp.IndexOf("/") + 1);
                        this.Invoke((MethodInvoker)delegate
                        {
                            while (temp.IndexOf("/") != -1)
                            {
                                string item = temp.Substring(0, temp.IndexOf("/"));
                                this.multiplayerView.AddItemOnline(item);
                                temp = temp.Substring(temp.IndexOf("/") + 1);
                            }
                            this.multiplayerView.AddItemOnline(temp);
                        });
                        break;
                    }
                case "tick":
                    {
                        string msg1 = content;
                        string userCh = content.Substring(0,content.IndexOf("/"));
                        content = content.Substring(content.IndexOf("/")+1);
                        string userBeCh = content.Substring(0,content.IndexOf("/"));
                        content = content.Substring(content.IndexOf("/") + 1);
                        int x = Convert.ToInt32(content.Substring(0, content.IndexOf("/")));
                        content = content.Substring(content.IndexOf("/") + 1);
                        int y = Convert.ToInt32(content.Substring(0, content.IndexOf("/")));
                        content = content.Substring(content.IndexOf("/") + 1);
                        int win = Convert.ToInt32(content.Substring(0));
                        
                        this.Invoke((MethodInvoker)delegate {
                            this.multiplayerView.ChessTick(x,y,win);
                        });
                        break;
                    }
                case "winner":
                    {
                        string msg1 = content;
                        string userCh = content.Substring(0, content.IndexOf("/"));
                        string userBeCh = content.Substring(content.IndexOf("/")+1);
                        msg1 = "drawwin/" + this.multiplayerView.playerName + "/" + this.multiplayerView.playerBeCh;
                        int[] tempX = multiplayerView.battle.rowWinX.ToArray();
                        int[] tempY = multiplayerView.battle.rowWinY.ToArray();
                        int i = 0;
                        for (i = 1; i <= 5; i++)
                        {
                            msg1 += "/" + tempX[i] + "/" + tempY[i];
                        }
                        byte[] data = StaticController.Encoding(msg1);
                        try
                        {
                            this.loginSocket.Send(data);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error -ProccessRespond- "+ex.ToString());
                        }
                        break;
                    }
                case "drawwin":
                    {
                        string msg1 = content;
                        content = content.Substring(content.IndexOf("/") + 1);
                        content = content.Substring(content.IndexOf("/") + 1);
                        List<int> X = new List<int>();
                        List<int> Y = new List<int>();
                        X.Add(Convert.ToInt32(content.Substring(0,content.IndexOf("/"))));
                        content = content.Substring(content.IndexOf("/") + 1);
                        Y.Add(Convert.ToInt32(content.Substring(0, content.IndexOf("/"))));
                        content = content.Substring(content.IndexOf("/") + 1);
                        X.Add(Convert.ToInt32(content.Substring(0, content.IndexOf("/"))));
                        content = content.Substring(content.IndexOf("/") + 1);
                        Y.Add(Convert.ToInt32(content.Substring(0, content.IndexOf("/"))));
                        content = content.Substring(content.IndexOf("/") + 1);
                        X.Add(Convert.ToInt32(content.Substring(0, content.IndexOf("/"))));
                        content = content.Substring(content.IndexOf("/") + 1);
                        Y.Add(Convert.ToInt32(content.Substring(0, content.IndexOf("/"))));
                        content = content.Substring(content.IndexOf("/") + 1);
                        X.Add(Convert.ToInt32(content.Substring(0, content.IndexOf("/"))));
                        content = content.Substring(content.IndexOf("/") + 1);
                        Y.Add(Convert.ToInt32(content.Substring(0, content.IndexOf("/"))));
                        content = content.Substring(content.IndexOf("/") + 1);
                        X.Add(Convert.ToInt32(content.Substring(0, content.IndexOf("/"))));
                        Y.Add(Convert.ToInt32(content.Substring(content.IndexOf("/")+1)));
                        int[] tempX = X.ToArray();
                        int[] tempY = Y.ToArray();
                        this.multiplayerView.DrawRowWin(tempX,tempY);
                        
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
            this.CloseConnection();
            Application.Exit();
        }

        private void btnRegister_MouseHover(object sender, EventArgs e)
        {
            this.btnRegister.ForeColor = Color.FromArgb(0, 190, 252);
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            this.btnRegister.ForeColor = Color.FromArgb(54, 124, 138);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterView re = new RegisterView();
            re.Show();
            re.login = this;
            this.Hide();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string sendData = "login/"+username+"/"+password;
            bf.Serialize(ms,sendData);
            try
            {
                this.loginSocket.Send(ms.ToArray());
            }
            catch
            {
                MessageBox.Show("Can't Login");
            }
        }
    }
}
