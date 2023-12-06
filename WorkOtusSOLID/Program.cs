using System.Security.Cryptography;
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
			IRandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
			IUserInput userInput = new UserInput();
            Game game = new Game(gameSetting,randomNumberGenerator,userInput);
            game.Start();
        }
    }
}
