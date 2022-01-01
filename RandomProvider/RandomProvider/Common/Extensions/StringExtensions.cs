using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMVUnion.RandomProvider.Common.Extensions
{
    internal static class StringExtensions
    {
        internal static string AddLeft(this string item, int rowLength, char symbol)
        {
            return $"{new string(symbol, rowLength - item.Length)}{item}";
        }

        internal static string AddRight(this string item, int rowLength, char symbol)
        {
            return $"{item}{new string(symbol, rowLength - item.Length)}{item}";
        }
    }
}
