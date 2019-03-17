using System;
using System.Linq;
using Common;
using static Common.MessageWrapper;

namespace LINQ_ConversionOperators
{
    
    [Message("This sample shows different uses of Conversion Operators")]
    internal static class ConversionOperators
    {
        private static void Main(string[] args)
        {
            ShowMessage(typeof(ConversionOperators));
            
            WrappedInvoke(Linq54_1);
            WrappedInvoke(Linq54_2);

            WrappedInvoke(Linq55_1);
            WrappedInvoke(Linq55_2);

            WrappedInvoke(Linq56);

            WrappedInvoke(Linq57);
        }

        [Message("This sample uses ToArray to immediately evaluate a sequence into an array.")]
        private static void Linq54_1()
        {
            double[] doubles = {1.7, 2.3, 1.9, 4.1, 2.9};

            var sortedDoublesArray = (from d in doubles
                    orderby d descending
                    select d)
                .ToArray();

            Console.Write("Every other double from highest to lowest: ");
            for (var d = 0; d < sortedDoublesArray.Length; d += 2) Console.Write($"{sortedDoublesArray[d]} ");
            Console.Write('\n');
        }

        [Message("This sample uses ToArray to immediately evaluate a sequence into an array.")]
        private static void Linq54_2()
        {
            double[] doubles = {1.7, 2.3, 1.9, 4.1, 2.9};

            var sortedDoublesArray = doubles.OrderByDescending(d => d).ToArray();

            Console.Write("Every other double from highest to lowest: ");
            for (var d = 0; d < sortedDoublesArray.Length; d += 2) Console.Write($"{sortedDoublesArray[d]} ");
            Console.Write('\n');
        }

        [Message("This sample uses ToList to immediately evaluate a sequence into a List<T>.")]
        private static void Linq55_1()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            var sortedWordsList = (from w in words
                    orderby w
                    select w)
                .ToList();

            Console.Write("The sorted word list: ");
            foreach (var w in sortedWordsList) Console.Write($"{w} ");
            Console.Write('\n');
        }

        [Message("This sample uses ToList to immediately evaluate a sequence into a List<T>.")]
        private static void Linq55_2()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            var sortedWordsList = words.OrderBy(w => w).ToList();

            Console.Write("The sorted word list: ");
            foreach (var w in sortedWordsList) Console.Write($"{w} ");
            Console.Write('\n');
        }

        [Message(
            "This sample uses ToDictionary to immediately evaluate a sequence and a related key expression into a dictionary.")]
        private static void Linq56()
        {
            var scoreRecords = new[]
            {
                new {Name = "Alice", Score = 50},
                new {Name = "Bob", Score = 40},
                new {Name = "Cathy", Score = 45}
            };

            var scoreRecordsDict = scoreRecords.ToDictionary(r => r.Name);
            foreach (var (name, data) in scoreRecordsDict)
            {
                Console.WriteLine($"{name} data is '{data}'");
            }
        }

        [Message("This sample uses OfType to return only the elements of the array that are of type double.")]
        private static void Linq57()
        {
            object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };

            var doubles = numbers.OfType<double>();
            
            Console.Write("Numbers stored as doubles: "); 
            foreach (var d in doubles) Console.Write($"{d} ");
            Console.Write('\n');
        }

    }
}