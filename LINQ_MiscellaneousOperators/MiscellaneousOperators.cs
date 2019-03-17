using System;
using System.Linq;
using Common;
using static Common.MessageWrapper;
using static Common.Utils;

namespace LINQ_MiscellaneousOperators
{
    
    [Message("This sample shows different uses of Miscellaneous Operators")]
    internal static class MiscellaneousOperators
    {
        private static void Main(string[] args)
        {
            ShowMessage(typeof(MiscellaneousOperators));
            
            WrappedInvoke(Linq94);
        
            WrappedInvoke(Linq95_1);
            WrappedInvoke(Linq95_2);
        
            WrappedInvoke(Linq96);
        
            WrappedInvoke(Linq97);
        }
        
        [Message("This sample uses Concat to create one sequence that contains each array's values, one after the other.")]
        private static void Linq94()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; 
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var allNumbers = numbersA.Concat(numbersB);
            
            Console.Write("All numbers from both arrays: ");
            foreach (var n in allNumbers) Console.Write($" {n}");
            Console.Write('\n');
        }
        
        [Message("This sample uses Concat to create one sequence that contains the names of all customers and products, including any duplicates.")]
        private static void Linq95_1()
        {
            var customers = GetCustomerList();
            var products = GetProductList();

            var customerNames = from c in customers
                select c.CompanyName;
            var productNames = from p in products
                select p.ProductName;

            var allNames = customerNames.Concat(productNames);
            
            Console.WriteLine("Customer and product names:");
            foreach (var name in allNames) Console.WriteLine($"  {name}");
        }
        
        [Message("This sample uses Concat to create one sequence that contains the names of all customers and products, including any duplicates.")]
        private static void Linq95_2()
        {
            var customers = GetCustomerList();
            var products = GetProductList();

            var allNames = customers.Select(c => c.CompanyName)
                .Concat(products.Select(p => p.ProductName));
            
            Console.WriteLine("Customer and product names:");
            foreach (var name in allNames) Console.WriteLine($"  {name}");
        }
        
        [Message("This sample uses EqualAll to see if two sequences match on all elements in the same order.")]
        private static void Linq96()
        {
            var wordsA = new string[] { "cherry", "apple", "blueberry" }; 
            var wordsB = new string[] { "cherry", "apple", "blueberry" };

            bool match = wordsA.SequenceEqual(wordsB);
            
            Console.WriteLine($"The sequences match: {match}"); 
        }
        
        [Message("This sample uses EqualAll to see if two sequences match on all elements in the same order.")]
        private static void Linq97()
        {
            var wordsA = new string[] { "cherry", "apple", "blueberry" }; 
            var wordsB = new string[] { "apple", "blueberry", "cherry" };

            bool match = wordsA.SequenceEqual(wordsB);
            
            Console.WriteLine($"The sequences match: {match}");
        }
        
    }
}