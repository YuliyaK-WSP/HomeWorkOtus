using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOtusReflection
{
    public static class ResultConsole
    {
        public static void Result(TimeSpan serializationTime,TimeSpan consoleOutputTime,TimeSpan newtonsoftJsonSerializationTime,TimeSpan deserializationTime,TimeSpan newtonsoftJsondeserializationTime)
		{
			Console.WriteLine("Мой рефлексионный механизм:");
            Console.WriteLine("Время на сериализацию = " + serializationTime);
			Console.WriteLine("Время на десериализацию = " + deserializationTime);
            Console.WriteLine("Время на вывод в консоль = " + consoleOutputTime);
            Console.WriteLine("Стандартный механизм (Newtonsoft.Json):");
            Console.WriteLine("Время на сериализацию = " + newtonsoftJsonSerializationTime);
            Console.WriteLine("Время на десериализацию = " + newtonsoftJsondeserializationTime);
		}
    }
}