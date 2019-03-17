using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using static Common.MessageWrapper;

namespace LINQ_CustomSequenceOperators
{
    
    [Message("This sample shows different uses of Custom Sequence Operators")]
    internal static class CustomSequenceOperators
    {
        private static void Main(string[] args)
        {
            ShowMessage(typeof(CustomSequenceOperators));
            WrappedInvoke(Linq98);
        }

        [Message("This sample calculates the dot product of two integer vectors. It uses a user-created sequence operator, Combine, to calculate the dot product, passing it a lambda function to multiply two arrays, element by element, and sum the result.")]
        private static void Linq98()
        {
            int[] vectorA = { 0, 2, 4, 5, 6 }; 
            int[] vectorB = { 1, 3, 5, 7, 8 };

            int dotProduct = vectorA.Combine(vectorB, (a, b) => a * b).Sum();

            Console.WriteLine($"Dot product: {dotProduct}");
        }

        private static IEnumerable<T> Combine<T>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, T, T> func)
        {
            using(IEnumerator<T> e1 = first.GetEnumerator(), e2 = second.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext()) yield return func(e1.Current, e2.Current); 
            }
        } 
        
    }
}