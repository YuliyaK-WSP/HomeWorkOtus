using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using WorkOtusReflection.Interface;

namespace WorkOtusReflection
{
    public class MyDeserialize : IDeserialize
    {
        public F StartDeserialize(string serializedString)
		{
            F deserializedF = JsonSerializer.Deserialize<F>(serializedString);
			return deserializedF;
		}
    }
}