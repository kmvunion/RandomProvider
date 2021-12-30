using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMVUnion.RandomProvider.Common.Extensions
{
    internal static class ListExtensions
    {
        internal static List<char> ToLower(this List<char> list)
        {
            return list.Select(x => Char.ToLower(x)).ToList();
        }

        internal static List<char> ToUpper(this List<char> list)
        {
            return list.Select(x => Char.ToUpper(x)).ToList();
        }

        internal static List<char> ToMixCase(this List<char> list)
        {
            if (list == null)
            {
                return new();
            }
            else if (list.Count < 2)
            {
                return list;
            }

            var borderRange = Convert.ToInt32(Math.Floor((decimal)(list.Count / 2)));
            var result = list.Take(borderRange).Select(x => char.ToLower(x)).ToList();
            result.AddRange(list.Skip(borderRange).Select(x => char.ToUpper(x)).ToList());

            return result;
        }
    }
}
