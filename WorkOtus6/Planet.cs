internal class Planet
{
	public string Name{get;set;}
	public int Order{get;set;}
	public double EquatorLength{get;set;}
	public Planet Previous{get;set;}

	public Planet(string name,int order, double equatorLength,Planet previous = null)
	{
		Name = name;
		Order = order;
		EquatorLength = equatorLength;
		Previous = previous;
	}
}
