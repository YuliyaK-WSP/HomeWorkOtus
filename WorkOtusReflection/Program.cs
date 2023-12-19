using System;
using System.Security.AccessControl;
using System.Diagnostics;
using System.Text.Json;
using static WorkOtusReflection.ResultConsole;

namespace WorkOtusReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            MySerialize mySerialize = new MySerialize();
            MyDeserialize myDeserialize = new MyDeserialize();
            SerializeNewtonsoft serializeNewtonsoft = new SerializeNewtonsoft();
			DeserializeNewtonsoft deserializeNewtonsoft = new DeserializeNewtonsoft();
            F f = F.Get();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string json = mySerialize.ReplaySerialize(f, 100000);
            stopwatch.Stop();
            TimeSpan serializationTime = stopwatch.Elapsed;

            stopwatch.Restart();
            mySerialize.SerializeConsole(f);
            stopwatch.Stop();
            TimeSpan consoleOutputTime = stopwatch.Elapsed;

            stopwatch.Restart();
            serializeNewtonsoft.SerializeThroughNewtonsoft(f);
            stopwatch.Stop();
            TimeSpan newtonsoftJsonSerializationTime = stopwatch.Elapsed;

            stopwatch.Restart();
            f = myDeserialize.StartDeserialize(json);
            stopwatch.Stop();
            TimeSpan deserializationTime = stopwatch.Elapsed;

			stopwatch.Restart();
            f = deserializeNewtonsoft.StartDeserialize(json);
            stopwatch.Stop();
            TimeSpan newtonsoftJsondeserializationTime = stopwatch.Elapsed;
            Result(
                serializationTime,
                consoleOutputTime,
                newtonsoftJsonSerializationTime,
                deserializationTime,
				newtonsoftJsondeserializationTime
            );
        }
    }
}
