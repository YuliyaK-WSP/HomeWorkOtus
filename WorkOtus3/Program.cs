using System.Diagnostics;
using System.Collections;
using System;
class Program
{
	private static int startposition;

	private static Dictionary<string, string> valVar = new Dictionary<string, string>()
	{
		["a"] = "",
		["b"] = "",
		["c"] = ""
	};
	private static List<string> strVal = new List<string>();
	static double a;
	static double b;
	static double c;
	private static void SetDown()
	{
		if (selectedValue < startposition + valVar.Count - 1)
		{
			Console.SetCursorPosition(0, selectedValue);
			Console.Write(' ');
			selectedValue++;
			Console.SetCursorPosition(0, selectedValue);
			Console.Write('>');
			Console.SetCursorPosition(4, selectedValue);
		}

	}

	private static void PrintMenu()
	{
		strVal.Clear();
		Console.WriteLine("Расчет уровнения вида: a * x^2 + b * x + c = 0");
		foreach (string item in valVar.Keys)
		{
			Console.WriteLine($"  {item}:");
			strVal.Add(item);
		}
		Console.WriteLine("Для выхода нажмие ESC");
	}
	private static void SetUp()
	{
		if (selectedValue > startposition)
		{
			Console.SetCursorPosition(0, selectedValue);
			Console.Write(' ');
			selectedValue--;
			Console.SetCursorPosition(0, selectedValue);
			Console.Write('>');
			Console.SetCursorPosition(4, selectedValue);
		}
	}
	private static int selectedValue;

	private static void Start()
	{
		ConsoleKeyInfo ki;
		startposition = Console.CursorTop + 1;
		selectedValue = startposition;
		PrintMenu();
		Console.SetCursorPosition(0, selectedValue);
		Console.Write('>');
		Console.SetCursorPosition(4, selectedValue);
		string inputstr = "";
		do
		{
			ki = Console.ReadKey();

			switch (ki.Key)
			{
				case ConsoleKey.UpArrow:
					SaveValue(selectedValue - startposition, inputstr);
					SetUp();
					inputstr = "";
					break;
				case ConsoleKey.DownArrow:
					SaveValue(selectedValue - startposition, inputstr);
					SetDown();
					inputstr = "";
					break;
				case ConsoleKey.Enter:
					SaveValue(selectedValue - startposition, inputstr);
					inputstr = "";
					Console.SetCursorPosition(0, startposition + valVar.Count + 2);
					return;
					break;
				default:
					inputstr += ki.KeyChar;
					break;
			}

		} while (ki.Key != ConsoleKey.Escape);
	}

	public static void SaveValue(int idx, string value)
	{
		if (!String.IsNullOrWhiteSpace(value))
			valVar[strVal[idx]] = value;
	}
	public enum Severity
	{
		Warning,
		Error
	}
	public static void FormatData(string message, Severity severity, Dictionary<string, string> data)
	{
		switch (severity)
		{
			case Severity.Warning:
				Console.BackgroundColor = ConsoleColor.Yellow;
				Console.ForegroundColor = ConsoleColor.Black;
				break;
			case Severity.Error:
				Console.BackgroundColor = ConsoleColor.Red;
				Console.ForegroundColor = ConsoleColor.White;
				break;
		}
		for (int i = 0; i < 50; i++)
		{
			Console.Write("-");
		}
		Console.WriteLine();
		Console.WriteLine(message);
		for (int i = 0; i < 50; i++)
		{
			Console.Write("-");
		}
		Console.WriteLine();
		foreach (string item in data.Keys)
		{
			Console.WriteLine($"{item} = {data[item]}");
		}
		Console.ResetColor();
	}
	private static void Main(string[] args)
	{
		Start();
		foreach (string val in valVar.Keys)
		{
			try
			{
				double tryPar = Double.Parse(valVar[val]);
				if (tryPar % 1 != 0)
				{
					throw new ValuesExseption();
				}
			}
			catch (ValuesExseption e)
			{
				FormatData($"Значение параметра {val} должно быть целочисленным", Severity.Warning, valVar);
			}
			catch
			{
				FormatData($"Неверный формат параметра {val}", Severity.Error, valVar);
			}
		}
			
			D(Double.Parse(valVar["a"]), Double.Parse(valVar["b"]), Double.Parse(valVar["c"]));
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

