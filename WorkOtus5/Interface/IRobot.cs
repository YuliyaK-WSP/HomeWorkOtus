public interface IRobot
{
	string GetInfo();
	List<string> GetComponents();
	string GetRobotType()
	{
		string val = "I am a simple robot.";
		return val;
	}
}
