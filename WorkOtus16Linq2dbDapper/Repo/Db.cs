using System;
using WorkOtus16Linq2dbDapper.Model;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOtus16Linq2dbDapper.Repo
{
    public class Db
    {
        public static List<Customer> GetUsers()
        {
            var customer = new List<Customer>();
            using (var conn = new NpgsqlConnection(Config.SqlConnectionString))
            {
                string sql = @"select id,firstname,lastname,age from customers";
                conn.Open();
                using (var command = new NpgsqlCommand(sql, conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        customer.Add(
                            new Customer()
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                FirstName = reader["firstname"].ToString(),
                                LastName = reader["lastname"].ToString(),
                                Age = Convert.ToInt32(reader["age"].ToString())
                            }
                        );
                    }
                }
            }
            return customer;
        }

        public static List<Product> GetProducts()
        {
            var products = new List<Product>();
            using (var conn = new NpgsqlConnection(Config.SqlConnectionString))
            {
                string sql = @"select id, name, description, stockquantity, price from products";
                conn.Open();
                using (var command = new NpgsqlCommand(sql, conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(
                            new Product()
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["name"].ToString(),
                                Description = reader["description"].ToString(),
                                StockQuantity = Convert.ToInt32(reader["stockquantity"].ToString()),
                                Price = Convert.ToDecimal(reader["price"].ToString())
                            }
                        );
                    }
                }
            }
            return products;
        }

        /// <summary>
        /// Метод позволяет вывести информацию об объекте по конкрестному Id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>orders</returns>
        public static List<Order> GetOrderById(int orderId)
        {
            var orders = new List<Order>();
            using (var conn = new NpgsqlConnection(Config.SqlConnectionString))
            {
                string sql = @"select id, customerid, productid, quantity from orders where id = @OrderId";
                conn.Open();
                using (var command = new NpgsqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        orders.Add(
                            new Order()
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                CustomerId = Convert.ToInt32(reader["customerid"].ToString()),
                                ProductId = Convert.ToInt32(reader["productid"].ToString()),
                                Quantity = Convert.ToInt32(reader["quantity"].ToString())
                            }
                        );
                    }
                }
            }
            return orders;
        }
		/// <summary>
        /// Метод позволяет вывести информацию о заказах по конкретному покупателю
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns>orders</returns>
		public static List<Order> GetOrderByCustomers(int customerid)
        {
            var orders = new List<Order>();
            using (var conn = new NpgsqlConnection(Config.SqlConnectionString))
            {
                string sql = @"select id, customerid, productid, quantity from orders where customerid = @Customerid";
                conn.Open();
                using (var command = new NpgsqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@Customerid", customerid);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        orders.Add(
                            new Order()
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                CustomerId = Convert.ToInt32(reader["customerid"].ToString()),
                                ProductId = Convert.ToInt32(reader["productid"].ToString()),
                                Quantity = Convert.ToInt32(reader["quantity"].ToString())
                            }
                        );
                    }
                }
            }
            return orders;
        }

        public static List<Order> GetOrders()
        {
            var orders = new List<Order>();
            using (var conn = new NpgsqlConnection(Config.SqlConnectionString))
            {
                string sql = @"select id, customerid, productid, quantity from orders";
                conn.Open();
                using (var command = new NpgsqlCommand(sql, conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        orders.Add(
                            new Order()
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                CustomerId = Convert.ToInt32(reader["customerid"].ToString()),
                                ProductId = Convert.ToInt32(reader["productid"].ToString()),
                                Quantity = Convert.ToInt32(reader["quantity"].ToString())
                            }
                        );
                    }
                }
            }
            return orders;
        }
    }
}