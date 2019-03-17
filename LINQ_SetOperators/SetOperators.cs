using System;
using System.Linq;
using Common;
using static Common.Utils;
using static Common.MessageWrapper;

namespace LINQ_SetOperators
{
    
    [Message("This sample shows different uses of Set Operators.")]
    internal static class SetOperators
    {
        
        private static void Main(string[] args)
        {
            ShowMessage(typeof(SetOperators));
            
            WrappedInvoke(Linq46);
            
            WrappedInvoke(Linq47_1);
            WrappedInvoke(Linq47_2);
            
            WrappedInvoke(Linq48);
            
            WrappedInvoke(Linq49_1);
            WrappedInvoke(Linq49_2);
            
            WrappedInvoke(Linq50);
            
            WrappedInvoke(Linq51_1);
            WrappedInvoke(Linq51_2);
            
            WrappedInvoke(Linq52);
            
            WrappedInvoke(Linq53_1);
            WrappedInvoke(Linq53_2);
        }
        
        [Message("This sample uses Distinct to remove duplicate elements in a sequence of factors of 300.")]
        private static void Linq46()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };

            var uniqueFactors = factorsOf300.Distinct();
            
            Console.Write("Prime factors of 300: "); 
            foreach (var f in uniqueFactors) Console.Write($"{f} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Distinct to find the unique Category names.")]
        private static void Linq47_1()
        {
            var products = GetProductList();

            var categoryNames = (from p in products
                    select p.Category)
                .Distinct();
            
            Console.Write("Category names: "); 
            foreach (var n in categoryNames) Console.Write($"{n} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Distinct to find the unique Category names.")]
        private static void Linq47_2()
        {
            var products = GetProductList();

            var categoryNames = products.Select(p => p.Category).Distinct();
            
            Console.Write("Category names: "); 
            foreach (var n in categoryNames) Console.Write($"{n} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Union to create one sequence that contains the unique values from both arrays.")]
        private static void Linq48()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; 
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var uniqueNumbers = numbersA.Union(numbersB);

            Console.Write("Unique numbers from both arrays: "); 
            foreach (var n in uniqueNumbers) Console.Write($"{n} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Union to create one sequence that contains the unique first letter from both product and customer names.")]
        private static void Linq49_1()
        {
            var products = GetProductList();
            var customers = GetCustomerList();

            var productsFirstChar = from p in products
                select p.ProductName[0];
            var customersFirstChar = from c in customers
                select c.CompanyName[0];

            var uniqueFirstChars = productsFirstChar.Union(customersFirstChar);
            
            Console.Write("Unique first letters from Product names and Customer names: "); 
            foreach (var ch in uniqueFirstChars) Console.Write($"{ch} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Union to create one sequence that contains the unique first letter from both product and customer names.")]
        private static void Linq49_2()
        {
            var products = GetProductList();
            var customers = GetCustomerList();

            var uniqueFirstChars = products.Select(p => p.ProductName[0]).Union(customers.Select(c => c.CompanyName[0]));
            
            Console.Write("Unique first letters from Product names and Customer names: "); 
            foreach (var ch in uniqueFirstChars) Console.Write($"{ch} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Intersect to create one sequence that contains the common values shared by both arrays.")]
        private static void Linq50()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; 
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var commonNumbers = numbersA.Intersect(numbersB);
            
            Console.Write("Common numbers shared by both arrays: "); 
            foreach (var n in commonNumbers) Console.Write($"{n} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Intersect to create one sequence that contains the common first letter from both product and customer names.")]
        private static void Linq51_1()
        {
            var products = GetProductList();
            var customers = GetCustomerList();

            var productFirstChars = from p in products
                select p.ProductName[0];
            var customerFirstChars = from c in customers
                select c.CompanyName[0];

            var commonFirstChars = productFirstChars.Intersect(customerFirstChars);
            
            Console.Write("Common first letters from Product names and Customer names: "); 
            foreach (var ch in commonFirstChars) Console.Write($"{ch} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Intersect to create one sequence that contains the common first letter from both product and customer names.")]
        private static void Linq51_2()
        {
            var products = GetProductList();
            var customers = GetCustomerList();

            var commonFirstChars = products.Select(p => p.ProductName[0])
                .Intersect(customers.Select(c => c.CompanyName[0]));
            
            Console.Write("Common first letters from Product names and Customer names: "); 
            foreach (var ch in commonFirstChars) Console.Write($"{ch} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Except to create a sequence that contains the values from numbersA that are not also in numbersB.")]
        private static void Linq52()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; 
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var aOnlyNumbers = numbersA.Except(numbersB);
            
            Console.Write("Numbers in first array but not second array: "); 
            foreach (var n in aOnlyNumbers) Console.Write($"{n} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Except to create one sequence that contains the first letters of product names that are not also first letters of customer names.")]
        private static void Linq53_1()
        {
            var products = GetProductList();
            var customers = GetCustomerList();

            var productFirstChars = from p in products
                select p.ProductName[0];
            var customerFirstChars = from c in customers
                select c.CompanyName[0];

            var productsOnlyFirstChars = productFirstChars.Except(customerFirstChars);
            
            Console.Write("First letters from Product names, but not from Customer names: "); 
            foreach (var ch in productsOnlyFirstChars) Console.Write($"{ch} ");
            Console.Write('\n');
        }
        
        [Message("This sample uses Except to create one sequence that contains the first letters of product names that are not also first letters of customer names.")]
        private static void Linq53_2()
        {
            var products = GetProductList();
            var customers = GetCustomerList();

            var productsOnlyFirstChars = products.Select(p => p.ProductName[0])
                .Except(customers.Select(c => c.CompanyName[0]));
            
            Console.Write("First letters from Product names, but not from Customer names: "); 
            foreach (var ch in productsOnlyFirstChars) Console.Write($"{ch} ");
            Console.Write('\n');
        }
        
        
    }
}