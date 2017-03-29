using System;
using System.Linq;

namespace Pyatna
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] xx = new int[1024];
            for (int i = 0; i < 1024; ++i)
                xx[i] = i;
            IPlayable game = new Game2(xx);
            ConsoleGameUI CG = new ConsoleGameUI(game);
            CG.StartGame();
        }
    }
}