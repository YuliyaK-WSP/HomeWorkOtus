using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using WorkOtusReflection.Interface;

namespace WorkOtusReflection
{
    public class SerializeNewtonsoft : ISerializeNewtonsoft
    {
        public string SerializeThroughNewtonsoft(F f)
        {
            string newtonsoftJson = Newtonsoft.Json.JsonConvert.SerializeObject(f);
			return newtonsoftJson;
        }
    }
}
