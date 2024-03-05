using EF_BikeStore.Data;
using EF_BikeStore.Models;
using Microsoft.Extensions.Configuration;

namespace EF_BikeStore
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            ApplicationDbContext context = new ApplicationDbContext();


            // 1- Retrieve all categories from the production.categories table.
            var categories = context.Categories.ToList();
            foreach (var category in categories)
            {
                Console.WriteLine(category.CategoryName);
            }

            Console.WriteLine("******************************");

            // 2- Retrieve the first product from the production.products table.
            var product1 = context.Products.FirstOrDefault();
            Console.WriteLine($"{product1.ProductId}, {product1.ProductName}");

            Console.WriteLine("******************************");

            // 3- Retrieve a specific product from the production.products table by ID
            var prodById = context.Products.Find(3);
            Console.WriteLine(prodById.ProductName);

            Console.WriteLine("******************************");

            // 4- Retrieve all products from production.products with a certain model year
            var porductsOf2019 = context.Products.Where(p => p.ModelYear == 2019).ToList();
            foreach (var product in porductsOf2019)
            {
                Console.WriteLine($"{product.ProductName}");
            }

            Console.WriteLine("******************************");

            // 5- Retrieve a specific customer from the sales.customers table by ID.
            var customer = context.Customers.SingleOrDefault(c => c.CustomerId == 18);
            Console.WriteLine($"{customer.CustomerId}, {customer.FirstName}");

            Console.WriteLine("******************************");

            // 6- Retrieve a list of product names and their corresponding brand names
            var products = context.Products.Select(e => new { e.ProductName, e.Brand.BrandName }).ToList();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.ProductName}, {item.BrandName}");
            }
            
            Console.WriteLine("******************************");

            // 7- Count the number of products in a specific category.
            var prodsInCategs = context.Products.Count(p => p.CategoryId == 1);
            // var prodsInCategs = context.Products.Count(e => e.Category.CategoryId == 1);
            Console.WriteLine(prodsInCategs);
            
            Console.WriteLine("******************************");

            // 8- Calculate the total list price of all products in a specific category.
            var totalListPrice = context.Products.Where(p => p.CategoryId == 2).Sum(p => p.ListPrice);
            Console.WriteLine(totalListPrice);

            Console.WriteLine("******************************");
            
            // 9- Calculate the average list price of products.
            var avgPrice = context.Products.Average(p => p.ListPrice);
            Console.WriteLine(avgPrice);

            Console.WriteLine("******************************");
            
            // 10- Retrieve orders that are completed.
            var ordersCompleted = context.Orders.Where(o => o.OrderStatus == 4).ToList();
        }
    }
}
