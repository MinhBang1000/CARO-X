using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administrator
{
    public partial class AdminView : Form
    {
        public AdminView()
        {
            InitializeComponent();
            this.CenterToScreen();

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

        private void AdminView_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.dataSet.Users);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want modify this", "Save changes", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.usersTableAdapter.Update(this.dataSet.Users);
            }
            else if (dialogResult == DialogResult.No)
            {
                this.usersTableAdapter.Fill(this.dataSet.Users);
            }
            
        }
    }
}
