using CARO_X.Controllers;
using CARO_X.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARO_X
{
    public partial class ProfileView : Form
    {
        public MultiplayerView multi;
        public string username;
        public UserResponse userInfo;
        public Socket profileSocket;

        public ProfileView()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        // FUNCTION
        public void FillData()
        {
            txtFullname.Text = userInfo.fullname;
            lbScore.Text += userInfo.total_score;
            lbWin.Text += userInfo.total_win;
            lbBattle.Text += userInfo.total_battle;
            pic.Image = Image.FromFile(userInfo.avatar);
            rFemale.Checked = true;
            if (userInfo.gender == 1)
            {
                rMale.Checked = true;
            }
        }

        public void SendUpdatePicture()
        {
            string msg = "avatar/"+this.username+"/"+Config.FOLDER;
            msg += this.dialog.FileName.Substring(this.dialog.FileName.LastIndexOf("\\")+1);
            byte[] data = StaticController.Encoding(msg);
            try
            {
                this.profileSocket.Send(data);
                File.Copy(this.dialog.FileName, Config.FOLDER + this.dialog.FileName.Substring(this.dialog.FileName.LastIndexOf("\\") + 1), true);
                pic.Image = Image.FromFile(Config.FOLDER+ this.dialog.FileName.Substring(this.dialog.FileName.LastIndexOf("\\") + 1));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -SendUpdatePicture- " + ex.Message);
            }
        }

        public void SendUpdateInfo()
        {
            int gender = 0;
            if (rMale.Checked)
            {
                gender = 1;
            }
            string msg = "info/"+username+"/"+txtFullname.Text+"/"+gender;
            byte[] data = StaticController.Encoding(msg);
            try
            {
                this.profileSocket.Send(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -SendUpdatePicture- " + ex.Message);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.multi.Show();
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            this.dialog.ShowDialog();
            if (this.dialog.FileName != string.Empty && this.dialog.FileName.IndexOf("\\")!=-1)
            {
                this.SendUpdatePicture();
                this.multi.ReloadProfile(Config.FOLDER + this.dialog.FileName.Substring(this.dialog.FileName.LastIndexOf("\\") + 1));
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            this.SendUpdateInfo();
        }
    }
}
