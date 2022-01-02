using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMVUnion.RandomProvider.Common.Extensions
{
    internal static class StringExtensions
    {
        internal static string PadSides(this string item, int rowLength, char symbol)
        {
            int sidelength = Convert.ToInt32(Math.Floor((decimal)((rowLength - item.Length) / 2)));            
            return $"{new string(symbol, sidelength)}{item}{new string(symbol, rowLength-item.Length-sidelength)}";
        }
    }
}
