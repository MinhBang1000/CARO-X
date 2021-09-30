using CARO_X.Controllers;
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
    public partial class TwoPlayerView : Form
    {
        public MenuView menu;
        private Button[,] btn;
        // Lượt đánh và ô đã đánh
        private int[,] tick;
        private bool playerOneTiming = true;
        private bool playerTwoTiming = true;
        private bool turn;
        private bool result = false;
        private int backX;
        private int backY;
        // chưa có kết quả trận đấu

        // Lớp xử lý trận đấu
        private BattleController battle;

        public TwoPlayerView()
        {
            InitializeComponent();
            this.CenterToScreen();
            InitComponents();
            InitChessBoard();
        }

        // Function My Define
        // Khởi tạo bàn cở và đánh cờ
        public void InitComponents()
        {
            btn = new Button[Config.CHESS_X, Config.CHESS_Y];
            tick = new int[Config.CHESS_X,Config.CHESS_Y];
            // O đánh trước
            turn = true;
            this.battle = new BattleController();
            this.lbScoreO.Text = 0.ToString();
            this.lbScoreX.Text = 0.ToString();
            this.backX = -1;
            this.backY = -1;
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
                }
                x = 0;
                y += Config.CHESS_HEIGHT;
            }
        }

        public void ResetGame()
        {
            int n = Config.CHESS_X;
            int m = Config.CHESS_Y;
            int i, j;
            int x = 0;
            int y = 0;
            Button standardButton = new Button();
            this.turn = true;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    btn[i, j].BackgroundImage = standardButton.BackgroundImage;
                    btn[i, j].BackColor = Color.FromArgb(8, 17, 24);
                    tick[i, j] = -1;
                }
            }
            lbTime1.ForeColor = Color.FromArgb(54, 124, 138);
            lbTime2.ForeColor = Color.FromArgb(54, 124, 138);
            if (Config.TIME_TO_PLAY < 10)
            {
                lbTime1.Text = "0" + Config.TIME_TO_PLAY + ":00";
                lbTime2.Text = "0" + Config.TIME_TO_PLAY + ":00";
            }
            else
            {
                lbTime1.Text =Config.TIME_TO_PLAY + ":00";
                lbTime2.Text =Config.TIME_TO_PLAY + ":00";
            }
            result = false;
            battle.ResetRowWin();
            // Stop
            this.timer1.Stop();
            this.timer2.Stop();
            // Setting Clock
            this.trackM.Enabled = true;
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

        public void DrawChessAlready(int x, int y)
        {
            this.backX = x;
            this.backY = y;
            btn[x, y].BackColor = Color.FromArgb(8,200,204);
        }

        public void BackColorButton()
        {
            if (this.backX != -1) // bỏ qua lần đầu nhấn
            {
                btn[this.backX, this.backY].BackColor = Color.FromArgb(8,17,24);
            }
        }
        
        public void Draw(int x, int y, bool turn)
        {
            btn[x,y].BackgroundImageLayout = ImageLayout.Stretch;
            if (turn == true)
            {
                btn[x, y].BackColor = Color.FromArgb(8,200,204);//Chào em <3,..... iu em nhất 
            }
            else
            {
                btn[x, y].BackColor = Color.FromArgb(228,20,0); 
            }
            tick[x, y] = 0; // Tick xanh rồi

        }

        public void TestCase()
        {
            int i = 0;
            int first = 6;
            int end = 13;
            int sleep = 10;
            Thread th = new Thread(() => {
                while (i < Config.CHESS_X)
                {
                    if (i == 4)
                    {
                        for (int j = 0; j < Config.CHESS_Y; j++)
                        {
                            if (j != 6 && j != 7 && j != 8 && j != 11 && j != 12 && j != 13)
                            {
                                Draw(i, j, true);
                                Thread.Sleep(sleep);
                            }
                        }
                    }
                    else
                    {
                        if (i == 5)
                        {
                            for (int j = 0; j < Config.CHESS_Y; j++)
                            {
                                if (j < 5 || j > 14)
                                {
                                    Draw(i, j, true);
                                    Thread.Sleep(sleep);
                                }
                            }
                        }
                        else
                        {
                            if (i == 6 || i == 7)
                            {
                                for (int j = 0; j < Config.CHESS_Y; j++)
                                {
                                    if (j < 5 || j > 14)
                                    {
                                        Draw(i, j, true);
                                        Thread.Sleep(sleep);
                                    }
                                }
                            }
                            else
                            {
                                if (i >= 8 && i <= 14)
                                {
                                    for (int j = 0; j < Config.CHESS_Y; j++)
                                    {
                                        if (j >= first && j <= end)
                                        {
                                            //...
                                        }
                                        else
                                        {
                                            Draw(i, j, true);
                                            Thread.Sleep(sleep);
                                        }
                                    }
                                    first++;
                                    end--;
                                }
                                else
                                {
                                    for (int j = 0; j < Config.CHESS_Y; j++)
                                    {
                                        this.Draw(i, j, true);
                                        Thread.Sleep(sleep);
                                    }
                                }
                            }
                        }
                    }
                    i++;
                }
            });
            th.IsBackground = true;
            th.Start();
            
        }
        
        // Sự kiện nhất quán trên với 1
        public void ChessClick(Object Sender, EventArgs e)
        {
            // Bắt lấy cái nút nhấn
            Button btn = Sender as Button;
            string str = btn.Name;
            // Đánh dấu trên tick
            int index = str.IndexOf("_");
            string str1 = str.Substring(index+1);
            index = str1.IndexOf("_");
            int x = Convert.ToInt32(str1.Substring(0, index));
            int y = Convert.ToInt32(str1.Substring(index+1));
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
                    btn.BackgroundImage = Image.FromFile(Config.PATH_O);
                }
                else
                {
                    btn.BackgroundImage = Image.FromFile(Config.PATH_X);
                }
                // Tô màu và gỡ màu của nút vừa mới đánh
                this.BackColorButton();
                this.DrawChessAlready(x, y);
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
                        timer1.Stop();
                        timer2.Stop();
                        MessageBox.Show("O is Winner");
                        this.lbScoreO.Text = Convert.ToString(Convert.ToInt32(lbScoreO.Text) + 1);
                    }
                    else
                    {
                        if (win == 1) // X thắng
                        {
                            this.DrawRowWin();
                            BlockBoard();
                            result = true;
                            battle.score_x++;
                            timer1.Stop();
                            timer2.Stop();
                            MessageBox.Show("X is Winner");
                            this.lbScoreX.Text = Convert.ToString(Convert.ToInt32(lbScoreX.Text) + 1);
                        }
                    }
                }
                // đổi lượt
                this.turn = !this.turn; 
                if (!result)
                {
                    this.PlayerTurn();
                }
                // Setting Clock
                trackM.Enabled = false;
            }
            
        }
        
        // Sự kiện Hover các Chess Button
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

        // Đếm thời gian
        public void PlayerTurn()
        {
            if (this.turn)
            {
                timer1.Start();
                lbTime1.ForeColor = Color.FromArgb(8, 200, 204);
                timer2.Stop();
                lbTime2.ForeColor = Color.FromArgb(54, 124, 138);
            }
            else
            {
                timer2.Start();
                lbTime2.ForeColor = Color.FromArgb(8, 200, 204);
                timer1.Stop();
                lbTime1.ForeColor = Color.FromArgb(54, 124, 138);
            }
        }
        
        public void PlayerTime(Label lbTimer)
        {
            int minutes = Convert.ToInt32(lbTimer.Text.Substring(0,lbTimer.Text.IndexOf(":")));
            int seconds = Convert.ToInt32(lbTimer.Text.Substring(lbTimer.Text.IndexOf(":")+1));
            if (seconds == 0)
            {
                minutes--;
                if (minutes == 0)
                {
                    if (this.turn)
                    {
                        MessageBox.Show("X is Winner");
                    }
                    else
                    {
                        MessageBox.Show("O is Winner");
                    }
                }
                seconds = 59;
            }
            else
            {
                seconds--;
            }
            if (minutes < 10)
            {
                lbTimer.Text = "0" + minutes;
            }
            else
            {
                lbTimer.Text = minutes.ToString();
            }
            lbTimer.Text += ":";
            if (seconds < 10)
            {
                lbTimer.Text += "0" + seconds;
            }
            else
            {
                lbTimer.Text += seconds.ToString();
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


        // Event handle

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.playerOneTiming)
            {
                this.PlayerTime(lbTime1);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.playerTwoTiming)
            {
                this.PlayerTime(lbTime2);
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            this.ResetGame();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.menu.Show();
        }

        private void rOn_CheckedChanged(object sender, EventArgs e)
        {
            this.playerOneTiming = this.playerTwoTiming = true;
        }

        private void rOff_CheckedChanged(object sender, EventArgs e)
        {
            this.playerOneTiming = this.playerTwoTiming = false;
        }

        private void trackM_Scroll(object sender, EventArgs e)
        {
            int minutes = Convert.ToInt32(trackM.Value.ToString());
            if (minutes < 10)
            {
                lbTime1.Text = "0"+minutes + ":00";
                lbTime2.Text = "0" + minutes + ":00";
            }
            else
            {
                lbTime1.Text = minutes + ":00";
                lbTime2.Text = minutes + ":00";
            }
            Config.TIME_TO_PLAY = minutes;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            SettingView setting = new SettingView();
            setting.backForm = this;
            setting.Show();
        }

        public bool testcase = false;
        //if (testcase == false)
        //{
        //    this.TestCase();
        //    testcase = true;
        //}
        //else
        //{
        //    Thread th = new Thread(()=> {
        //        for (int i = 3; i < 12; i++)
        //        {
        //            for (int j = 5; j < 15; j++)
        //            {
        //                if (tick[i, j] == -1)
        //                {
        //                    Draw(i, j, false);
        //                    Thread.Sleep(20);
        //                }
        //            }
        //        }
        //    });
        //    th.IsBackground = true;
        //    th.Start();
        //}
    }
}
