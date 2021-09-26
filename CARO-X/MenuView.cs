using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARO_X
{
    public partial class MenuView : Form
    {
        public TwoPlayerView two;
        public LoginView login;
        private bool twoOrMulti = true;
        // Thread for music
        public Thread music = null;
        
        public MenuView()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Config.PlaySound();
            proBar.Visible = false;
            two = new TwoPlayerView();
            two.menu = this;
            this.CenterToScreen();
        }

        // FUNCTION MY DEFINE

        public void SetEnableButton(bool kt)
        {
            foreach (Button btn in Controls.OfType<Button>())
            {
                btn.Enabled = kt;
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

        // EVENT


        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (proBar.Value != proBar.Maximum)
            {
                proBar.PerformStep();
            }
            else
            {
                this.Hide();
                two.Show();
                timer.Stop();
                proBar.Value = 0;
                proBar.Visible = false;
                this.SetEnableButton(true);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.SetEnableButton(false);
            proBar.Visible = true;
            this.twoOrMulti = true;
            timer.Start();
        }

        private void btnOnline_Click(object sender, EventArgs e)
        {
            login = new LoginView();
            login.menu = this;
            login.Show();
            this.Hide();
            this.twoOrMulti = false;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            SettingView setting = new SettingView();
            setting.backForm = this;
            setting.Show();
        }
    }
}
