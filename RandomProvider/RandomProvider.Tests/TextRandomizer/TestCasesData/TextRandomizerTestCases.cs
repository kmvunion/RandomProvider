using KMVUnion.RandomProvider.TextRandomizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomProvider.Tests.TextRandomizer.TestCasesData
{
    public class TextRandomizerTestCases
    {
        public static object[] GetNoisyTextDifferentLength =
        {
            new object[] {370, 400,TextAlign.Left},
            new object[] {41, 80, TextAlign.Left},
            new object[] {40, 40, TextAlign.Left},
            new object[] {30, 40, TextAlign.Left},
            new object[] {1, 40, TextAlign.Left},

            new object[] {370, 400, TextAlign.Right},
            new object[] {41, 80, TextAlign.Right},
            new object[] {40, 40, TextAlign.Right},
            new object[] {30, 40, TextAlign.Right},
            new object[] {1, 40, TextAlign.Right},

            new object[] {370, 400, TextAlign.Center},
            new object[] {41, 80, TextAlign.Center},
            new object[] {40, 40, TextAlign.Center},
            new object[] {30, 40, TextAlign.Center},
            new object[] {1, 40, TextAlign.Center},

            new object[] {370, 400, TextAlign.Justify},
            new object[] {41, 80, TextAlign.Justify},
            new object[] {40, 40, TextAlign.Justify},
            new object[] {30, 40, TextAlign.Justify},
            new object[] {1, 40, TextAlign.Justify}
        };

        public static object[] GetWordyTextDifferentLength =
        {
            new object[] {1,TextAlign.Left},
            new object[] {12, TextAlign.Left},
            new object[] {30, TextAlign.Left},

            new object[] {1,TextAlign.Right},
            new object[] {12, TextAlign.Right},
            new object[] {30, TextAlign.Right },

            new object[] {1,TextAlign.Center},
            new object[] {12, TextAlign.Center},
            new object[] {30, TextAlign.Center },

            new object[] {1,TextAlign.Justify},
            new object[] {12, TextAlign.Justify},
            new object[] {30, TextAlign.Justify }
        };
    }
}
