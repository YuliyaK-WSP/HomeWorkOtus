using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOtusSOLID.Interface;


namespace WorkOtusSOLID
{
    public class GameSetting : IGameSetting
    {
        private int _minNumber;
        private int _maxNumber;
		private int _attemptCount;

        public int MinNumber => _minNumber;
        public int MaxNumber => _maxNumber;
		public int AttemptCount => _attemptCount;

		public GameSetting(int minNumber, int maxNumber, int attemptCount)
		{
			_minNumber = minNumber;
			_maxNumber = maxNumber;
			_attemptCount = attemptCount;
		}
    }
}
