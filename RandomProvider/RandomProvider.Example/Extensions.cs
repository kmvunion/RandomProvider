using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomProvider.Example
{
    internal static class Extensions
    {
        internal static string FillUpToLength(this string text, int targetLength = 30, char charValue = '.')
        {
            var textLength = text.Length;
            if (targetLength <= textLength)
            {
                return text;
            }
            return text + string.Concat(Enumerable.Repeat(charValue, targetLength - textLength));
        }

        internal static string ToStringRepresentation(this IEnumerable collection, string separator = ", ")
        {
            var res = new StringBuilder();
            foreach (var item in collection)
            {
                res.Append(item.ToString());
                res.Append(separator);
            }
            return res.ToString().Trim(separator.ToArray());
        }
    }
}
