using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common;
using static Common.Utils;
using static Common.MessageWrapper;

namespace LINQ_OrderingOperators
{
    
    [Message("This sample shows different uses of Ordering Operators")]
    internal static class OrderingOperators
    {
        private static void Main(string[] args)
        {
            ShowMessage(typeof(OrderingOperators));
            
            WrappedInvoke(Linq28_1);
            WrappedInvoke(Linq28_2);
            
            WrappedInvoke(Linq29_1);
            WrappedInvoke(Linq29_2);
            
            WrappedInvoke(Linq30_1);
            WrappedInvoke(Linq30_2);
            
            WrappedInvoke(Linq31);
            
            WrappedInvoke(Linq32_1);
            WrappedInvoke(Linq32_2);
            
            WrappedInvoke(Linq33_1);
            WrappedInvoke(Linq33_2);
            
            WrappedInvoke(Linq34);
            
            WrappedInvoke(Linq35_1);
            WrappedInvoke(Linq35_2);
            
            WrappedInvoke(Linq36);
            
            WrappedInvoke(Linq37_1);
            WrappedInvoke(Linq37_2);
            
            WrappedInvoke(Linq38);
            
            WrappedInvoke(Linq39_1);
            WrappedInvoke(Linq39_2);
        }
        
        [Message("This sample uses orderby to sort a list of words alphabetically.")]
        private static void Linq28_1()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords = from w in words
                orderby w
                select w;
            
            Console.Write("The sorted list of words: "); 
            foreach (var w in sortedWords) Console.Write($"{w} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses orderby to sort a list of words alphabetically.")]
        private static void Linq28_2()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords = words.OrderBy(w => w);
            
            Console.Write("The sorted list of words: "); 
            foreach (var w in sortedWords) Console.Write($"{w} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses orderby to sort a list of words by length.")]
        private static void Linq29_1()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords = from w in words
                orderby w.Length
                select w;
            
            Console.Write("The sorted list of words (by length): "); 
            foreach (var w in sortedWords) Console.Write($"{w} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses orderby to sort a list of words by length.")]
        private static void Linq29_2()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords = words.OrderBy(w => w.Length);
            
            Console.Write("The sorted list of words (by length): "); 
            foreach (var w in sortedWords) Console.Write($"{w} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses orderby to sort a list of products by name.")]
        private static void Linq30_1()
        {
            var products = GetProductList();

            var sortedProducts = from p in products
                orderby p.ProductName
                select p;

            foreach (var p in sortedProducts)
            {
                Console.WriteLine($"ProductID: {p.ProductID}, Product name: {p.ProductName}");
            }
        }
        
        [Message("This sample uses orderby to sort a list of products by name.")]
        private static void Linq30_2()
        {
            var products = GetProductList();

            var sortedProducts = products.OrderBy(p => p.ProductName);
            
            foreach (var p in sortedProducts)
            {
                Console.WriteLine($"ProductID: {p.ProductID}, Product name: {p.ProductName}");
            }
        }
        
        [Message("This sample uses an OrderBy clause with a custom comparer to do a case-insensitive sort of the words in an array.")]
        private static void Linq31()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words.OrderBy(w => w, new CaseSensitiveComparer());

            foreach (var w in sortedWords) Console.Write($"{w} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses orderby and descending to sort a list of doubles from highest to lowest.")]
        private static void Linq32_1()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            var sortedDoubles = from d in doubles
                orderby d descending
                select d;
            
            Console.WriteLine("The doubles from highest to lowest: "); 
            foreach (var d in sortedDoubles) Console.Write($"{d} "); 
            Console.Write('\n');
        }
        
        [Message("This sample uses orderby and descending to sort a list of doubles from highest to lowest.")]
        private static void Linq32_2()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            var sortedDoubles = doubles.OrderByDescending(d => d);
            
            Console.WriteLine("The doubles from highest to lowest: "); 
            foreach (var d in sortedDoubles) Console.Write($"{d} "); 
            Console.Write('\n');
        }
        
        [Message("This sample uses orderby to sort a list of products by units in stock from highest to lowest.")]
        private static void Linq33_1()
        {
            var products = GetProductList();

            var sortedProducts = from p in products
                orderby p.UnitsInStock descending
                select p;

            foreach (var p in sortedProducts)
            {
                Console.WriteLine($"Product name: {p.ProductName}, in stock: {p.UnitsInStock}");   
            }
        }
        
        [Message("This sample uses orderby to sort a list of products by units in stock from highest to lowest.")]
        private static void Linq33_2()
        {
            var products = GetProductList();

            var sortedProducts = products.OrderByDescending(p => p.UnitsInStock);
            foreach (var p in sortedProducts)
            {
                Console.WriteLine($"Product name: {p.ProductName}, in stock: {p.UnitsInStock}");   
            }
        }
                
        [Message("This sample uses an OrderBy clause with a custom comparer to do a case-insensitive descending sort of the words in an array.")]
        private static void Linq34()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words.OrderByDescending(w => w, new CaseSensitiveComparer());
            foreach (var w in sortedWords) Console.Write($"{w} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses a compound orderby to sort a list of digits, first by length of their name, and then alphabetically by the name itself.")]
        private static void Linq35_1()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sortedDigits = from d in digits
                orderby d.Length, d
                select d;
            
            Console.Write("Sorted digits: "); 
            foreach (var d in sortedDigits) Console.Write($"{d} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses a compound orderby to sort a list of digits, first by length of their name, and then alphabetically by the name itself.")]
        private static void Linq35_2()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sortedDigits = digits.OrderBy(d => d.Length).ThenBy(d => d);
            
            Console.Write("Sorted digits: "); 
            foreach (var d in sortedDigits) Console.Write($"{d} ");
            Console.Write('\n');
        }
                
        [Message("This sample uses an OrderBy and a ThenBy clause with a custom comparer to sort first by word length and then by a case-insensitive sort of the words in an array.")]
        private static void Linq36()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words.OrderBy(a => a.Length).ThenBy(a => a, new CaseSensitiveComparer());

            foreach (var w in sortedWords) Console.Write($"{w} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses a compound orderby to sort a list of products, first by category, and then by unit price, from highest to lowest.")]
        private static void Linq37_1()
        {
            var products = GetProductList();

            var sortedProducts = from p in products
                orderby p.Category, p.UnitPrice descending
                select p;

            foreach (var p in sortedProducts) Console.WriteLine($"Name: {p.ProductName}, Category: {p.Category}, Price: {p.UnitPrice}");
        }
        
        [Message("This sample uses a compound orderby to sort a list of products, first by category, and then by unit price, from highest to lowest.")]
        private static void Linq37_2()
        {
            var products = GetProductList();

            var sortedProducts = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            foreach (var p in sortedProducts) Console.WriteLine($"Name: {p.ProductName}, Category: {p.Category}, Price: {p.UnitPrice}");
        }
                
        [Message("This sample uses an OrderBy and a ThenBy clause with a custom comparer to sort first by word length and then by a case-insensitive descending sort of the words in an array.")]
        private static void Linq38()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words.OrderBy(w => w.Length).ThenBy(w => w, new CaseSensitiveComparer());

            foreach (var w in sortedWords) Console.Write($"{w} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Reverse to create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.")]
        private static void Linq39_1()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var reversedIDigits = (from d in digits
                    where d[1] == 'i'
                    select d)
                .Reverse();

            foreach (var d in reversedIDigits) Console.Write($"{d} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Reverse to create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.")]
        private static void Linq39_2()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var reversedIDigits = digits.Where(d => d[1] == 'i').Reverse();

            foreach (var d in reversedIDigits) Console.Write($"{d} ");
            Console.Write('\n');
        }
        
    }
}