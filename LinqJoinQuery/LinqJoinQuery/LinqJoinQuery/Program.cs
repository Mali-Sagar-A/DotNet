using System.Xml.Linq;
using LinqJoinQuery.Model;

namespace LinqJoinQuery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shopping Application");
            

            var Invoice = from Customer in GetAllCustomers()
                          join
                          Order in GetAllOrders()
                          on Customer.CustomerId equals Order.CustomerId
                          join
                          Product in GetAllProducts()
                          on Order.ProductId equals Product.ProductId
                          where Customer.CustomerId == 101
                          select new
                          {
                              CustomerId = Customer.CustomerId,
                              CustomerName = Customer.CustomerName,
                              City = Customer.City,
                              OrderId = Order.OrderId,
                              DeliveryDate = Order.RequiredDate,
                              ProductName = Product.ProductName,
                              UnitPrice = Product.UnitPrice,
                              Quantity = Order.Quantity,
                              TotalPrice = Order.Quantity * Product.UnitPrice,
                          };
            foreach (var invoice in Invoice)
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine($"| { invoice.CustomerId} | {invoice.CustomerName} | {invoice.City} | {invoice.OrderId} | {invoice.DeliveryDate} | {invoice.ProductName} | {invoice.UnitPrice} | {invoice.Quantity} | {invoice.TotalPrice}/- |" );
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
            }



        }



        private static List<Customer> GetAllCustomers()
        {
            var customers = from Customer in XElement.Load(@"C:\Users\user\Desktop\ExamDotNet\LinqJoinQuery\LinqJoinQuery\Customer.xml").Elements()
                            select new Customer()
                            {
                                CustomerId = int.Parse(Customer.Attribute("CustomerId").Value),
                                CustomerName = Customer.Attribute("CustomerName").Value,
                                City = Customer.Attribute("City").Value
                            };
            return customers.ToList();
        }

        private static List<Product> GetAllProducts()
        {
            return new List<Product>(){
                new Product() { ProductId = 1, ProductName = "bag", UnitPrice = 650.21 },
                new Product() { ProductId = 2, ProductName = "pen", UnitPrice = 50.21 },
                new Product() { ProductId = 3, ProductName = "Book", UnitPrice = 1080.21 },
                new Product() { ProductId = 4, ProductName = "Botal", UnitPrice = 350.21 },

                };

        }

        private static List<Order> GetAllOrders()
        {
            return new List<Order>() {

                new Order{CustomerId = 101,OrderId=1001,ProductId = 1,OrderDate=DateTime.Now,RequiredDate=DateTime.Now.AddDays(2),Quantity=100},
                new Order{CustomerId = 101,OrderId=1002,ProductId = 3,OrderDate=DateTime.Now,RequiredDate=DateTime.Now.AddDays(3),Quantity=10},
                new Order{CustomerId = 102,OrderId=1003,ProductId = 4,OrderDate=DateTime.Now,RequiredDate=DateTime.Now.AddDays(2),Quantity=50},
                new Order{CustomerId = 103,OrderId=1004,ProductId = 5,OrderDate=DateTime.Now,RequiredDate=DateTime.Now.AddDays(4),Quantity=1000},
                new Order{CustomerId = 104,OrderId=1005,ProductId = 2,OrderDate=DateTime.Now,RequiredDate=DateTime.Now.AddDays(2),Quantity=100},

            };
        }






    }

   
}
