using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using WorkOtusReflection.Interface;

namespace WorkOtusReflection
{
    public class MySerialize : ISerialize
    {
        public string ReplaySerialize(F f, int iterations)
        {
            string json = "";
            for (int i = 0; i < iterations; i++)
            {
                json = JsonSerializer.Serialize(f);
            }
            return json;
        }

        public void SerializeConsole(F f)
        {
            string json = JsonSerializer.Serialize(f);
            Console.WriteLine("Сериализованная строка: " + json);
        }
    }
}
