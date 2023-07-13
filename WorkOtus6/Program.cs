internal partial class Program
{

	private static void Main(string[] args)
	{
		// программа 1

		// var planet = new { Name = "Venus", Order = 2, EquatorLength = 38026, Previous = (object)null };
		// planet = new { Name = "Earth", Order = 3, EquatorLength = 40075, Previous = (object)planet };
		// planet = new { Name = "Mars", Order = 4, EquatorLength = 21344, Previous = (object)planet };
		// planet = new { Name = "Venus", Order = 2, EquatorLength = 38026, Previous = (object)planet };

		// while (planet.Previous != null)
		// {
		// 	Console.WriteLine(
		// 				$"Name: {((dynamic)planet).Name}, Order: {((dynamic)planet).Order}," +
		// 				$"Equator Length: {((dynamic)planet).EquatorLength}," +
		// 				$"Previous: {(((dynamic)planet).Previous != null ? ((dynamic)planet).Previous.Name : "None")}," +
		// 				$"Equivalent to Venus: {((dynamic)planet).Name == "Venus" && ((dynamic)planet).Order == 2}"
		// 				);
		// 	planet = ((dynamic)planet).Previous;
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
		//Func<string, string> defValidator = (string planetName) => catalog.counter % 3 == 0 ? "Вы спрашиваете слишком часто" : "";

		Func<string, string> defValidator = (string planetName) => planetName == "Лимония" ? "Это запретная планета" : null;
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
