using KMVUnion.RandomProvider.TextRandomizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMVUnion.RandomProvider.Example
{
    internal static class TextRandomizerExamples
    {

        public static void Example1()
        {
            var randomizer = new TextRandomizerBuilder()
                        .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
                        .WithRowLength(30)
                        .WithTextAlign(TextAlign.Left)
                        .Build();   

            var genereatedValues = GenrateNoisyValues(randomizer,100);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 1.",
                "Generating noisy text with aligning text from the left side.");
            PrintHelpers.PrintTestsRezultsAsText(genereatedValues);
        }

        public static void Example2()
        {
            var randomizer = new TextRandomizerBuilder()
                        .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })                        
                        .WithRowLength(30)
                        .WithTextAlign(TextAlign.Right)
                        .Build();

            var genereatedValues = GenrateNoisyValues(randomizer, 100);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 2.",
                "Generating noisy text with aligning text from the right side.");
            PrintHelpers.PrintTestsRezultsAsText(genereatedValues);
        }

        public static void Example3()
        {
            var randomizer = new TextRandomizerBuilder()
                        .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
                        .WithRowLength(30)
                        .WithTextAlign(TextAlign.Center)
                        .Build();

            var genereatedValues = GenrateNoisyValues(randomizer, 100);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 3.",
                "Generating noisy text with aligning text in the center.");
            PrintHelpers.PrintTestsRezultsAsText(genereatedValues);
        }

        public static void Example4()
        {
            var randomizer = new TextRandomizerBuilder()
                        .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
                        .WithRowLength(30)
                        .WithTextAlign(TextAlign.Justify)
                        .Build();

            var genereatedValues = GenrateNoisyValues(randomizer, 100);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 3.",
                "Generating noisy text with aligning text in justify mode. According to noisy text is generating text should be aligned by default (left).");
            PrintHelpers.PrintTestsRezultsAsText(genereatedValues);
        }

        private static List<List<string>> GenrateNoisyValues(ITextRandomizer randomizer,int symbolsCount, int numberOfExamples = 3)
        {
            var res = new List<List<string>>();
            for (int i = 0; i < numberOfExamples; i++)
            {
                res.Add(randomizer.GetNoisyText(symbolsCount).ToList());
            }

            return res;
        }
    }
}
