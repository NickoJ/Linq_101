using System;
using System.Linq;
using Common;

using static Common.MessageWrapper;
using static Common.Utils;

namespace LINQ_PartitioningOperators
{
    
    [Message("This sample shows different uses of Partitioning Operators")]
    internal static class PartitioningOperators
    {
        
        private static void Main(string[] args)
        {
            ShowMessage(typeof(PartitioningOperators));
            
            WrappedInvoke(Linq20);
            
            WrappedInvoke(Linq21_1);
            WrappedInvoke(Linq21_2);

            WrappedInvoke(Linq22);

            WrappedInvoke(Linq23_1);
            WrappedInvoke(Linq23_2);

            WrappedInvoke(Linq24);

            WrappedInvoke(Linq25);

            WrappedInvoke(Linq26);

            WrappedInvoke(Linq27);
        }
        
        [Message("This sample uses Take to get only the first 3 elements of the array.")]
        private static void Linq20()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var first3Numbers = numbers.Take(3);
            
            Console.Write("First 3 numbers: ");
            foreach (var n in first3Numbers) Console.Write($"{n} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Take to get the first 3 orders from customers in Washington.")]
        private static void Linq21_1()
        {
            var customers = GetCustomerList();

            var firstWAOrders = (from c in customers
                    where "WA".Equals(c.Region)
                    from o in c.Orders
                    select new {c.CustomerID, o.OrderID, o.OrderDate})
                .Take(3);
            
            Console.WriteLine("First 3 orders in WA:");
            foreach (var order in firstWAOrders)
            {
                Console.WriteLine($"CustomerID: {order.CustomerID}, OrderID: {order.OrderID}, Order date: {order.OrderDate}");
            }
        }
        
        [Message("This sample uses Take to get the first 3 orders from customers in Washington.")]
        private static void Linq21_2()
        {
            var customers = GetCustomerList();

            var firstWAOrders = customers.Where(c => "WA".Equals(c.Region))
                .SelectMany(c => c.Orders, (c, o) => new {c.CustomerID, o.OrderID, o.OrderDate})
                .Take(3);
            
            Console.WriteLine("First 3 orders in WA:");
            foreach (var order in firstWAOrders)
            {
                Console.WriteLine($"CustomerID: {order.CustomerID}, OrderID: {order.OrderID}, Order date: {order.OrderDate}");
            }
        }
        
        [Message("This sample uses Skip to get all but the first 4 elements of the array.")]
        private static void Linq22()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var allButFirst4Numbers = numbers.Skip(4);
            
            Console.Write("All but first 4 numbers: "); 
            foreach (var n in allButFirst4Numbers) Console.Write($"{n} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Take to get all but the first 2 orders from customers in Washington.")]
        private static void Linq23_1()
        {
            var customers = GetCustomerList();

            var allButFirst2Orders = (from c in customers
                    where "WA".Equals(c.Region)
                    from o in c.Orders
                    select new { c.CustomerID, o.OrderID, o.OrderDate })
                .Skip(2);
            
            Console.WriteLine("All but first 2 orders in WA:");
            foreach (var order in allButFirst2Orders)
            {
                Console.WriteLine($"CustomerID: {order.CustomerID}, OrderID: {order.OrderID}, Order date: {order.OrderDate}");
            }
        }
        
        [Message("This sample uses Take to get all but the first 2 orders from customers in Washington.")]
        private static void Linq23_2()
        {
            var customers = GetCustomerList();

            var allButFirst2Orders = customers.Where(c => "WA".Equals(c.Region))
                .SelectMany(c => c.Orders, (c, o) => new { c.CustomerID, o.OrderID, o.OrderDate })
                .Skip(2);
            
            Console.WriteLine("All but first 2 orders in WA:");
            foreach (var order in allButFirst2Orders)
            {
                Console.WriteLine($"CustomerID: {order.CustomerID}, OrderID: {order.OrderID}, Order date: {order.OrderDate}");
            }
        }
        
        [Message("This sample uses TakeWhile to return elements starting from the beginning of the array until a number is hit that is not less than 6.")]
        private static void Linq24()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);
            
            Console.Write("First numbers less than 6: "); 
            foreach (var n in firstNumbersLessThan6) Console.Write($"{n} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses TakeWhile to return elements starting from the beginning of the array until a number is hit that is less than its position in the array.")]
        private static void Linq25()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);
            
            Console.Write("First numbers not less than their position: "); 
            foreach (var n in firstSmallNumbers) Console.Write($"{n} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses SkipWhile to get the elements of the array starting from the first element divisible by 3.")]
        private static void Linq26()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var allButFirst3Numbers = numbers.SkipWhile(n => n % 3 != 0);
            
            Console.Write("All elements starting from first element divisible by 3: "); 
            foreach (var n in allButFirst3Numbers) Console.Write($"{n} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses SkipWhile to get the elements of the array starting from the first element less than its position.")]
        private static void Linq27()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var laterNumbers = numbers.SkipWhile((n, index) => n >= index);
            
            Console.Write("All elements starting from first element less than its position: "); 
            foreach (var n in laterNumbers) Console.Write($"{n} ");
            Console.Write('\n');
        }
        
    }
    
}