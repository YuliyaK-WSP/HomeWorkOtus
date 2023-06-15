public interface IFlyingRobot : IRobot
{
	string GetRobotType()
	{
		string val = "I am a flying robot.";
		return val;
	}
}
