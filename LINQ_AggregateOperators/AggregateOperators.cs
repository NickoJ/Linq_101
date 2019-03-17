using System;
using System.Linq;
using System.Text.RegularExpressions;
using Common;
using static Common.MessageWrapper;
using static Common.Utils;

namespace LINQ_AggregateOperators
{
    
    [Message("This sample shows different uses of Aggregate Operators")]
    internal static class AggregateOperators
    {
        private static void Main(string[] args)
        {
            ShowMessage(typeof(AggregateOperators));
            
            WrappedInvoke(Linq73);
            
            WrappedInvoke(Linq74);
            
//            WrappedInvoke(Linq75_1);
//            WrappedInvoke(Linq75_2);
            
            WrappedInvoke(Linq76_1);
            WrappedInvoke(Linq76_2);
            
            WrappedInvoke(Linq77_1);
            WrappedInvoke(Linq77_2);
            
            WrappedInvoke(Linq78);
            
            WrappedInvoke(Linq79);
            
            WrappedInvoke(Linq80_1);
            WrappedInvoke(Linq80_2);
            
            WrappedInvoke(Linq81);
            
            WrappedInvoke(Linq82);
            
            WrappedInvoke(Linq83_1);
            WrappedInvoke(Linq83_2);
            
            WrappedInvoke(Linq84_1);
            WrappedInvoke(Linq84_2);
            
            WrappedInvoke(Linq85);
            
            WrappedInvoke(Linq86);
            
            WrappedInvoke(Linq87_1);
            WrappedInvoke(Linq87_2);
            
            WrappedInvoke(Linq88_1);
            WrappedInvoke(Linq88_2);
            
            WrappedInvoke(Linq89);
            
            WrappedInvoke(Linq90);
            
            WrappedInvoke(Linq91_1);
            WrappedInvoke(Linq91_2);
            
            WrappedInvoke(Linq92);
            
            WrappedInvoke(Linq93);
        }

        [Message("This sample uses Count to get the number of unique factors of 300.")]
        private static void Linq73()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };

            int uniqueCount = factorsOf300.Distinct().Count();

            Console.WriteLine($"There are {uniqueCount} unique factors of 300.");
        }

        [Message("This sample uses Count to get the number of odd ints in the array.")]
        private static void Linq74()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int oddCount = numbers.Count(n => n % 2 == 1);

            Console.WriteLine($"There are {oddCount} odd numbers in the list.");
        }

        [Message("This sample uses Count to return a list of customers and how many orders each has.")]
        private static void Linq76_1()
        {
            var customers = GetCustomerList();

            var ordersCountByCustomerId = from c in customers
                select new { c.CustomerID, OrdersCount = c.Orders.Count(o => o.Total > 100.00M) };

            foreach (var c in ordersCountByCustomerId)
            {
                Console.WriteLine($"CustomerID: {c.CustomerID}, Orders count > 100.00M: {c.OrdersCount}");
            }
        }

        [Message("This sample uses Count to return a list of customers and how many orders each has.")]
        private static void Linq76_2()
        {
            var customers = GetCustomerList();

            var ordersCountByCustomerId = customers
                .Select(c => new { c.CustomerID, OrdersCount = c.Orders.Count(o => o.Total > 100.00M) });
            
            foreach (var c in ordersCountByCustomerId)
            {
                Console.WriteLine($"CustomerID: {c.CustomerID}, Orders count > 100.00M: {c.OrdersCount}");
            }
        }

        [Message("This sample uses Count to return a list of categories and how many products each has.")]
        private static void Linq77_1()
        {
            var products = GetProductList();

            var categoryCounts = from p in products
                group p by p.Category
                into g
                select new {Category = g.Key, ProductsCount = g.Count(p => p.UnitsInStock > 0)};

            foreach (var g in categoryCounts)
            {
                Console.WriteLine($"Category: {g.Category}, Products count with units > 0: {g.ProductsCount}");
            }
        }

        [Message("This sample uses Count to return a list of categories and how many products each has.")]
        private static void Linq77_2()
        {
            var products = GetProductList();

            var categoryCounts = products.GroupBy(p => p.Category)
                .Select(g => new {Category = g.Key, ProductsCount = g.Count(p => p.UnitsInStock > 0)});

            foreach (var g in categoryCounts)
            {
                Console.WriteLine($"Category: {g.Category}, Products count with units > 0: {g.ProductsCount}");
            }
        }

        [Message("This sample uses Sum to get the total of the numbers in an array.")]
        private static void Linq78()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int sum = numbers.Sum();
            
            Console.WriteLine($"The sum of the numbers is {sum}.");
        }

        [Message("This sample uses Sum to get the total number of characters of all words in the array.")]
        private static void Linq79()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            int totalChars = words.Sum(w => w.Length);
            
            Console.WriteLine($"There are a total of {totalChars} characters in these words."); 
        }

        [Message("This sample uses Sum to get the total units in stock for each product category.")]
        private static void Linq80_1()
        {
            var products = GetProductList();

            var categories = from p in products
                group p by p.Category
                into g
                select new { Category = g.Key, TotalUnitsInStock = g.Sum(p => p.UnitsInStock) };

            foreach (var g in categories)
            {
                Console.WriteLine($"Category: {g.Category}, Total units: {g.TotalUnitsInStock}");
            }
        }

        [Message("This sample uses Sum to get the total units in stock for each product category.")]
        private static void Linq80_2()
        {
            var products = GetProductList();

            var categories = products.GroupBy(p => p.Category)
                .Select(g => new {Category = g.Key, TotalUnitsInStock = g.Sum(p => p.UnitsInStock)});

            foreach (var g in categories)
            {
                Console.WriteLine($"Category: {g.Category}, Total units: {g.TotalUnitsInStock}");
            }
        }

        [Message("This sample uses Min to get the lowest number in an array.")]
        private static void Linq81()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int min = numbers.Min();

            Console.WriteLine($"The minimum number is {min}.");
        }

        [Message("This sample uses Min to get the length of the shortest word in an array.")]
        private static void Linq82()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            int shortestWord = words.Min(w => w.Length);

            Console.WriteLine($"The shortest word is {shortestWord} characters long.");
        }

        [Message("This sample uses Min to get the cheapest price among each category's products.")]
        private static void Linq83_1()
        {
            var products = GetProductList();

            var categories = from p in products
                group p by p.Category
                into g
                select new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) };

            foreach (var g in categories)
            {
                Console.WriteLine($"Category: {g.Category}, Cheapest price: {g.CheapestPrice}");
            }
        }

        [Message("This sample uses Min to get the cheapest price among each category's products.")]
        private static void Linq83_2()
        {
            var products = GetProductList();

            var categories = products.GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) });

            foreach (var g in categories)
            {
                Console.WriteLine($"Category: {g.Category}, Cheapest price: {g.CheapestPrice}");
            }
        }

        [Message("This sample uses Min to get the products with the cheapest price in each category.")]
        private static void Linq84_1()
        {
            var products = GetProductList();

            var categories = from p in products
                group p by p.Category
                into g
                let minPrice = g.Min(p => p.UnitPrice)
                select new { Category = g.Key, CheapestProducts = g.Where(p => p.UnitPrice == minPrice) };

            foreach (var g in categories)
            {
                Console.WriteLine($"Category: {g.Category}");
                foreach (var p in g.CheapestProducts)
                {
                    Console.WriteLine($"  ProductID: {p.ProductID}, Name: {p.ProductName}, Price: {p.UnitPrice}");
                }
            }
        }

        [Message("This sample uses Min to get the products with the cheapest price in each category.")]
        private static void Linq84_2()
        {
            var products = GetProductList();

            var categories = products.GroupBy(p => p.Category)
                .Select(g =>
                {
                    var minPrice = g.Min(p => p.UnitPrice);
                    return new { Category = g.Key, CheapestProducts = g.Where(p => p.UnitPrice == minPrice) };
                });
            
            foreach (var g in categories)
            {
                Console.WriteLine($"Category: {g.Category}");
                foreach (var p in g.CheapestProducts)
                {
                    Console.WriteLine($"  ProductID: {p.ProductID}, Name: {p.ProductName}, Price: {p.UnitPrice}");
                }
            }
        }

        [Message("This sample uses Max to get the highest number in an array.")]
        private static void Linq85()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int max = numbers.Max();

            Console.WriteLine($"The maximum number is {max}.");
        }

        [Message("This sample uses Max to get the length of the longest word in an array.")]
        private static void Linq86()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            int longestLength = words.Max(w => w.Length);
            
            Console.WriteLine($"The longest word is {longestLength} characters long."); 
        }

        [Message("This sample uses Max to get the most expensive price among each category's products.")]
        private static void Linq87_1()
        {
            var products = GetProductList();

            var categories = from p in products
                group p by p.Category
                into g
                select new { Category = g.Key, MostExpensivePrice = g.Max(p => p.UnitPrice) };

            foreach (var g in categories) Console.WriteLine($"Category: {g.Category}, Most expensive price: {g.MostExpensivePrice}");
        }

        [Message("This sample uses Max to get the most expensive price among each category's products.")]
        private static void Linq87_2()
        {
            var products = GetProductList();

            var categories = products.GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, MostExpensivePrice = g.Max(p => p.UnitPrice) });

            foreach (var g in categories) Console.WriteLine($"Category: {g.Category}, Most expensive price: {g.MostExpensivePrice}");
        }

        [Message("This sample uses Max to get the products with the most expensive price in each category.")]
        private static void Linq88_1()
        {
            var products = GetProductList();

            var categories = from p in products
                group p by p.Category
                into g
                let maxPrice = g.Max(p => p.UnitPrice)
                select new { Category = g.Key, MostExpensiveProducts = g.Where(p => p.UnitPrice == maxPrice) };

            foreach (var g in categories)
            {
                Console.WriteLine($"Category: {g.Category}");
                foreach (var p in g.MostExpensiveProducts)
                {
                    Console.WriteLine($"  ProductID: {p.ProductID}, Name: {p.ProductName}, Price: {p.UnitPrice}");                    
                }
            }
        }

        [Message("This sample uses Max to get the products with the most expensive price in each category.")]
        private static void Linq88_2()
        {
            var products = GetProductList();

            var categories = products.GroupBy(p => p.Category)
                .Select(g =>
                {
                    var maxPrice = g.Max(p => p.UnitPrice);
                    return new {Category = g.Key, MostExpensiveProducts = g.Where(p => p.UnitPrice == maxPrice)};
                });
            
            foreach (var g in categories)
            {
                Console.WriteLine($"Category: {g.Category}");
                foreach (var p in g.MostExpensiveProducts)
                {
                    Console.WriteLine($"  ProductID: {p.ProductID}, Name: {p.ProductName}, Price: {p.UnitPrice}");                    
                }
            }
        }

        [Message("This sample uses Average to get the average of all numbers in an array.")]
        private static void Linq89()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            double average = numbers.Average();
            
            Console.WriteLine($"The average number is {average}."); 
        }

        [Message("This sample uses Average to get the average length of the words in the array.")]
        private static void Linq90()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            double averageLength = words.Average(w => w.Length);

            Console.WriteLine($"The average word length is {averageLength} characters.");
        }

        [Message("This sample uses Average to get the average price of each category's products.")]
        private static void Linq91_1()
        {
            var products = GetProductList();

            var categories = from p in products
                group p by p.Category
                into g
                select new { Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice) };

            foreach (var g in categories) Console.WriteLine($"Category: {g.Category}, Average price: {g.AveragePrice}");
        }

        [Message("This sample uses Average to get the average price of each category's products.")]
        private static void Linq91_2()
        {
            var products = GetProductList();

            var categories = products.GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice) });

            foreach (var g in categories) Console.WriteLine($"Category: {g.Category}, Average price: {g.AveragePrice}");
        }

        [Message("This sample uses Aggregate to create a running product on the array that calculates the total product of all elements.")]
        private static void Linq92()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            double product = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);
            
            Console.WriteLine($"Total product of all numbers: {product}"); 
        }

        [Message("This sample uses Aggregate to create a running account balance that subtracts each withdrawal from the initial balance of 100, as long as the balance never drops below 0.")]
        private static void Linq93()
        {
            double startBalance = 100.0;
            
            int[] attemptedWithdrawals = { 20, 10, 40, 50, 10, 70, 30 };

            double endBalance = attemptedWithdrawals.Aggregate(startBalance,
                (balance, nextWithdrawal) => (balance >= nextWithdrawal) ? balance - nextWithdrawal : balance);
            
            Console.WriteLine($"Ending balance: {endBalance}");
        }

    }
}