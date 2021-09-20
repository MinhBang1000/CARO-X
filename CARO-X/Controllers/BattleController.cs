using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARO_X.Controllers
{
    public class BattleController
    {
        public List<int> rowWinX;
        public List<int> rowWinY;

        // Điểm số giữa trận đấu
        public int score_o = 0;
        public int score_x = 0;

        // DEFINE
        public BattleController()
        {
            rowWinX = new List<int>(5);
            rowWinY = new List<int>(5);
            // Five in line to Win
        }

        // Lưu trữ List thắng cuộc
        public void ResetRowWin()
        {
            rowWinX.Clear();
            rowWinY.Clear();
        }
        public void AddRowWin(int x, int y)
        {
            rowWinX.Add(x);
            rowWinY.Add(y);
        }
        
        public bool CheckPeace(int[,] tick)
        {
            int i, j;
            int count = 0;
            for (i = 0; i < Config.CHESS_X; i++)
            {
                for (j = 0; j < Config.CHESS_Y; j++)
                {
                    if (tick[i, j] == -1 || tick[i,j]==-3)
                    {
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                return true;
            }
            return false;
        }

        // 0 - O, 1 - X, 2 là chưa biết
        // who 0 - O, 1 - X
        public int CheckWin(int[,] tick, int x, int y, int who)
        {
            if (this.CheckWinX(tick,x,y,who))
            {
                return who;
            }
            ResetRowWin();
            if (this.CheckWinY(tick, x, y, who))
            {
                return who;
            }
            ResetRowWin();
            if (this.CheckWinXY(tick, x, y, who))
            {
                return who;
            }
            ResetRowWin();
            if (this.CheckWinYX(tick, x, y, who))
            {
                return who;
            }
            ResetRowWin();
            return 2;
        }

        // Hàng ngang
        public bool CheckWinX(int[,] tick, int x, int y, int who) {
            int i = 0;
            int count = -1;
            for (i = 0; i < Config.WIN_RULE; i++)
            {
                if (y + i < Config.CHESS_Y)
                {
                    if (tick[x, y + i] == who)
                    {
                        count++;
                        this.AddRowWin(x, y+i);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
                
            }
            if (count >= 5)
            {
                return true;
            }
            for (i = 0; i < Config.WIN_RULE; i++)
            {
                if (y - i >= 0)
                {
                    if (tick[x, y - i] == who)
                    {
                        count++;
                        this.AddRowWin(x, y - i);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            if (count >= 5)
            {
                return true;
            }
            return false;
        }

        // Hàng dọc
        public bool CheckWinY(int[,] tick, int x, int y, int who)
        {
            int i = 0;
            int count = -1;
            for (i = 0; i < Config.WIN_RULE; i++)
            {
                if (x + i < Config.CHESS_X)
                {
                    if (tick[x + i, y] == who)
                    {
                        count++;
                        this.AddRowWin(x+i, y);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            if (count >= 5)
            {
                return true;
            }
            for (i = 0; i < Config.WIN_RULE; i++)
            {
                if (x - i >= 0)
                {
                    if (tick[x - i, y] == who)
                    {
                        count++;
                        this.AddRowWin(x-i, y);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                } 
            }
            if (count >= 5)
            {
                return true;
            }
            return false;
        }
        
        // Hàng chéo \
        public bool CheckWinXY(int[,] tick, int x, int y, int who)
        {
            int i = 0;
            int count = -1;
            for (i = 0; i < Config.WIN_RULE; i++)
            {
                if (x-i>=0 && y + i < Config.CHESS_Y)
                {
                    if (tick[x - i, y + i] == who)
                    {
                        count++;
                        this.AddRowWin(x-i, y + i);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (count >= 5)
            {
                return true;
            }
            for (i = 0; i < Config.WIN_RULE; i++)
            {
                if (x + i < Config.CHESS_X && y - i >= 0)
                {
                    if (tick[x + i, y - i] == who)
                    {
                        count++;
                        this.AddRowWin(x+i, y - i);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (count >= 5)
            {
                return true;
            }
            return false;
        }

        // Hàng chéo ?
        public bool CheckWinYX(int[,] tick, int x, int y, int who)
        {
            int i = 0;
            int count = -1;
            for (i = 0; i < Config.WIN_RULE; i++)
            {
                if (x - i >= 0 && y - i >= 0)
                {
                    if (tick[x - i, y - i] == who)
                    {
                        count++;
                        this.AddRowWin(x-i, y - i);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (count >= 5)
            {
                return true;
            }
            for (i = 0; i < Config.WIN_RULE; i++)
            {
                if (x + i < Config.CHESS_X && y + i < Config.CHESS_Y)
                {
                    if (tick[x + i, y + i] == who)
                    {
                        count++;
                        this.AddRowWin(x+i, y + i);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (count >= 5)
            {
                return true;
            }
            return false;
        }

    }
}
