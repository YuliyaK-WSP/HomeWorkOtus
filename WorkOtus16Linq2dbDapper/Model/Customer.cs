using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOtus16Linq2dbDapper.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
