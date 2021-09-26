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
    public partial class SettingView : Form
    {
        public Form backForm;
        
        public SettingView()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.CenterToScreen();
        }

        // FUNCTION
        public void ChooseIcon(int choose)
        {
            //O - X
            //MAN - WOMAN
            //SAMSUNG - APPLE
            //GOOGLE - MICROSOFT
            //SUPERHERO - SUPERVIVIAN
            //FACEBOOK - INSTARGRAM
            //TWITTER - YOUTUBE
            //JAVA - C#
            switch (choose)
            {
                case 0: 
                    {
                        Config.PATH_O = "ICON\\O.png";
                        Config.PATH_X = "ICON\\X.png";
                        break;
                    }
                case 1: 
                    {
                        Config.PATH_O = "ICON\\003-man.png";
                        Config.PATH_X = "ICON\\004-woman.png";
                        break;
                    }
                case 2: 
                    {
                        Config.PATH_O = "ICON\\005-samsung.png";
                        Config.PATH_X = "ICON\\006-apple.png";
                        break;
                    }
                case 3: 
                    {
                        Config.PATH_O = "ICON\\007-google.png";
                        Config.PATH_X = "ICON\\008-microsoft.png";
                        break;
                    }
                case 4: 
                    {
                        Config.PATH_O = "ICON\\O.png";
                        Config.PATH_X = "ICON\\X.png";
                        break;
                    }
                case 5: 
                    {
                        Config.PATH_O = "ICON\\001-facebook.png";
                        Config.PATH_X = "ICON\\002-instagram.png";
                        break;
                    }
                case 6: 
                    {
                        Config.PATH_O = "ICON\\011-twitter.png";
                        Config.PATH_X = "ICON\\012-youtube.png";
                        break;
                    }
                case 7: 
                    {
                        Config.PATH_O = "ICON\\009-java.png";
                        Config.PATH_X = "ICON\\010-hashtag.png";
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void trackA_Scroll(object sender, EventArgs e)
        {
            Config.VOLUME = Convert.ToInt32(trackA.Value);
            txtAudio.Text = trackA.Value.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.backForm.Show();
            this.Close();
        }

        private void txtAudio_TextChanged(object sender, EventArgs e)
        {
            if (txtAudio.Text != string.Empty)
            {
                try
                {
                    int vol = -1;
                    vol = Convert.ToInt32(txtAudio.Text);
                    Config.VOLUME = vol;
                    trackA.Value = Config.VOLUME;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You only can input number! Please input again");
                }
            }
            else
            {
                Config.VOLUME = 20;
                trackA.Value = Config.VOLUME;
            }
        }

        private void lstIco_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ChooseIcon(this.lstIco.SelectedIndex);
            this.btnO.BackgroundImage = Image.FromFile(Config.PATH_O);
            this.btnX.BackgroundImage = Image.FromFile(Config.PATH_X);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.trackA.Value = 20;
            Config.VOLUME = 20;
            this.ChooseIcon(0);
            this.lstIco.SelectedIndex = 0;
            this.btnO.BackgroundImage = Image.FromFile(Config.PATH_O);
            this.btnX.BackgroundImage = Image.FromFile(Config.PATH_X);
        }
    }
}
