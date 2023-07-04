internal class PlanetsCatalog
{
	public List<Planet> planets { get; }
	 public int counter;

    public PlanetsCatalog()
    {
        planets = new List<Planet>
        {
            new Planet("Венера", 2, 3760.4),
            new Planet("Земля", 3, 40075),
            new Planet("Марс", 4, 21340)
        };
		counter = 0;
    }
	public (int,double,string,Planet) GetPlanet(string planetName)
	{
		//string Name = planetName;
		counter++;
		
		if (counter % 3 == 0)
        {
            return (0, 0, "Вы спрашиваете слишком часто", null);
        }

		Planet planet = planets.FirstOrDefault(p => p.Name == planetName);

		if(planet == null)
		{
			return (0 , 0, "Не удалось найти планету",null);
		}

		return (planet.Order, planet.EquatorLength, planet.Name, planet);
	}

	public (int,double,string,Planet) GetPlanet(string planetName,Func<string,string> planetValidator)
	{
		counter++;
		string error = planetValidator(planetName);

		if(!string.IsNullOrEmpty(error))
		{
			return (0, 0, error, null);
		}

		Planet planet = planets.FirstOrDefault(p => p.Name == planetName);

		if(planet == null)
		{
			return (0 , 0, "Не удалось найти планету",null);
		}

        
		return (planet.Order, planet.EquatorLength, planet.Name, planet);
	}
	
	
}  