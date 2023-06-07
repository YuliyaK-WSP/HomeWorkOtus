class Program
{
	private static void Main(string[] args)
	{
		var s = new Stack("a", "b", "c");
		//size = 3, Top = 'c'
		Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
		var deleted = s.Pop();
		// Извлек верхний элемент 'c' Size = 2
		Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");
		s.Add("d");
		// size = 3, Top = 'd'
		Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
		s.Pop();
		s.Pop();
		s.Pop();
		// size = 0, Top = null
		Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
		s.Pop();
		//var s = new Stack("a", "b", "c");
		//s.Merge(new Stack("1", "2", "3"));
		// в стеке s теперь элементы - "a", "b", "c", "3", "2", "1" <- верхний
		//Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
		//var s = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
		//Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
	}
}
class Stack
{
	class StackItem
	{
		public string value;
    	public StackItem prevItem;

		public StackItem()
		{
			value = null;
			prevItem = null;
		}
		public StackItem(string val, StackItem prev)
		{
			value = val;
			prevItem = prev;
		}

	}
	StackItem stki = new StackItem();
	//List<string> dictionarystr = new List<string>();
	public int Size { get; set; } = 0;
	public string Top { get; set; } = null;
	public void Add(string elem)
	{
		
		//Реализация под List
		//dictionarystr.Add(elem);

		//Реализация под StackItem
		stki = new StackItem(elem,stki);
		
		Size++;
		Top = elem;
	}
	public string Pop()
	{
		if (Size == 0)
			throw new Exception("Стек пустой");
		stki = stki.prevItem;
		//dictionarystr.RemoveAt(Size - 1);
		Size--;
		string retTopValue = Top;
		if (Size > 0)
			//Top = dictionarystr[Size - 1];
			Top = stki.value;
		else
			Top = null;
		return retTopValue;
	}
	public Stack(params string[] par)
	{
		for (int i = 0; i < par.Length; i++)
		{
			Add(par[i]);
		}
	}
	//Дополнительное задание 2 
	public static Stack Concat(params Stack[] stk)
	{
		Stack stackMain = new Stack();
		for (int i = 0; i < stk.Length; i++)
		{
			stackMain.Merge(stk[i]);
		}
		return stackMain;
	}

}
// Дополнительное задание 1
static class StackExtensions
{
	/// <summary>
	/// Метод предназначен для перегрузки данных в обратном порядке из одного стека в другой 
	/// </summary>
	/// <param name="count">Количество</param>
	/// <returns></returns>	
	public static void Merge(this Stack s1, Stack s2)
	{
		while (s2.Size != 0)
		{
			s1.Add(s2.Pop());
		}
	}
}

