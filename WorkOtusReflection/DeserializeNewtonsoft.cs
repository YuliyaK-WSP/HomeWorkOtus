using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOtusReflection.Interface;

namespace WorkOtusReflection
{
    public class DeserializeNewtonsoft : IDeserialize
    {
        public F StartDeserialize(string serializedString)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<F>(serializedString);
        }
    }
}
