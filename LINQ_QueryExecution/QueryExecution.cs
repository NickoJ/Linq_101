using System;
using System.Linq;
using Common;
using static Common.MessageWrapper;

namespace LINQ_QueryExecution
{
    
    [Message("This sample shows different uses of Query Execution")]
    internal static class QueryExecution
    {

        private static void Main(string[] args)
        {
            ShowMessage(typeof(QueryExecution));
            
            WrappedInvoke(Linq99_1);
            WrappedInvoke(Linq99_2);
            
            WrappedInvoke(Linq100_1);
            WrappedInvoke(Linq100_2);

            WrappedInvoke(Linq101_1);
            WrappedInvoke(Linq101_2);
        }
        
        [Message("The following sample shows how query execution is deferred until the query is enumerated at a foreach statement.")]
        private static void Linq99_1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int i = 0;
            var q = from n in numbers
                select ++i;

            foreach (var v in q) Console.WriteLine($"v: {v}, i: {i}");
        }
        
        [Message("The following sample shows how query execution is deferred until the query is enumerated at a foreach statement.")]
        private static void Linq99_2()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int i = 0;
            var q = numbers.Select(n => ++i);

            foreach (var v in q) Console.WriteLine($"v: {v}, i: {i}");
        }
        
        [Message("The following sample shows how queries can be executed immediately with operators such as ToList().")]
        private static void Linq100_1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int i = 0;
            var q = (from n in numbers
                    select ++i)
                .ToList();

            foreach (var v in q) Console.WriteLine($"v: {v}, i: {i}");
        }
        
        [Message("The following sample shows how queries can be executed immediately with operators such as ToList().")]
        private static void Linq100_2()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int i = 0;
            var q = numbers.Select(n => ++i).ToList();

            foreach (var v in q) Console.WriteLine($"v: {v}, i: {i}");
        }
        
        [Message("The following sample shows how, because of deferred execution, queries can be used again after data changes and will then operate on the new data.")]
        private static void Linq101_1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNumbers = from n in numbers
                where n < 3
                select n;
            
            Console.Write($"First run number < 3: ");
            foreach (var n in lowNumbers) Console.Write($"{n} ");
            Console.Write('\n');

            for (int i = 0; i < numbers.Length; ++i) numbers[i] = -numbers[i];
            
            Console.Write($"Second run number < 3: ");
            foreach (var n in lowNumbers) Console.Write($"{n} ");
            Console.Write('\n');
        }
        
        [Message("The following sample shows how, because of deferred execution, queries can be used again after data changes and will then operate on the new data.")]
        private static void Linq101_2()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNumbers = numbers.Where(n => n < 3);
            
            Console.Write($"First run number < 3: ");
            foreach (var n in lowNumbers) Console.Write($"{n} ");
            Console.Write('\n');

            for (int i = 0; i < numbers.Length; ++i) numbers[i] = -numbers[i];
            
            Console.Write($"Second run number < 3: ");
            foreach (var n in lowNumbers) Console.Write($"{n} ");
            Console.Write('\n');
        }
        
    }
}