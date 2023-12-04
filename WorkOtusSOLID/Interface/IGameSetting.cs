using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOtusSOLID.Interface
{
    public interface IGameSetting
    {
        int MinNumber { get; }
        int MaxNumber { get; }
		int AttemptCount{get;}
    }
}
