using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOtus12HouseJack
{
    public class Part9
    {
        public List<string> Poem { get; private set; }

        public List<string> AddPart(List<string> previousPart)
        {
            Poem = new List<string>(previousPart);
            Poem.Add("Большой-пребольшой вёдрушкой");
            return Poem;
        }
    }
}
