using CARO_X.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using CARO_X.Controllers;

namespace CARO_X
{
    public partial class RegisterView : Form
    {
        public LoginView login;
        public UserResponse userInfo;
        public Socket registerSocket;

        public RegisterView()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.userInfo = new UserResponse();
        }
        // DEFINE

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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.login.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            this.dialogFile.ShowDialog();
            txtBrowser.Text = this.dialogFile.FileName;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirm.Text)
            {
                // Username
                userInfo.username = txtUsername.Text;
                // Password
                userInfo.password = txtPassword.Text;
                // Fullname
                userInfo.fullname = txtFullname.Text;
                // Gender
                userInfo.gender = 0;
                if (rMale.Checked)
                {
                    userInfo.gender = 1;
                }
                // Avatar
                string name = txtBrowser.Text.Substring(txtBrowser.Text.LastIndexOf("\\") + 1);
                try
                {
                    File.Copy(this.dialogFile.FileName, Config.FOLDER + name,true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error -btnBrowser_Click- " + ex.Message);
                }
                userInfo.avatar = Config.FOLDER + name;
                // Auto Setup
                userInfo.id = -1;
                userInfo.total_score = userInfo.total_battle = userInfo.total_win = 0;
                string msg = "register/"+JsonConvert.SerializeObject(userInfo);
                try
                {
                    byte[] data = StaticController.Encoding(msg);
                    this.registerSocket.Send(data); 
                    MessageBox.Show("Register Successful!");
                    this.login.Show();
                    this.login.RegisterDone(userInfo.username,userInfo.password);
                    this.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error -btnRegister_Click- " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Password Confirm and Password are different! Please check them again");
            }
        }
    }
}
