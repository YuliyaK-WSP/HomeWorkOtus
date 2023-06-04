using System.Diagnostics;
using System.Collections;
class Program
{
	const int elem = 1000000;
	private static void Main(string[] args)
	{
		List<int> list = new List<int>(elem);
		ArrayList arrayList = new ArrayList();
		var linkedList = new LinkedList<int>();
		Print(list);
		Print(arrayList);
		Print(linkedList);
	}
	public static void Print(object list)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		for (int i = 0; i < elem; i++)
		{
			switch (list)
			{
				case List<int>:
					((List<int>)list).Add(i);
					break;
				case ArrayList:
					((ArrayList)list).Add(i);
					break;
				case LinkedList<int>:
					((LinkedList<int>)list).AddLast(i);
					break;
			}
			if (i % 777 == 0)
			{
				Console.WriteLine($"Число {i} делится без остатка на 777");
			}
		}
		Console.WriteLine($"Выполнение операции {list.GetType().Name}: {stopwatch.ElapsedMilliseconds} m/s");
		SearchPrint(list);
		stopwatch.Stop();
	}

	public static void SearchPrint(Object obj)
	{
		int search = 496753;
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		switch (obj)
		{
			case List<int>:

				for (int i = 0; i < ((List<int>)obj).Count; i++)
				{
					if (i == search)
					{
						Console.WriteLine("Элемент 496753  найден");
						break;
					}
				}
				break;
			case ArrayList:
				for (int i = 0; i < ((ArrayList)obj).Count; i++)
				{
					if (i == search)
					{
						Console.WriteLine("Элемент 496753  найден");
						break;
					}
				}
				break;
			case LinkedList<int>:
				for (int i = 0; i < ((LinkedList<int>)obj).Count; i++)
				{
					if (i == search)
					{
						Console.WriteLine("Элемент 496753  найден");
						break;
					}
				}
				break;
		}
		stopwatch.Stop();
		Console.WriteLine($"Выполнение операции {obj.GetType().Name} Search: {stopwatch.ElapsedMilliseconds} m/s");
	}
}
