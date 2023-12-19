using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOtusReflection.Interface
{
    public interface IDeserialize
    {
        F StartDeserialize(string serializedString);
    }
}