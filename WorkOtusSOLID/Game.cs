using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOtusSOLID.Interface;

namespace WorkOtusSOLID
{
    public class Game
    {
        private readonly IGameSetting _gameSetting;
        private int _targetNumber;
        private int _attemptCount;

        public Game(IGameSetting gameSetting)
        {
            _gameSetting = gameSetting;
            _attemptCount = 0;
        }

        public void Start()
        {
            _targetNumber = GenerateNumber();
            Console.WriteLine($"Угадайте число! У вас {_gameSetting.AttemptCount} попыток");

            while (true)
            {
                _attemptCount++;
				if(_attemptCount > _gameSetting.AttemptCount)
				{
					Console.WriteLine($"Вы не угадали число {_targetNumber} за  {_attemptCount - 1} попыток.");
					break;
				}
				Console.WriteLine($"Попытка № {_attemptCount}.");
                Console.WriteLine("Введите число");
                int numberUser = Convert.ToInt32(Console.ReadLine());
                if (_targetNumber == numberUser)
                {
                    Console.WriteLine(
                        $"Поздравляю! Вы угадали число {_targetNumber} за {_attemptCount} попыток."
                    );
                    break;
                }
                else if (_targetNumber > numberUser)
                {
                    Console.WriteLine("Загаданное число больше.");
                }
                else
                {
                    Console.WriteLine("Загаданное число меньше.");
                }
            }
			Console.WriteLine("Игра завершена!");
        }

        private int GenerateNumber()
        {
            Random random = new Random();
            return random.Next(_gameSetting.MinNumber, _gameSetting.MaxNumber);
        }
    }
}
