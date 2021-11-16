using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AdminCon_CLI_dotnetEdition.Components.Sound
{
    class BingoSounds
    {
        public BingoSounds()
        {
            ThreadStart playMusic = new ThreadStart(Bingo);
            Thread t = new Thread(playMusic);
            t.Start();
        }
        public void Bingo()//Super Mario
        {
            Console.Beep(659, 200);
            Console.Beep(659, 200);
            Console.Beep(659, 100);
            Thread.Sleep(80);
            Console.Beep(523, 200);
            Console.Beep(659, 100);
            Thread.Sleep(80);
            Console.Beep(783, 100);
            Thread.Sleep(400);
            Console.Beep(392, 100);
        }
    }
}
