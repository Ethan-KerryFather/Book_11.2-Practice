using LinqPractice3.Data;
using LinqPractice3.Models;
using static System.Console;
using LinqPractice3.Models;
using Microsoft.EntityFrameworkCore;


// 연습 11.2 번
namespace LinqPractice3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                IEnumerable<Customer> customers = db.Customers;


                WriteLine("도시 목록");
                foreach (var customer in customers)
                {
                    Write($"{customer.City}\t");
                }

                Write("Enter the name of a city : ");
                string input = ReadLine();

                var findingQuery = customers
                    .Where(customer => customer.City.Contains(input))
                    .Select(customer => new { CustomerId = customer.CustomerId, CustomerName = customer.ContactName, CustomerAddress = customer.Address, CustomerCity = customer.City, });

                int count = 0;
                foreach(var customer in findingQuery)
                {
                    count++;
                    
                    WriteLine($"-----{count}-----");
                    WriteLine(customer.CustomerName);
                    WriteLine(customer.CustomerAddress);
                    WriteLine(customer.CustomerCity);
                    
                }

                
                
            }
        }
    }
}
