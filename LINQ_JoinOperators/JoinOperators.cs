using System;
using System.Linq;
using Common;
using static Common.MessageWrapper;
using static Common.Utils;

namespace LINQ_JoinOperators
{
    
    [Message("This sample shows different uses of Join Operators")]
    internal static class JoinOperators
    {
        private static void Main(string[] args)
        {
            ShowMessage(typeof(JoinOperators));
            
            WrappedInvoke(Linq102_1);
            WrappedInvoke(Linq102_2);
            
            WrappedInvoke(Linq103_1);
            WrappedInvoke(Linq103_2);

            WrappedInvoke(Linq104_1);
            WrappedInvoke(Linq104_2);

            WrappedInvoke(Linq105_1);
            WrappedInvoke(Linq105_2);
        }
        
        [Message("This sample shows how to efficiently join elements of two sequences based on equality between key expressions over the two.")]
        private static void Linq102_1()
        {
            string[] categories =
            {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };

            var products = GetProductList();

            var q = from c in categories
                join p in products on c equals p.Category
                select new { Category = c, p.ProductName };

            foreach (var v in q) Console.WriteLine($"{v.ProductName}: {v.Category}");
        }
        
        [Message("This sample shows how to efficiently join elements of two sequences based on equality between key expressions over the two.")]
        private static void Linq102_2()
        {
            string[] categories =
            {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };

            var products = GetProductList();

            var q = categories.Join(products, c => c, p => p.Category,
                (c, p) => new {Category = c, p.ProductName});

            foreach (var v in q) Console.WriteLine($"{v.ProductName}: {v.Category}");
        }
        
        [Message("Using a group join you can get all the products that match a given category bundled as a sequence.")]
        private static void Linq103_1()
        {
            string[] categories = 
            {  
                "Beverages",  
                "Condiments",  
                "Vegetables",  
                "Dairy Products",  
                "Seafood" 
            };

            var products = GetProductList();

            var q = from c in categories
                join p in products on c equals p.Category into ps
                where ps.Any()
                select new { Category = c, Products = ps };

            foreach (var v in q)
            {
                Console.WriteLine($"{v.Category}: ");
                foreach (var p in v.Products) Console.WriteLine($"  {p.ProductName}");
            }
        }
        
        [Message("Using a group join you can get all the products that match a given category bundled as a sequence.")]
        private static void Linq103_2()
        {
            string[] categories = 
            {  
                "Beverages",  
                "Condiments",  
                "Vegetables",  
                "Dairy Products",  
                "Seafood" 
            };

            var products = GetProductList();

            var q = categories.GroupJoin(products, c => c, p => p.Category,
                (c, ps) => new {Category = c, Products = ps});

            foreach (var v in q)
            {
                Console.WriteLine($"{v.Category}: ");
                foreach (var p in v.Products) Console.WriteLine($"  {p.ProductName}");
            }
        }
        
        [Message("The group join operator is more general than join, as this slightly more verbose version of the cross join sample shows.")]
        private static void Linq104_1()
        {
            string[] categories = 
            {   
                "Beverages",  
                "Condiments",  
                "Vegetables", 
                "Dairy Products",   
                "Seafood"
            };
            var products = GetProductList();

            var q = from c in categories
                join p in products on c equals p.Category into ps
                where ps.Any()
                from p in ps
                select new { Category = c, p.ProductName };

            foreach (var v in q) Console.WriteLine($"{v.Category}: {v.ProductName}");
        }
        
        [Message("The group join operator is more general than join, as this slightly more verbose version of the cross join sample shows.")]
        private static void Linq104_2()
        {
            string[] categories = 
            {   
                "Beverages",  
                "Condiments",  
                "Vegetables", 
                "Dairy Products",   
                "Seafood"
            };
            var products = GetProductList();

            var q = categories.GroupJoin(products, c => c, p => p.Category, (c, ps) => (c: c, ps: ps))
                .Where(e => e.ps.Any())
                .SelectMany(e => e.ps, (e, p) => new {Category = e.c, p.ProductName});
            
            foreach (var v in q) Console.WriteLine($"{v.Category}: {v.ProductName}");
        }
        
        [Message("A so-called outer join can be expressed with a group join. A left outer join is like a cross join, " +
                 "except that all the left hand side elements get included at least once, even if they don't match any " +
                 "right hand side elements. Note how Vegetables shows up in the output even though it has no matching products.")]
        private static void Linq105_1()
        {
            string[] categories = 
            {   
                "Beverages",  
                "Condiments",   
                "Vegetables",   
                "Dairy Products",  
                "Seafood"
            }; 
  
            var products = GetProductList();

            var q = from c in categories
                join p in products on c equals p.Category into ps
                from p in ps.DefaultIfEmpty()
                select new { Category = c, ProductName = p?.ProductName ?? "(No products)" };

            foreach (var v in q)
            {
                Console.WriteLine($"{v.ProductName}: {v.Category}");
            }
        }
        
        [Message("A so-called outer join can be expressed with a group join. A left outer join is like a cross join, " +
                 "except that all the left hand side elements get included at least once, even if they don't match any " +
                 "right hand side elements. Note how Vegetables shows up in the output even though it has no matching products.")]
        private static void Linq105_2()
        {
            string[] categories = 
            {   
                "Beverages",  
                "Condiments",   
                "Vegetables",   
                "Dairy Products",  
                "Seafood"
            }; 
  
            var products = GetProductList();

            var q = categories.GroupJoin(products, c => c, p => p.Category, (c, ps) => (c: c, ps: ps.DefaultIfEmpty()))
                .SelectMany(e => e.ps, (e, p) => new { Category = e.c, ProductName = p?.ProductName ?? "(No products)" });

            foreach (var v in q)
            {
                Console.WriteLine($"{v.ProductName}: {v.Category}");
            }
        }
        
    }
}