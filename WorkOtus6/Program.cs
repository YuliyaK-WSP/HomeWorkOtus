internal partial class Program
{
	
	private static void Main(string[] args)
	{
		// программа 1

		// var venus = new { Name = "Venus", Order = 2, EquatorLength = 38026, Previous = (object)null };
		// var earth = new { Name = "Earth", Order = 3, EquatorLength = 40075, Previous = venus };
		// var mars = new { Name = "Mars", Order = 4, EquatorLength = 21344, Previous = earth };
		// var venus2 = new { Name = "Venus", Order = 2, EquatorLength = 38026, Previous = mars };


		// object[] planets = new object[]
		// {
		// 	Tuple.Create(venus.Name, venus.Order, venus.EquatorLength, venus.Previous),
		// 	Tuple.Create(earth.Name, earth.Order, earth.EquatorLength, earth.Previous),
		// 	Tuple.Create(mars.Name, mars.Order, mars.EquatorLength, mars.Previous),
		// 	Tuple.Create(venus2.Name, venus2.Order, venus2.EquatorLength, venus2.Previous)
		// };
		// foreach (var planet in planets)
		// {
		// 	Console.WriteLine(
		// 					$"Name: {((dynamic)planet).Item1}, Order: {((dynamic)planet).Item2}," +
		// 					 $"Equator Length: {((dynamic)planet).Item3}," +
		// 					 $"Previous: {(((dynamic)planet).Item4 != null ? ((dynamic)planet).Item4.Name : "None")}," +
		// 					 $"Equivalent to Venus: {((dynamic)planet).Item1 == "Venus" && ((dynamic)planet).Item2 == 2}"
		// 					);
		// }


		/// программа 2 
		
		// PlanetsCatalog catalog = new PlanetsCatalog();

		// Console.WriteLine("Поиск планет:");
		// PrintPlanet(catalog, "Земля");
		// PrintPlanet(catalog, "Лимония");
		// PrintPlanet(catalog, "Марс");

		// программа 3
		PlanetsCatalog catalog = new PlanetsCatalog();
		Console.WriteLine("Поиск планет:");
		PrintPlanetDelegate(catalog, "Земля");
		PrintPlanetDelegate(catalog, "Лимония");
		PrintPlanetDelegate(catalog, "Марс");

	}
	public static void PrintPlanet(PlanetsCatalog catalog, string Name)
	{
		var result = catalog.GetPlanet(Name);
		if (result.Item3 == "")
		{
			Console.WriteLine(result.Item3);
		}
		else
		{
			Console.WriteLine($"Название планеты: {result.Item3}");
			Console.WriteLine($"Порядковый номер от Солнца: {result.Item1}");
			Console.WriteLine($"Экватор: {result.Item2}");
		}
	
	}
	// программа 3
	public static void PrintPlanetDelegate(PlanetsCatalog catalog, string Name)
	{
		Func<string, string> defValidator = (string planetName) => catalog.counter % 3 == 0 ? "Вы спрашиваете слишком часто" : "";
		var result = catalog.GetPlanet(Name, defValidator);
		if (result.Item3 == "")
		{
			Console.WriteLine(result.Item3);
		}
		else
		{
			Console.WriteLine($"Название планеты: {result.Item3}");
			Console.WriteLine($"Порядковый номер от Солнца: {result.Item1}");
			Console.WriteLine($"Экватор: {result.Item2}");
		}
	
	}
}
