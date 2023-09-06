using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WorkOtus12
{
    public class Customer
    {
        public void OnItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Item item in e.NewItems)
                {
                    Console.WriteLine($" Добавлен товар: {item.Name} (ID: {item.Id})");
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Item item in e.OldItems)
                {
                    Console.WriteLine($" Удален товар: {item.Name} (ID: {item.Id})");
                }
            }
        }
    }
}
