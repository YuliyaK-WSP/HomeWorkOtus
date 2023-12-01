using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOtusSOLID.Interface
{
    public interface IRandomNumberGenerator
    {
        int GenerateNumber(int minValue, int maxValue);
    }
}