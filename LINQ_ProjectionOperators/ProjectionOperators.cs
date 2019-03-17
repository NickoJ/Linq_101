using System;
using System.Linq;
using Common;

using static Common.Utils;
using static Common.MessageWrapper;

namespace LINQ_ProjectionOperators
{
    
    [Message("This sample shows different uses of Projection Operators")]
    internal static class ProjectionOperators
    {
        private static void Main(string[] args)
        {
            ShowMessage(typeof(ProjectionOperators));
            
            WrappedInvoke(Linq6_1);
            WrappedInvoke(Linq6_2);
            
            WrappedInvoke(Linq7_1);
            WrappedInvoke(Linq7_2);
            
            WrappedInvoke(Linq8_1);
            WrappedInvoke(Linq8_2);
            
            WrappedInvoke(Linq9_1);
            WrappedInvoke(Linq9_2);
            
            WrappedInvoke(Linq10_1);
            WrappedInvoke(Linq10_2);
            
            WrappedInvoke(Linq11_1);
            WrappedInvoke(Linq11_2);
            
            WrappedInvoke(Linq12);
            
            WrappedInvoke(Linq13_1);
            WrappedInvoke(Linq13_2);
            
            WrappedInvoke(Linq14_1);
            WrappedInvoke(Linq14_2);
            
            WrappedInvoke(Linq15_1);
            WrappedInvoke(Linq15_2);
            
            WrappedInvoke(Linq16_1);
            WrappedInvoke(Linq16_2);
            
            WrappedInvoke(Linq17_1);
            WrappedInvoke(Linq17_2);
            
            WrappedInvoke(Linq18_1);
            WrappedInvoke(Linq18_2);
            
            WrappedInvoke(Linq19);
        }

        [Message("This sample uses select to produce a sequence of ints one higher than those in an existing array of ints (Query expression.")]
        private static void Linq6_1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numPlusOne = from n in numbers
                select n + 1;
            
            Console.WriteLine("Numbers + 1");
            foreach (var n in numPlusOne)
            {
                Console.Write($"{n} ");
            }
            Console.Write('\n');
        }

        [Message("This sample uses select to produce a sequence of ints one higher than those in an existing array of ints (Dot notation.")]
        private static void Linq6_2()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            var numPlusOne = numbers.Select(n => n + 1);
            foreach (var n in numPlusOne)
            {
                Console.Write($"{n} ");
            }
            Console.Write('\n');
        }

        [Message("This sample uses select to return a sequence of just the names of a list of products. (Query expressions)")]
        private static void Linq7_1()
        {
            var products = GetProductList();

            var productNames = from p in products
                select p.ProductName;
            
            Console.WriteLine("Product names: ");
            foreach (var name in productNames) Console.WriteLine(name);
        }

        [Message("This sample uses select to return a sequence of just the names of a list of products. (Dot notation)")]
        private static void Linq7_2()
        {
            var products = GetProductList();

            var productNames = products.Select(p => p.ProductName);
            
            Console.WriteLine("Product names: ");
            foreach (var name in productNames) Console.WriteLine(name);
        }

        private static void Linq8_1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var textNums = from n in numbers
                select strings[n];
            
            Console.WriteLine("Number strings:");
            foreach (var s in textNums) Console.Write($"{s} ");
            Console.Write('\n');
        }

        private static void Linq8_2()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var textNums = numbers.Select(n => strings[n]);
            
            Console.WriteLine("Number strings:");
            foreach (var s in textNums) Console.Write($"{s} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses select to produce a sequence of the uppercase and lowercase versions of each word in the original array.")]
        private static void Linq9_1()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = from w in words
                select new { Upper = w.ToUpper(), Lower = w.ToLower() }; 

            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");   
            }
        }
        
        [Message("This sample uses select to produce a sequence of the uppercase and lowercase versions of each word in the original array.")]
        private static void Linq9_2()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower()});

            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
            }
        }
        
        [Message("This sample uses select to produce a sequence containing text representations of digits and whether their length is even or odd.")]
        private static void Linq10_1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digitOddEvens = from n in numbers
                select new {Digit = strings[n], Even = (n % 2 == 0)};

            foreach (var d in digitOddEvens)
            {
                Console.WriteLine($"The digit {d.Digit} is {(d.Even ? "even" : "odd")}");
            }
        }
        
        [Message("This sample uses select to produce a sequence containing text representations of digits and whether their length is even or odd.")]
        private static void Linq10_2()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digitOddEvens = numbers.Select(n => new {Digit = strings[n], Even = (n % 2 == 0)});

            foreach (var d in digitOddEvens)
            {
                Console.WriteLine($"The digit {d.Digit} is {(d.Even ? "even" : "odd")}");
            }
        }
        
        [Message("This sample uses select to produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.")]
        private static void Linq11_1()
        {
            var products = GetProductList();

            var productInfos = from p in products
                select new { p.ProductName, p.Category, Price = p.UnitPrice };
            
            Console.WriteLine("Product Info:");
            foreach (var info in productInfos)
            {
                Console.WriteLine($"{info.ProductName} is in category {info.Category} and costs {info.Price} per unit.");
            }
        }
        
        [Message("This sample uses select to produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.")]
        private static void Linq11_2()
        {
            var products = GetProductList();

            var productInfos = products.Select(p => new {p.ProductName, p.Category, Price = p.UnitPrice}); 
            
            Console.WriteLine("Product Info:");
            foreach (var info in productInfos)
            {
                Console.WriteLine($"{info.ProductName} is in category {info.Category} and costs {info.Price} per unit.");
            }
        }
        
        [Message("This sample uses an indexed Select clause to determine if the value of ints in an array match their position in the array.")]
        private static void Linq12()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsInPlace = numbers.Select((num, index) => new {Num = num, InPlace = num == index});
            Console.WriteLine("Number: In-place?");
            foreach (var n in numsInPlace)
            {
                Console.WriteLine($"{n.Num}: {n.InPlace}");
            }
        }
        
        [Message("This sample combines select and where to make a simple query that returns the text form of each digit less than 5.")]
        private static void Linq13_1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var lowNums = from n in numbers
                where n < 5
                select digits[n];
            
            Console.Write("Numbers < 5: ");
            foreach (var num in lowNums) Console.Write($"{num} ");
            Console.Write('\n');
        }
        
        [Message("This sample combines select and where to make a simple query that returns the text form of each digit less than 5.")]
        private static void Linq13_2()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var lowNums = numbers.Where(n => n < 5).Select(n => digits[n]);
            
            Console.Write("Numbers < 5: ");
            foreach (var num in lowNums) Console.Write($"{num} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses a compound from clause to make a query that returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.")]
        private static void Linq14_1()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; 
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs = from a in numbersA
                from b in numbersB
                where a < b
                select (a, b);
            
            Console.WriteLine("Pairs where a < b:"); 
            foreach (var (a, b) in pairs) 
            { 
                Console.WriteLine($"{a} is less than {b}"); 
            } 
        }
        
        [Message("This sample uses a compound from clause to make a query that returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.")]
        private static void Linq14_2()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; 
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs = numbersA.SelectMany(a => numbersB, (a, b) => (a: a, b: b)).Where(p => p.a < p.b);
            
            Console.WriteLine("Pairs where a < b:"); 
            foreach (var (a, b) in pairs) 
            { 
                Console.WriteLine($"{a} is less than {b}"); 
            }
        }
        
        [Message("This sample uses a compound from clause to select all orders where the order total is less than 500.00.")]
        private static void Linq15_1()
        {
            var customers = GetCustomerList();
            var orders = from c in customers
                from o in c.Orders
                where o.Total < 500.00M
                select new {c.CustomerID, o.OrderID, o.Total};

            foreach (var o in orders)
            {
                Console.WriteLine($"CustomerId: {o.CustomerID}");
                Console.WriteLine($"  OrderId: {o.OrderID}, Total: {o.Total}");
            }
        }
        
        [Message("This sample uses a compound from clause to select all orders where the order total is less than 500.00.")]
        private static void Linq15_2()
        {
            var customers = GetCustomerList();
            var orders = customers.SelectMany(c => c.Orders.Where(o => o.Total < 500.00M),
                    (c, o) => new { c.CustomerID, o.OrderID, o.Total });

            foreach (var o in orders)
            {
                Console.WriteLine($"CustomerId: {o.CustomerID}");
                Console.WriteLine($"  OrderId: {o.OrderID}, Total: {o.Total}");
            }
        }
        
        [Message("This sample uses a compound from clause to select all orders where the order was made in 1998 or later.")]
        private static void Linq16_1()
        {
            var customers = GetCustomerList();

            var orders = from c in customers
                from o in c.Orders
                where o.OrderDate >= new DateTime(1998, 1, 1)
                select new {c.CustomerID, o.OrderID, o.OrderDate};

            foreach (var o in orders)
            {
                Console.WriteLine($"CustomerId: {o.CustomerID}");
                Console.WriteLine($"  OrderId: {o.OrderID}, Order date: {o.OrderDate}");
            }
        }
        
        [Message("This sample uses a compound from clause to select all orders where the order was made in 1998 or later.")]
        private static void Linq16_2()
        {
            var customers = GetCustomerList();

            var orders = customers
                .SelectMany(c => c.Orders.Where(o => o.OrderDate > new DateTime(1998, 1, 1)),
                    (c, o) => new { c.CustomerID, o.OrderID, o.OrderDate });
            
            foreach (var o in orders)
            {
                Console.WriteLine($"CustomerId: {o.CustomerID}");
                Console.WriteLine($"  OrderId: {o.OrderID}, Order date: {o.OrderDate}");
            }
        }
        
        [Message("This sample uses a compound from clause to select all orders where the order total is greater than 2000.00 and uses from assignment to avoid requesting the total twice.")]
        private static void Linq17_1()
        {
            var customers = GetCustomerList();

            var orders = from c in customers
                from o in c.Orders
                where o.Total >= 2000.00M
                select new { c.CustomerID, o.OrderID, o.Total };

            foreach (var o in orders)
            {
                Console.WriteLine($"CustomerId: {o.CustomerID}");
                Console.WriteLine($"  OrderId: {o.OrderID}, Total: {o.Total}");
            }
        }
        
        [Message("This sample uses a compound from clause to select all orders where the order total is greater than 2000.00 and uses from assignment to avoid requesting the total twice.")]
        private static void Linq17_2()
        {
            var customers = GetCustomerList();

            var orders = customers.SelectMany(c => c.Orders.Where(o => o.Total >= 2000.00M),
                (c, o) => new { c.CustomerID, o.OrderID, o.Total });

            foreach (var o in orders)
            {
                Console.WriteLine($"CustomerId: {o.CustomerID}");
                Console.WriteLine($"  OrderId: {o.OrderID}, Total: {o.Total}");
            }
        }
        
        [Message("This sample uses multiple from clauses so that filtering on customers can be done before selecting their orders. This makes the query more efficient by not selecting and then discarding orders for customers outside of Washington.")]
        private static void Linq18_1()
        {
            var customers = GetCustomerList(); 
            var cutoffDate = new DateTime(1997, 1, 1);

            var orders = from c in customers
                where "WA".Equals(c.Region)
                from o in c.Orders
                select new {c.CustomerID, o.OrderID};

            foreach (var o in orders)
            {
                Console.WriteLine($"CustomerId: {o.CustomerID}, OrderId: {o.OrderID}");
            }
        }
        
        [Message("This sample uses multiple from clauses so that filtering on customers can be done before selecting their orders. This makes the query more efficient by not selecting and then discarding orders for customers outside of Washington.")]
        private static void Linq18_2()
        {
            var customers = GetCustomerList(); 
            var cutoffDate = new DateTime(1997, 1, 1);

            var orders = customers.Where(c => "WA".Equals(c.Region))
                .SelectMany(c => c.Orders, (c, o) => new { c.CustomerID, o.OrderID });
                
            foreach (var o in orders)
            {
                Console.WriteLine($"CustomerId: {o.CustomerID}, OrderId: {o.OrderID}");
            }
        }
        
        [Message("This sample uses an indexed SelectMany clause to select all orders, while referring to customers by the order in which they are returned from the query.")]
        private static void Linq19()
        {
            var customers = GetCustomerList();

            var orders = customers.SelectMany(
                (customer, index) => customer.Orders.Select(o => $"Customer #{(index + 1)} has an order with OrderID {o.OrderID}"));

            foreach (var order in orders) Console.WriteLine(order);
        }
        
    }
    
}