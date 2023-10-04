using System.Data.Common;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using WorkOtus16Linq2dbDapper.Model;
using WorkOtus16Linq2dbDapper.Repo;
using Npgsql;

namespace WorkOtus16Linq2dbDapper
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Ado();
        }

        private static void Ado()
        {
            //var customers = Db.GetUsers();
            //customers.ForEach(Printcustomer);
			
			//var products = Db.GetProducts();

			//var order = Db.GetOrderById(1);
			//order.ForEach(PrintOrder);

			//var custmOrders = Db.GetOrderByCustomers(2);
			//custmOrders.ForEach(PrintOrder);
	

        }

        private static void Printcustomer(Customer customer)
        {
            Console.WriteLine($"{customer.Id} {customer.LastName} \t{customer.FirstName}");
        }
		private static void PrintProduct(Product product)
        {
            Console.WriteLine($"{product.Id} {product.Name} \t{product.Description} \t{product.StockQuantity} \t{product.Price}");
        }

        private static void PrintOrder(Order order)
        {
            Console.WriteLine($"{order.Id} \t{order.CustomerId} \t{order.ProductId} \t{order.Quantity}");
        }
    }

    public static class FLinq
    {
        public static void ForEach<T>(this IEnumerable<T> souse, Action<T> action)
        {
            foreach (var item in souse)
            {
                action(item);
            }
        }
    }

}
