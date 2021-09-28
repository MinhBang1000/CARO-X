using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WMPLib;
using System.Threading;
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
        public static string PATH_O = "ICON\\O.png";
        public static string PATH_X = "ICON\\X.png";

        // Config Rules
        public static int WIN_RULE = 5;

        // Config Time to Play
        public static int TIME_TO_PLAY = 5; // 5 minutes
        public static bool PLAY_ON_TIME = true;

        // Config Client 
        public static int PORT = 9999;

        // Config Setting
        public static int VOLUME = 0;
        public static int CHESS = 0;

        // Config Audio
        public static Thread music;
        public static WindowsMediaPlayer player;
        public static void PlaySound()
        {
            music = new Thread(()=> {
                player = new WindowsMediaPlayer();
                player.URL = @"SOUND\\background_1.mp3";
                player.settings.volume = VOLUME;
                player.settings.setMode("loop",true);
                player.controls.play();
            });
            music.IsBackground = true;
            music.Start();
        }
        public static void ChangeVolume()
        {
            player.settings.volume = VOLUME;
        }

        // Config Avatar
        public static string FOLDER = "AVATAR\\";
    }
}
