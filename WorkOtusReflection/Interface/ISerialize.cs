using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOtusReflection.Interface
{
    public interface ISerialize
    {
        string ReplaySerialize(F f, int iterations);
        void SerializeConsole(F f);
    }
}
