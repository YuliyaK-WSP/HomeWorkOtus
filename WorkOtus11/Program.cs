using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        OtusDictionary otusDictionary = new OtusDictionary();
        /*otusDictionary.Add(1, "value1");
        otusDictionary.Add(2, "value2");
        otusDictionary.Add(50, "value50");
        Console.WriteLine(otusDictionary.Get(1));
        Console.WriteLine(otusDictionary.Get(2));
        Console.WriteLine(otusDictionary.Get(50));*/
		for(int i = 0; i < 34; i++)
		{
			otusDictionary.Add(i,"test");
		}
        otusDictionary[4] = "value4";
        Console.WriteLine(otusDictionary[4]);
		Console.WriteLine(otusDictionary.capacity);
    }
}
