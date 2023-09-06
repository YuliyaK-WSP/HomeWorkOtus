using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WorkOtus12
{
    public class Shop
    {
        public ObservableCollection<Item> Items { get; set; }

        public Shop()
        {
            Items = new ObservableCollection<Item>();
            
        }

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Remove(Item item)
        {
            Items.Remove(item);
        }
    }
}
