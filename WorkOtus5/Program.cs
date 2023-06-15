internal partial class Program
{
	private static void Main(string[] args)
	{
		IFlyingRobot r = new Quadcopter();
			var type = r.GetRobotType();
			Console.WriteLine(type);
		// IRobot ir = new Quadcopter();
		// var components = ir.GetComponents();
		// Console.WriteLine(components);
	}
}
