using System;
using WorkOtusSOLID.Interface;

namespace WorkOtusSOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minNumber = 1;
            int maxNumber = 10;
			int attemptCount = 3;
			IGameSetting gameSetting = new GameSetting (minNumber,maxNumber,attemptCount);
            Game game = new Game(gameSetting);
            game.Start();
            //Console.WriteLine("Hello World!");
        }
    }
}
