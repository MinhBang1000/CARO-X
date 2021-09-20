﻿using CARO_X.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARO_X
{
    public partial class MultiplayerView : Form
    {
        /// <summary>
        /// Quản lý kết nối Socket
        /// </summary>
        public Socket playerSocket;
        public LoginView login;
        public FriendView friendView;
        public string playerName;
        public string playerBeCh;

        /// <summary>
        /// Quản lý tác vụ đánh cờ
        /// </summary>
        public MenuView menu;
        private Button[,] btn;
        // Lượt đánh và ô đã đánh
        private int[,] tick;
        private bool[,] block;
        private bool turn;
        private bool result = false; // chưa có kết quả trận đấu

        /// <summary>
        /// Lớp xử lý trận đấu
        /// </summary>
        public BattleController battle;

        public MultiplayerView()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            InitComponents();
            InitChessBoard();
        }

        // FUNCTION MY DEFINE
        // Khởi tạo bàn cở và đánh cờ
        public void InitComponents()
        {
            btn = new Button[Config.CHESS_X, Config.CHESS_Y];
            tick = new int[Config.CHESS_X, Config.CHESS_Y];
            block = new bool[Config.CHESS_X, Config.CHESS_Y];
            // O đánh trước
            turn = true;
            this.battle = new BattleController();
        }

        public void InitChessBoard()
        {
            int n = Config.CHESS_X;
            int m = Config.CHESS_Y;
            int i, j;
            int x = 0;
            int y = 0;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Button chessBtn = new Button()
                    {
                        Width = Config.CHESS_WIDTH,
                        Height = Config.CHESS_HEIGHT,
                        Name = "_" + i + "_" + j,
                        Location = new Point(x, y)
                    };

                    // Design Button Chess to Flat Style
                    chessBtn.FlatStyle = FlatStyle.Flat;
                    chessBtn.FlatAppearance.BorderColor = Color.FromArgb(54, 124, 138);
                    chessBtn.FlatAppearance.BorderSize = 1;

                    // Add Event Click
                    chessBtn.Click += ChessClick;

                    // Add Event Enter
                    chessBtn.MouseEnter += ChessEnter;

                    // Add Event Leave
                    chessBtn.MouseLeave += ChessLeave;

                    pnBoard.Controls.Add(chessBtn); //1
                    x += Config.CHESS_WIDTH;
                    btn[i, j] = chessBtn;
                    tick[i, j] = -1; // là chưa có đánh gì hết
                    block[i, j] = true; // là cho đánh nhưng mở đầu sẽ bị hàm kia block lại
                }
                x = 0;
                y += Config.CHESS_HEIGHT;
            }
        }

        public void DrawRowWin()
        {
            int[] tempX = battle.rowWinX.ToArray();
            int[] tempY = battle.rowWinY.ToArray();
            int i = 0;
            for (i = 0; i <= 5; i++)
            {
                this.btn[tempX[i], tempY[i]].BackColor = Color.FromArgb(255, 204, 0);
            }
        }

        public void DrawRowWin(int[] tempX, int[] tempY)
        {
            int i = 0;
            for (i = 0; i < 5; i++)
            {
                this.btn[tempX[i], tempY[i]].BackColor = Color.FromArgb(255, 204, 0);
            }
        }

        public void BlockBoard()
        {
            int n = Config.CHESS_X;
            int m = Config.CHESS_Y;
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    tick[i, j] = -2; // Khóa lại khi hết giờ
                }
            }
        }

        public void SetNamePlayer()
        {
            this.lbPlayer.Text = this.playerName;
        }

        public void SetCenterForm()
        {
            this.CenterToScreen();
        }

        public void BlockAfterChess(bool check)
        {
            int x = Config.CHESS_X;
            int y = Config.CHESS_Y;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (tick[i, j] == -1)
                    {
                        block[i, j] = check;
                    }
                }
            }
        }        

        /// <summary>
        /// Để set turn khi đánh online
        /// </summary>
        /// <param name="turn"></param>
        public void SetTurn(bool turn)
        {
            this.turn = turn;
        }

        /// <summary>
        /// Khóa và mở các nút khi chơi
        /// </summary>
        /// <param name="tmp"></param>
        public void BlockButton(bool tmp)
        {
            
        }

        // Sự kiện nhất quán trên với 1
        /// <summary>
        /// Sự kiện các nút trên bàn cờ
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public void ChessClick(Object Sender, EventArgs e)
        {
            // Bắt lấy cái nút nhấn
            Button btn = Sender as Button;
            string str = btn.Name;
            // Đánh dấu trên tick
            int index = str.IndexOf("_");
            string str1 = str.Substring(index + 1);
            index = str1.IndexOf("_");
            int x = Convert.ToInt32(str1.Substring(0, index));
            int y = Convert.ToInt32(str1.Substring(index + 1));
            if (tick[x, y] == -1 && block[x,y]==true)
            {
                // Ô nào đánh rồi thì không cho đánh nữa
                this.block[x, y] = false;
                this.BlockAfterChess(false);
                // Là O
                this.tick[x, y] = 0;
                if (this.turn == false)
                {
                    this.tick[x, y] = 1;
                    // Là X
                }

                // Đánh quân cờ lên
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                if (this.turn == true)
                {
                    btn.BackgroundImage = Image.FromFile("ICON\\O.png");
                }
                else
                {
                    btn.BackgroundImage = Image.FromFile("ICON\\X.png");
                }

                // Xử lý thắng thua ở đây
                int win = -1;
                if (battle.CheckPeace(tick))
                {
                    // Hòa
                    MessageBox.Show("Peace");
                    result = true;
                }
                else
                {
                    if (turn == true)
                    {
                        win = this.battle.CheckWin(tick, x, y, 0);
                    }
                    else
                    {
                        win = this.battle.CheckWin(tick, x, y, 1);
                    }
                    if (win == 0) // O thắng
                    {
                        this.DrawRowWin();
                        BlockBoard();
                        result = true;
                        battle.score_o++;
                        
                        MessageBox.Show("O is Winner");
                    }
                    else
                    {
                        if (win == 1) // X thắng
                        {
                            this.DrawRowWin();
                            BlockBoard();
                            result = true;
                            battle.score_x++;
                            
                            MessageBox.Show("X is Winner");
                        }
                    }
                }
                // Gửi cho đối thủ
                string msg = "tick/"+this.playerName+"/"+this.playerBeCh+"/" + x + "/" + y + "/" + win;
                byte[] data = StaticController.Encoding(msg);
                try
                {
                    this.playerSocket.Send(data);
                }catch (Exception ex)
                {
                    Console.WriteLine("Error -ChessClick- "+ex.ToString());
                }
                // đổi lượt
                this.turn = !this.turn;
            }

        }
        
        public void ChessEnter(Object Sender, EventArgs e)
        {
            Button btn = Sender as Button;
            btn.FlatAppearance.BorderColor = Color.FromArgb(8, 200, 204);
        }
        
        public void ChessLeave(Object Sender, EventArgs e)
        {
            Button btn = Sender as Button;
            btn.FlatAppearance.BorderColor = Color.FromArgb(54, 124, 138);
        }

        // SERVER ACTION
        /// <summary>
        /// Hàm đánh cờ lên bàn cờ từ phía Server truyền qua
        /// </summary>
        /// win = {0,1,2} => 0 la O thắng , 1 là X thắng, 2 là hòa cờ
        public void AddItemOnline(string item)
        {
            this.lstOnl.Items.Add(item);
        }

        public void CheckTickArray()
        {
            int x = Config.CHESS_X;
            int y = Config.CHESS_Y;
            string str = "";
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    str += " " + tick[i, j];
                }
                str += "\n";
            }
            MessageBox.Show(str);
        }
        
        public void ChessTick(int x, int y, int winner)
        {
            Button btn = this.btn[x,y];
            this.block[x, y] = false;
            if (winner == 2)
            {
                if (tick[x, y] == -1)
                {
                    
                    // Là O
                    this.tick[x, y] = 0;
                    if (this.turn == false)
                    {
                        this.tick[x, y] = 1;
                        // Là X
                    }

                    // Đánh quân cờ lên
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    if (this.turn == true)
                    {
                        btn.BackgroundImage = Image.FromFile("ICON\\O.png");
                    }
                    else
                    {
                        btn.BackgroundImage = Image.FromFile("ICON\\X.png");
                    }
                    // Đổi lượt
                    this.turn = !this.turn;
                }
            }
            else
            {
                // Có người Win rồi thì không đánh nữa
                string msg = "winner/" + this.playerName + "/" + this.playerBeCh;
                this.tick[x, y] = 0;
                if (this.turn == false)
                {
                    this.tick[x, y] = 1;
                    // Là X
                }

                // Đánh quân cờ lên
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                if (this.turn == true)
                {
                    btn.BackgroundImage = Image.FromFile("ICON\\O.png");
                }
                else
                {
                    btn.BackgroundImage = Image.FromFile("ICON\\X.png");
                }
                // Đổi lượt
                this.turn = !this.turn;
                byte[] data = StaticController.Encoding(msg);
                try
                {
                    this.playerSocket.Send(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error -ChessTick- "+ex.ToString());
                }
                MessageBox.Show("Winner is "+this.playerBeCh);
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
            this.login.CloseConnection();
            Application.Exit();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            string msg = "online/list";
            this.lstOnl.Items.Clear();
            byte[] data = StaticController.Encoding(msg);
            try
            {
                playerSocket.Send(data);
            }
            catch
            {
                Console.WriteLine("Can't send data to server -MultiplayerView-");
            }
        }

        private void btnChallenge_Click(object sender, EventArgs e)
        {
            string friend = this.lstOnl.SelectedItem.ToString();
            string msg = "play/"+this.playerName+"/"+friend;
            byte[] data = StaticController.Encoding(msg);
            try
            {
                playerSocket.Send(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -btnChallenge- "+ex.ToString());
            }
        }

    }
}