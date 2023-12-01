using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOtusSOLID.Interface;

namespace WorkOtusSOLID
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int GenerateNumber(int minValue, int maxValue)
        {
            Random random = new Random();
            return random.Next(minValue, maxValue + 1);
        }
    }
}
