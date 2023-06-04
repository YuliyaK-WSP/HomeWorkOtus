using System;
using System.Runtime.InteropServices;

public class Program
{
	static string plus = "+";
	public static void Main()
	{
		Print();
	}
	public static void Print()
	{
		string n;
		int val;
		string text;
		int maxLngsText = 40;

		do
		{
			Console.WriteLine("введите размерность таблицы:");

			n = (Console.ReadLine());
			if (!int.TryParse(n, out val))
			{
				Console.WriteLine("Вы ввели не корректное значение");
				continue;
			}
			else if (val < 1 || val > 6)
			{
				Console.WriteLine("Значение должно быть от 1 до 6");
			}
		}
		while (!(val >= 1 && val <= 6));

		do
		{
			Console.WriteLine("введите произвольный текст:");
			text = Console.ReadLine();
			if (text.Length > (maxLngsText - val))
			{
				Console.WriteLine($"Текст не может быть длиннее {maxLngsText - val}");
			}
			else if (string.IsNullOrWhiteSpace(text))
			{
				Console.WriteLine($"Текст состоит только из пробелов");
			}
			else
			{
				Str(val, text);
				Console.ReadKey();
			}
		}
		while (true);
	}
	public static void Str(int n, string text)
	{
		int strLength = text.Length + (n * 2);

		OneStr(strLength);
		int strHight = 1 + ((n - 1) * 2);

		for (int i = 0; i < strHight; i++)
		{
			if (i == strHight / 2)
			{
				Console.WriteLine((plus.PadRight(n) + text).PadRight(strLength - 1) + plus);
			}
			else
			{
				Console.WriteLine(plus.PadRight(strLength - 1) + plus);
			}
		}
		OneStr(strLength);
		for (int i = 0; i < strHight; i++)
		{
			if (i % 2 == 0)
			{
				StrPlusTrim(strLength, true);
			}
			else
			{
				StrPlusTrim(strLength, false);
			}
		}
		OneStr(strLength);
		StrX(strLength);
	}

	public static void StrPlusTrim(int strLength, bool even)
	{
		Console.Write(plus);
		for (int i = 0; i < strLength - 2; i++)
		{
			if (even == true)
			{
				Console.Write(" ");
			}
			else
			{
				Console.Write(plus);
			}
			even = !even;
		}
		Console.Write(plus);
		Console.WriteLine();
	}

	public static void StrX(int strLength)
	{
		for (int i = 0; i < strLength; i++)
		{
			char[] strArray = (plus.PadRight(strLength - 1) + plus).ToCharArray();
			strArray[i] = '+';
			strArray[strLength - (i + 1)] = '+';
			Console.WriteLine(new string(strArray));
		}
		OneStr(strLength);
	}

	public static void OneStr(int strLength)
	{
		for (int i = 0; i < strLength; i++)
		{
			Console.Write("+");
		}
		Console.WriteLine();
	}
}
