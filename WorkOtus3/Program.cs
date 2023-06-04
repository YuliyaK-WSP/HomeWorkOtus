using System.Diagnostics;
using System.Collections;
class Program
{

	private static void Main(string[] args)
	{
		Console.WriteLine("Расчет уровнения вида: a * x^2 + b * x + c = 0");
		double a;
		double b;
		double c;
		do
		{
			Console.WriteLine("Введите значение a");
			a = double.Parse(Console.ReadLine());
		}
		while (!ValuesABC(a));
		do
		{
			Console.WriteLine("Введите значение b");
			b = double.Parse(Console.ReadLine());
		}
		while (!ValuesABC(b));

		do
		{
			Console.WriteLine("Введите значение c");
			c = double.Parse(Console.ReadLine());
		}
		while (!ValuesABC(c));


		D(a, b, c);
	}
	public static bool ValuesABC(double val)
	{
		try
		{

			if (val % 1 != 0)
			{
				throw new ValuesExseption();

			}

		}
		catch (ValuesExseption e)
		{
			Console.WriteLine($"{e.Message},число может быть только целым");
			return false;
		}
		return true;
	}
	public static void D(double a, double b, double c)
	{
		var d = (b * b) - 4 * a * c;
		switch (d)
		{
			case 0:
				Console.WriteLine("Уравнение имеет один корень");
				break;
			case < 0:
				Console.WriteLine("Уравнение корней не имеет");
				break;
			case > 0:
				Console.WriteLine("Уравнение имеет два различных корня");
				var x1 = ((-b) - Math.Sqrt(d)) / (2 * a);
				var x2 = ((-b) + Math.Sqrt(d)) / (2 * a);
				Console.WriteLine($"x1 = {x1} x2 = {x2}");
				break;
		}
		Console.WriteLine(d);
	}
}
class ValuesExseption : Exception
{
	public ValuesExseption() : base("Ошибка числа")
	{

	}
}

