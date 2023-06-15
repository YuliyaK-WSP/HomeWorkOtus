using System.Threading;
class Quadcopter : IFlyingRobot, IChargeable
{
	List<string> _components = new List<string> { "rotor1", "rotor2", "rotor3", "rotor4" };
	List<string> IRobot.GetComponents()
	{
		foreach(var _component in _components)
		{
			Console.WriteLine(_component);
		}
		return _components;
	}
	string IRobot.GetInfo()
	{
		throw new NotImplementedException();
	}
	void IChargeable.Charge()
	{
		Console.WriteLine("Charging...");
		Thread.Sleep(3000);
		Console.WriteLine("Charged!");
	}
	string IChargeable.GetInfo()
	{
		return "IChargeable.GetInfo";
	}
}