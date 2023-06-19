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

