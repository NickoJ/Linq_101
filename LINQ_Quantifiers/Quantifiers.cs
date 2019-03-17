using System;
using System.Linq;
using Common;
using static Common.MessageWrapper;
using static Common.Utils;

namespace LINQ_Quantifiers
{
    
    [Message("This sample shows different uses of Quantifiers")]
    internal static class Quantifiers
    {
        private static void Main(string[] args)
        {
            ShowMessage(typeof(Quantifiers));
            
            WrappedInvoke(Linq67);
            
//            WrappedInvoke(Linq68_1);
//            WrappedInvoke(Linq68_2);
            
            WrappedInvoke(Linq69_1);
            WrappedInvoke(Linq69_2);
            
            WrappedInvoke(Linq70);
            
//            WrappedInvoke(Linq71_1);
//            WrappedInvoke(Linq71_2);
            
            WrappedInvoke(Linq72_1);
            WrappedInvoke(Linq72_2);
        }
        
        [Message("This sample uses Any to determine if any of the words in the array contain the substring 'ei'.")]
        private static void Linq67()
        {
            string[] words = { "believe", "relief", "receipt", "field" };
            
            var iAfterE = words.Any(w => w.Contains("ei"));
            
            Console.WriteLine($"There is a word that contains in the list that contains 'ei': {iAfterE}");  
        }
        
        [Message("This sample uses Any to return a grouped a list of products only for categories that have at least one product that is out of stock.")]
        private static void Linq69_1()
        {
            var products = GetProductList();

            var productGroup = from p in products
                group p by p.Category
                into g
                where g.Any(p => p.UnitsInStock == 0)
                select new { Category = g.Key, Products = g };

            foreach (var g in productGroup)
            {
                Console.WriteLine($"Category: {g.Category}");
                foreach (var p in g.Products) Console.WriteLine($"  ProductID: {p.ProductID}, Product name: {p.ProductName}, in stock: {p.UnitsInStock}");
            }
        }
        
        [Message("This sample uses Any to return a grouped a list of products only for categories that have at least one product that is out of stock.")]
        private static void Linq69_2()
        {
            var products = GetProductList();

            var productGroup = products.GroupBy(p => p.Category)
                .Where(g => g.Any(p => p.UnitsInStock == 0))
                .Select(g => new { Category = g.Key, Products = g });
            
            foreach (var g in productGroup)
            {
                Console.WriteLine($"Category: {g.Category}");
                foreach (var p in g.Products) Console.WriteLine($"  ProductID: {p.ProductID}, Product name: {p.ProductName}, in stock: {p.UnitsInStock}");
            }
        }
        
        [Message("This sample uses All to determine whether an array contains only odd numbers.")]
        private static void Linq70()
        {
            int[] numbers = { 1, 11, 3, 19, 41, 65, 19 };

            bool onlyOdd = numbers.All(n => n % 2 == 1);
            
            Console.WriteLine($"The list contains only the odd numbers: {onlyOdd}");
        }
        
        [Message("This sample uses All to return a grouped a list of products only for categories that have all of their products in stock.")]
        private static void Linq72_1()
        {
            var products = GetProductList();

            var productGroup = from p in products
                group p by p.Category
                into g
                where g.All(p => p.UnitsInStock > 0)
                select new { Category = g.Key, Products = g };
            
            foreach (var g in productGroup)
            {
                Console.WriteLine($"Category: {g.Category}");
                foreach (var p in g.Products) Console.WriteLine($"  ProductID: {p.ProductID}, Product name: {p.ProductName}, in stock: {p.UnitsInStock}");
            }
        }
        
        [Message("This sample uses All to return a grouped a list of products only for categories that have all of their products in stock.")]
        private static void Linq72_2()
        {
            var products = GetProductList();

            var productGroup = products.GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock > 0))
                .Select(g => new {Category = g.Key, Products = g});

            foreach (var g in productGroup)
            {
                Console.WriteLine($"Category: {g.Category}");
                foreach (var p in g.Products) Console.WriteLine($"  ProductID: {p.ProductID}, Product name: {p.ProductName}, in stock: {p.UnitsInStock}");
            }
        }
        
    }
}