using System;
using System.Collections.Generic;

namespace LINQ_OrderingOperators
{
    internal class CaseSensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y) => string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
    }
}