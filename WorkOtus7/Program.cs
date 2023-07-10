using System.Diagnostics;
internal class Program
{
	private static void Main(string[] args)
	{
		Print(5);
		Print(10);
		Print(20);
	}
	static void Print(int n)
	{
		Stopwatch stopwatch = new Stopwatch();

		//Console.WriteLine(FibRec(6));
		stopwatch.Start();
		FibRec(n);
		stopwatch.Stop();
		 Console.WriteLine($"FibRec for {n} Execution time: {stopwatch.ElapsedMilliseconds} ms");

		//Console.WriteLine(FibCycle(6));
		stopwatch.Start();
		FibCycle(n);
		stopwatch.Stop();
		 Console.WriteLine($"FibCycle for {n} Execution time: {stopwatch.ElapsedMilliseconds} ms");
	}

	static int FibRec(int n)
	{
		if(n == 0) return 0;

		if(n == 1 || n == 2) return 1;

		return FibRec(n-1) + FibRec(n-2);
	}
	static int FibCycle(int n)
	{
		int f1 = 1,f2 = 1;

		for(int i = 0; i < (n-2); i++)
		{
			int sum = f1 +f2;
			f1 = f2;
			f2 = sum;
		}
		return f2;
	}


}