
namespace CARO_X
{
    partial class MenuView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuView));
            this.btnTwo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMulti = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnTitle = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTwo
            // 
            this.btnTwo.AutoSize = true;
            this.btnTwo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTwo.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTwo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(124)))), ((int)(((byte)(138)))));
            this.btnTwo.Location = new System.Drawing.Point(397, 170);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(165, 37);
            this.btnTwo.TabIndex = 9;
            this.btnTwo.Text = "Two Players";
            this.btnTwo.Click += new System.EventHandler(this.btnTwo_Click);
            this.btnTwo.MouseEnter += new System.EventHandler(this.btnTwo_MouseEnter);
            this.btnTwo.MouseLeave += new System.EventHandler(this.btnTwo_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.label5.Location = new System.Drawing.Point(186, -11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(253, 73);
            this.label5.TabIndex = 8;
            this.label5.Text = "CARO - X";
            // 
            // btnMulti
            // 
            this.btnMulti.AutoSize = true;
            this.btnMulti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMulti.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMulti.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(124)))), ((int)(((byte)(138)))));
            this.btnMulti.Location = new System.Drawing.Point(397, 245);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(173, 37);
            this.btnMulti.TabIndex = 9;
            this.btnMulti.Text = "Multiplayers";
            this.btnMulti.Click += new System.EventHandler(this.btnMulti_Click);
            this.btnMulti.MouseEnter += new System.EventHandler(this.btnMulti_MouseEnter);
            this.btnMulti.MouseLeave += new System.EventHandler(this.btnMulti_MouseLeave);
            // 
            // btnSetting
            // 
            this.btnSetting.AutoSize = true;
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(124)))), ((int)(((byte)(138)))));
            this.btnSetting.Location = new System.Drawing.Point(397, 320);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(103, 37);
            this.btnSetting.TabIndex = 9;
            this.btnSetting.Text = "Setting";
            this.btnSetting.MouseEnter += new System.EventHandler(this.btnSetting_MouseEnter);
            this.btnSetting.MouseLeave += new System.EventHandler(this.btnSetting_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(124)))), ((int)(((byte)(138)))));
            this.btnClose.Location = new System.Drawing.Point(596, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 40);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 126);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(326, 299);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // proBar
            // 
            this.proBar.Location = new System.Drawing.Point(0, 475);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(633, 5);
            this.proBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.proBar.TabIndex = 12;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.label5);
            this.pnTitle.Location = new System.Drawing.Point(0, 51);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(633, 429);
            this.pnTitle.TabIndex = 13;
            this.pnTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnTitle_MouseMove);
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(634, 480);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.proBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnMulti);
            this.Controls.Add(this.btnTwo);
            this.Controls.Add(this.pnTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuView";
            this.Text = "MenuView";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btnTwo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label btnMulti;
        private System.Windows.Forms.Label btnSetting;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar proBar;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel pnTitle;
    }
}