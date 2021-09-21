
namespace CARO_X
{
    partial class MultiplayerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiplayerView));
            this.pnBoard = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPlayerWin = new System.Windows.Forms.Label();
            this.lbPlayerScore = new System.Windows.Forms.Label();
            this.lbPlayer = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnLeaveRoom = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnChallenge = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstOnl = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnBoard
            // 
            this.pnBoard.Location = new System.Drawing.Point(12, 53);
            this.pnBoard.Name = "pnBoard";
            this.pnBoard.Size = new System.Drawing.Size(856, 711);
            this.pnBoard.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.label4.Location = new System.Drawing.Point(12, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 37);
            this.label4.TabIndex = 8;
            this.label4.Text = "CARO - X";
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(124)))), ((int)(((byte)(138)))));
            this.btnClose.Location = new System.Drawing.Point(1088, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 40);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(891, 188);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbPlayerWin);
            this.panel2.Controls.Add(this.lbPlayerScore);
            this.panel2.Controls.Add(this.lbPlayer);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(873, 374);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 132);
            this.panel2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.label2.Location = new System.Drawing.Point(57, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Win:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.label1.Location = new System.Drawing.Point(40, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Scores:";
            // 
            // lbPlayerWin
            // 
            this.lbPlayerWin.AutoSize = true;
            this.lbPlayerWin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayerWin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.lbPlayerWin.Location = new System.Drawing.Point(111, 86);
            this.lbPlayerWin.Name = "lbPlayerWin";
            this.lbPlayerWin.Size = new System.Drawing.Size(44, 24);
            this.lbPlayerWin.TabIndex = 1;
            this.lbPlayerWin.Text = "Text";
            // 
            // lbPlayerScore
            // 
            this.lbPlayerScore.AutoSize = true;
            this.lbPlayerScore.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayerScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.lbPlayerScore.Location = new System.Drawing.Point(111, 45);
            this.lbPlayerScore.Name = "lbPlayerScore";
            this.lbPlayerScore.Size = new System.Drawing.Size(44, 24);
            this.lbPlayerScore.TabIndex = 1;
            this.lbPlayerScore.Text = "Text";
            // 
            // lbPlayer
            // 
            this.lbPlayer.AutoSize = true;
            this.lbPlayer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.lbPlayer.Location = new System.Drawing.Point(111, 9);
            this.lbPlayer.Name = "lbPlayer";
            this.lbPlayer.Size = new System.Drawing.Size(44, 24);
            this.lbPlayer.TabIndex = 1;
            this.lbPlayer.Text = "Text";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.label9.Location = new System.Drawing.Point(3, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 24);
            this.label9.TabIndex = 1;
            this.label9.Text = "Your Name:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnMenu);
            this.panel3.Controls.Add(this.btnSetting);
            this.panel3.Controls.Add(this.btnLeaveRoom);
            this.panel3.Controls.Add(this.btnNewGame);
            this.panel3.Location = new System.Drawing.Point(876, 555);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(241, 209);
            this.panel3.TabIndex = 11;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Location = new System.Drawing.Point(20, 159);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(200, 39);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.Text = "Back To Menu";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.Location = new System.Drawing.Point(20, 111);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(200, 39);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = false;
            // 
            // btnLeaveRoom
            // 
            this.btnLeaveRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.btnLeaveRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeaveRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaveRoom.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeaveRoom.Location = new System.Drawing.Point(20, 63);
            this.btnLeaveRoom.Name = "btnLeaveRoom";
            this.btnLeaveRoom.Size = new System.Drawing.Size(200, 39);
            this.btnLeaveRoom.TabIndex = 0;
            this.btnLeaveRoom.Text = "Leave Room";
            this.btnLeaveRoom.UseVisualStyleBackColor = false;
            this.btnLeaveRoom.Click += new System.EventHandler(this.btnLeaveRoom_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.btnNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGame.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.Location = new System.Drawing.Point(20, 15);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(200, 39);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Location = new System.Drawing.Point(3, 43);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1124, 732);
            this.panel4.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnChallenge);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lstOnl);
            this.panel1.Location = new System.Drawing.Point(873, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 172);
            this.panel1.TabIndex = 0;
            // 
            // btnReload
            // 
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.Location = new System.Drawing.Point(191, 7);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(27, 24);
            this.btnReload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnReload.TabIndex = 3;
            this.btnReload.TabStop = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(18, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // btnChallenge
            // 
            this.btnChallenge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.btnChallenge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChallenge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChallenge.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChallenge.Location = new System.Drawing.Point(18, 122);
            this.btnChallenge.Name = "btnChallenge";
            this.btnChallenge.Size = new System.Drawing.Size(200, 41);
            this.btnChallenge.TabIndex = 2;
            this.btnChallenge.Text = "Challenge";
            this.btnChallenge.UseVisualStyleBackColor = false;
            this.btnChallenge.Click += new System.EventHandler(this.btnChallenge_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.label3.Location = new System.Drawing.Point(51, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Online List";
            // 
            // lstOnl
            // 
            this.lstOnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.lstOnl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.lstOnl.FormattingEnabled = true;
            this.lstOnl.ItemHeight = 16;
            this.lstOnl.Location = new System.Drawing.Point(18, 37);
            this.lstOnl.Name = "lstOnl";
            this.lstOnl.Size = new System.Drawing.Size(200, 68);
            this.lstOnl.TabIndex = 0;
            // 
            // MultiplayerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1126, 776);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnBoard);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MultiplayerView";
            this.Text = "Multiplayer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnBoard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstOnl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChallenge;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox btnReload;
        private System.Windows.Forms.Label lbPlayerWin;
        private System.Windows.Forms.Label lbPlayerScore;
        private System.Windows.Forms.Label lbPlayer;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnLeaveRoom;
        private System.Windows.Forms.Button btnNewGame;
    }
}