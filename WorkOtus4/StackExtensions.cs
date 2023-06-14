
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

