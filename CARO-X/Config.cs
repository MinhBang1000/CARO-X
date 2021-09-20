using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARO_X
{
    public class Config
    {
        // Config Chess Board
        public static int CHESS_X = 18;
        public static int CHESS_Y = 20;
        public static int CHESS_WIDTH = 32;
        public static int CHESS_HEIGHT = 32;

        // Config Rules
        public static int WIN_RULE = 5;

        // Config Time to Play
        public static int TIME_TO_PLAY = 5; // 5 minutes
        public static bool PLAY_ON_TIME = true;

        // Config Client 
        public static int PORT = 9999;
    }
}
