using System;
using System.ComponentModel;
using System.Linq;
using Common;
using static Common.Utils;
using static Common.MessageWrapper;

namespace LINQ_GroupingOperators
{
    
    [Message("This sample shows different uses of Grouping Operators")]
    internal static class GroupingOperators
    {
        private static void Main(string[] args)
        {
            ShowMessage(typeof(GroupingOperators));
            
            WrappedInvoke(Linq40_1);
            WrappedInvoke(Linq40_2);
            
            WrappedInvoke(Linq41_1);
            WrappedInvoke(Linq41_2);

            WrappedInvoke(Linq42_1);
            WrappedInvoke(Linq42_2);

            WrappedInvoke(Linq43_1);
            WrappedInvoke(Linq43_2);

            WrappedInvoke(Linq44);

            WrappedInvoke(Linq45);
        }
        
        [Message("This sample uses group by to partition a list of numbers by their remainder when divided by 5.")]
        private static void Linq40_1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numberGroups = from n in numbers
                group n by n % 5
                into g
                orderby g.Key
                select new { Remainder = g.Key, Numbers = g };

            foreach (var g in numberGroups)
            {
                Console.Write($"Numbers with a remainder of {g.Remainder} when divided by 5: ");
                foreach (var n in g.Numbers.OrderBy(n => n)) Console.Write($"{n} ");
                Console.Write('\n');
            }
        }
        
        [Message("This sample uses group by to partition a list of numbers by their remainder when divided by 5.")]
        private static void Linq40_2()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numberGroups = numbers.GroupBy(n => n % 5)
                .OrderBy(g => g.Key)
                .Select(g => new {Remainder = g.Key, Numbers = g});

            foreach (var g in numberGroups)
            {
                Console.Write($"Numbers with a remainder of {g.Remainder} when divided by 5: ");
                foreach (var n in g.Numbers.OrderBy(n => n)) Console.Write($"{n} ");
                Console.Write('\n');
            }
        }
        
        [Message("This sample uses group by to partition a list of words by their first letter.")]
        private static void Linq41_1()
        {
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

            var wordGroups = from w in words
                group w by w[0] 
                into g
                orderby g.Key
                select new {FirstLetter = g.Key, Words = g};
            
            foreach (var g in wordGroups) 
            { 
                Console.Write($"Words that start with the letter '{g.FirstLetter}': "); 
                foreach (var w in g.Words.OrderBy(w => w)) Console.Write($"{w}, ");
                Console.Write('\n');
            } 
        }
        
        [Message("This sample uses group by to partition a list of words by their first letter.")]
        private static void Linq41_2()
        {
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

            var wordGroups = words
                .GroupBy(w => w[0])
                .OrderBy(g => g.Key)
                .Select(g => new {FirstLetter = g.Key, Words = g});
            
            foreach (var g in wordGroups) 
            { 
                Console.Write($"Words that start with the letter '{g.FirstLetter}': "); 
                foreach (var w in g.Words.OrderBy(w => w)) Console.Write($"{w}, ");
                Console.Write('\n');
            } 
        }
        
        [Message("This sample uses group by to partition a list of products by category.")]
        private static void Linq42_1()
        {
            var products = GetProductList();

            var orderGroups = from p in products
                group p by p.Category
                into g
                orderby g.Key
                select new {Category = g.Key, Products = g};

            foreach (var g in orderGroups)
            {
                Console.WriteLine($"Group '{g.Category}'");
                foreach (var p in g.Products.OrderBy(p => p.ProductName))
                {
                    Console.WriteLine($"    Name: {p.ProductName}");
                }
            }
        }
        
        [Message("This sample uses group by to partition a list of products by category.")]
        private static void Linq42_2()
        {
            var products = GetProductList();

            var orderGroups = products.GroupBy(p => p.Category)
                .OrderBy(g => g.Key)
                .Select(g => new {Category = g.Key, Products = g});

            foreach (var g in orderGroups)
            {
                Console.WriteLine($"Group '{g.Category}'");
                foreach (var p in g.Products.OrderBy(p => p.ProductName))
                {
                    Console.WriteLine($"    Name: {p.ProductName}");
                }
            }
        }
        
        [Message("This sample uses group by to partition a list of each customer's orders, first by year, and then by month.")]
        private static void Linq43_1()
        {
            var customers = GetCustomerList();

            var customerOrderGroups = from c in customers
                select new
                {
                    c.CompanyName,
                    YearGroups = from o in c.Orders
                        group o by o.OrderDate.Year
                        into yg
                        orderby yg.Key
                        select new
                        {
                            Year = yg.Key,
                            MonthGroups = from o in yg
                                group o by o.OrderDate.Month
                                into mg
                                orderby mg.Key
                                select new {Month = mg.Key, Orders = mg}
                        }
                };

            foreach (var orderGroup in customerOrderGroups)
            {
                Console.WriteLine($"Orders for '{orderGroup.CompanyName}'");
                foreach (var yearGroup in orderGroup.YearGroups)
                {
                    Console.WriteLine($"  {yearGroup.Year} year:");
                    foreach (var monthGroup in yearGroup.MonthGroups)
                    {
                        Console.WriteLine($"    {monthGroup.Month} month:");
                        foreach (var o in monthGroup.Orders)
                        {
                            Console.WriteLine($"      OrderID: {o.OrderID}, OrderDate: {o.OrderDate}");
                        }
                    }
                }
            }
        }
        
        [Message("This sample uses group by to partition a list of each customer's orders, first by year, and then by month.")]
        private static void Linq43_2()
        {
            var customers = GetCustomerList();

            var customerOrderGroups = customers.Select(c => new
            {
                c.CompanyName,
                YearGroups = c.Orders.GroupBy(o => o.OrderDate.Year)
                    .OrderBy(yg => yg.Key)
                    .Select(yg => new
                    {
                        Year = yg.Key,
                        MonthGroups = yg.GroupBy(o => o.OrderDate.Month)
                            .OrderBy(mg => mg.Key)
                            .Select(mg => new { Month = mg.Key, Orders = mg })
                    })
            });
                
            foreach (var orderGroup in customerOrderGroups)
            {
                Console.WriteLine($"Orders for '{orderGroup.CompanyName}'");
                foreach (var yearGroup in orderGroup.YearGroups)
                {
                    Console.WriteLine($"  {yearGroup.Year} year:");
                    foreach (var monthGroup in yearGroup.MonthGroups)
                    {
                        Console.WriteLine($"    {monthGroup.Month} month:");
                        foreach (var o in monthGroup.Orders)
                        {
                            Console.WriteLine($"      OrderID: {o.OrderID}, OrderDate: {o.OrderDate}");
                        }
                    }
                }
            }
        }
        
        [Message("This sample uses GroupBy to partition trimmed elements of an array using a custom comparer that matches words that are anagrams of each other.")]
        private static void Linq44()
        {
            string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            var orderGroups = anagrams.Select(w => w.Trim())
                .GroupBy(w => w, new AnagramEqualityComparer());

            foreach (var g in orderGroups)
            {
                foreach (var v in g) Console.Write($"{v} ");
                Console.Write('\n');
            }
        }
        
        [Message("This sample uses GroupBy to partition trimmed elements of an array using a custom comparer that matches words that are anagrams of each other, and then converts the results to uppercase.")]
        private static void Linq45()
        {
            string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            var orderGroups = anagrams.Select(w => w.Trim())
                .GroupBy(w => w, w => w.ToUpper(), new AnagramEqualityComparer());
            
            foreach (var g in orderGroups)
            {
                foreach (var v in g) Console.Write($"{v} ");
                Console.Write('\n');
            }
        }
        
    }
}