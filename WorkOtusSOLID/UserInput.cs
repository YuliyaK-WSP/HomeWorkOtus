using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOtusSOLID
{
    public class UserInput : IUserInput
    {
        public GetNumberUser()
		{
			return Convert.ToInt32(Console.ReadLine());
		}
    }
}