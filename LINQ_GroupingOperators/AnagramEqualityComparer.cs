using System;
using System.Collections.Generic;

namespace LINQ_GroupingOperators
{
    public class AnagramEqualityComparer : IEqualityComparer<string>
    {
        
        public bool Equals(string x, string y) => string.Equals(GetCanonicalString(x), GetCanonicalString(y));
        public int GetHashCode(string obj) => GetCanonicalString(obj).GetHashCode();

        private static string GetCanonicalString(string str)
        {
            var chars = str.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
        
    }
}