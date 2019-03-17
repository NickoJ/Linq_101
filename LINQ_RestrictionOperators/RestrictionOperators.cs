using System;
using System.Linq;
using Common;

using static Common.Utils;
using static Common.MessageWrapper;

namespace LINQ_RestrictionOperators
{
    
    [Message("This sample shows different uses of Restriction Operators.")]
    internal static class RestrictionOperators
    {
        
        private static void Main(string[] args)
        {
            ShowMessage(typeof(RestrictionOperators));
            
            WrappedInvoke(Linq1_1);
            WrappedInvoke(Linq1_1);
            WrappedInvoke(Linq1_2);
            
            WrappedInvoke(Linq2_1);
            WrappedInvoke(Linq2_2);
            
            WrappedInvoke(Linq3_1);
            WrappedInvoke(Linq3_2);
            
            WrappedInvoke(Linq4_1);
            WrappedInvoke(Linq4_2);

            WrappedInvoke(Linq5);
        }

        [Message("This sample uses where to find all elements of an array less than 5 (Query expression).")]
        private static void Linq1_1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNums = from n in numbers
                where n < 5
                select n;

            foreach (var x in lowNums) Console.Write($"{x} ");
            Console.Write('\n');
        }

        [Message("This sample uses where to find all elements of an array less than 5 (Dot notation).")]
        private static void Linq1_2()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            var lowNums = numbers.Where(n => n < 5);

            foreach (var x in lowNums) Console.Write($"{x} ");
            Console.Write('\n');
        }

        [Message("This sample uses where to find all products that are out of stock (Query expression).")]
        private static void Linq2_1()
        {
            var products = GetProductList();

            var soldOutProducts = from p in products
                where p.UnitsInStock == 0
                select p;
            
            Console.WriteLine("Sold out products:");
            foreach (var product in soldOutProducts)
            {
                Console.WriteLine($"{product.ProductName} is sold out!");
            }
        }

        [Message("This sample uses where to find all products that are out of stock (Dot notation).")]
        private static void Linq2_2()
        {
            var products = GetProductList();

            var soldOutProducts = products.Where(p => p.UnitsInStock == 0);
            
            Console.WriteLine("Sold out products:");
            foreach (var product in soldOutProducts)
            {
                Console.WriteLine($"{product.ProductName} is sold out!");
            }
        }

        [Message("This sample uses where to find all products that are in stock and cost more than 3.00 per unit (Query expression).")]
        private static void Linq3_1()
        {
            var products = GetProductList();

            var expensiveInStockProducts = from p in products
                where p.UnitsInStock > 0 && p.UnitPrice > 3.00M
                select p;
            
            Console.WriteLine("In-stock products that cost more than 3.00:");
            foreach (var product in expensiveInStockProducts)
            {
                Console.WriteLine($"{product.ProductName} is in stock and costs {product.UnitPrice}");
            }
        }
        
        [Message("This sample uses where to find all products that are in stock and cost more than 3.00 per unit (Dot notation).")]
        private static void Linq3_2()
        {
            var products = GetProductList();

            var expensiveInStockProducts = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);
            
            Console.WriteLine("In-stock products that cost more than 3.00:");
            foreach (var product in expensiveInStockProducts)
            {
                Console.WriteLine($"{product.ProductName} is in stock and costs {product.UnitPrice}");
            }
        }

        [Message("This sample uses where to find all customers in Washington and then uses the resulting sequence to drill down into their orders (Query expression).")]
        private static void Linq4_1()
        {
            var customers = GetCustomerList();

            var waCustomers = from c in customers
                where "WA".Equals(c.Region)
                select c;

            foreach (var customer in waCustomers)
            {
                Console.WriteLine($"Customer {customer.CustomerID}: {customer.CompanyName}");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"  Order {order.OrderID}: {order.OrderDate}");
                }
            }
        }

        [Message("This sample uses where to find all customers in Washington and then uses the resulting sequence to drill down into their orders (Dot notation).")]
        private static void Linq4_2()
        {
            var customers = GetCustomerList();

            var waCustomers = customers.Where(c => "WA".Equals(c.Region));

            foreach (var customer in waCustomers)
            {
                Console.WriteLine($"Customer {customer.CustomerID}: {customer.CompanyName}");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"  Order {order.OrderID}: {order.OrderDate}");
                }
            }
        }
      
        [Message("This sample demonstrates an indexed Where clause that returns digits whose name is shorter than their value.")]
        private static void Linq5()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortDigits = digits.Where(((digit, index) => digit.Length < index));
            
            Console.WriteLine("Short digits:");
            foreach (var digit in shortDigits)
            {
                Console.WriteLine($"The word {digit} is shorter than its value");
            }
        }

    }
}