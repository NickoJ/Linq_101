using System;
using System.Linq;
using Common;
using static Common.MessageWrapper;
using static Common.Utils;

namespace LINQ_ElementOperators
{
    
    [Message("This sample shows different uses of Element Operators")]
    internal static class ElementOperators
    {
        private static void Main(string[] args)
        {
            ShowMessage(typeof(ElementOperators));
            
            WrappedInvoke(Linq58_1);
            WrappedInvoke(Linq58_2);
        
            WrappedInvoke(Linq59_1);
            WrappedInvoke(Linq59_2);
        
//            WrappedInvoke(Linq60_1);
//            WrappedInvoke(Linq60_2);
        
            WrappedInvoke(Linq61);
        
            WrappedInvoke(Linq62);
        
//            WrappedInvoke(Linq63_1);
//            WrappedInvoke(Linq63_2);
        
            WrappedInvoke(Linq64_1);
            WrappedInvoke(Linq64_2);
        }
        
        [Message("This sample uses First to return the first matching element as a Product, instead of as a sequence containing a Product.")]
        private static void Linq58_1()
        {
            var products = GetProductList();

            var p12 = (from p in products
                    where p.ProductID == 12
                    select p)
                .First();
            
            Console.WriteLine($"ProductID: {p12.ProductID}, Product name: {p12.ProductName}.");
        }
        
        [Message("This sample uses First to return the first matching element as a Product, instead of as a sequence containing a Product.")]
        private static void Linq58_2()
        {
            var products = GetProductList();

            var p12 = products.First(p => p.ProductID == 12);
            
            Console.WriteLine($"ProductID: {p12.ProductID}, Product name: {p12.ProductName}.");
        }
        
        [Message("This sample uses First to find the first element in the array that starts with 'o'.")]
        private static void Linq59_1()
        {
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var startsWithO = (from s in strings
                    where s[0] == 'o'
                    select s)
                .First();
            
            Console.WriteLine($"A string starting with 'o': {startsWithO}"); 
        }
        
        [Message("This sample uses First to find the first element in the array that starts with 'o'.")]
        private static void Linq59_2()
        {
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var startsWithO = strings.First(s => s[0] == 'o');
            
            Console.WriteLine($"A string starting with 'o': {startsWithO}"); 
        }
        
        [Message("This sample uses FirstOrDefault to try to return the first element of the sequence, unless there are no elements, in which case the default value for that type is returned.")]
        private static void Linq61()
        {
            int[] numbers = { };
            
            var firstNumOrDefault = numbers.FirstOrDefault();
            Console.WriteLine(firstNumOrDefault);
        }
        
        [Message("This sample uses FirstOrDefault to return the first product whose ProductID is 789 as a single Product object, unless there is no match, in which case null is returned.")]
        private static void Linq62()
        {
            var products = GetProductList();

            var p789 = products.FirstOrDefault(p => p.ProductID == 789);
            
            Console.WriteLine($"Product 789 exists: {p789 != null}");
        }
        
        [Message("This sample uses ElementAt to retrieve the second number greater than 5 from an array.")]
        private static void Linq64_1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            
            var fourthLowNum = (from n in numbers
                where n > 5
                select n)
                .ElementAt(1);
                
            Console.WriteLine($"Second number > 5: {fourthLowNum}");
        }
        
        [Message("This sample uses ElementAt to retrieve the second number greater than 5 from an array.")]
        private static void Linq64_2()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            
            var fourthLowNum = numbers.Where(n => n > 5).ElementAt(1);
                
            Console.WriteLine($"Second number > 5: {fourthLowNum}");
        }
        
    }
}