using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOtusSOLID.Interface;

namespace WorkOtusSOLID
{
    public class UserInput : IUserInput
    {
        public int GetNumberUser()
		{
			return Convert.ToInt32(Console.ReadLine());
		}
		
    }
}