using KMVUnion.RandomProvider.StringRandomizer;

namespace KMVUnion.RandomProvider.Example
{
    static internal class StringRandomizerExamples
    {

        public static void Example1()
        {
            var randomizer = new StringRandomizerBuilder()
            .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
            .WithExactLength(7)
            .Build();
            var genereatedValues = GenrateValues(randomizer);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 1.",
                "Example of using only symbols configuration and exact length. Mixed(Top and Lower) character cases. ");
            PrintHelpers.PrintTestsRezults(genereatedValues);
        }

        public static void Example2()
        {
            var randomizer = new StringRandomizerBuilder()
            .SetAllowedSymbolsFromString("This is string of symbols from which will be used as a template for generating random string.")
            .WithMinLength(3)
            .WithMaxLength(10)
            .WithSymbolsCases(KMVUnion.RandomProvider.StringRandomizer.SymbolCases.Lower)
            .Build();
            var genereatedValues = GenrateValues(randomizer);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 2.",
                "Example of using symbols from the string. Variable length and only in lower case. ");
            PrintHelpers.PrintTestsRezults(genereatedValues);
        }

        public static void Example3()
        {
            var randomizer = new StringRandomizerBuilder()
            .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f', '$', '%', '#' })
            .SetDeniedSymbolsFromString("A5$#")
            .WithSymbolsCases(KMVUnion.RandomProvider.StringRandomizer.SymbolCases.Upper)
            .WithExactLength(15)
            .Build();
            var genereatedValues = GenrateValues(randomizer);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 3.",
                "Example of using only symbols configuration and do not use symbols from excluding string. Also only Upper character cases has applied. ");
            PrintHelpers.PrintTestsRezults(genereatedValues);
        }

        public static void Example4()
        {
            var randomizer = new StringRandomizerBuilder()
            .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f', '$', '%', '#' })
            .SetDeniedSymbolsFromString("A5$#")
            .WithSymbolsCases(KMVUnion.RandomProvider.StringRandomizer.SymbolCases.Upper)
            .WithExactLength(15)
            .Build();
            var genereatedValues = GenrateRunTimeExactValue(randomizer);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 4.",
                "Example of using only symbols configuration and do not use symbols from excluding string. Running generating random value of exact length in runtime.");
            PrintHelpers.PrintTestsRezults(genereatedValues);
        }

        public static void Example5()
        {
            var randomizer = new StringRandomizerBuilder()
            .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f', '$', '%', '#' })
            .SetDeniedSymbolsFromString("A5$#")
            .WithSymbolsCases(KMVUnion.RandomProvider.StringRandomizer.SymbolCases.Upper)
            .WithExactLength(15)
            .Build();
            var genereatedValues = GenrateRunTimeRangeValue(randomizer);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 5.",
                "Example of using only symbols configuration and do not use symbols from excluding string. Running generating random value from the range of length in runtime.");
            PrintHelpers.PrintTestsRezults(genereatedValues);
        }

        public static void Example6()
        {
            var randomizer = new StringRandomizerBuilder()
                .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
                .WithExactLength(5)
                .Build();

            var genereatedValues = GenrateCollectionOfValues(randomizer);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 6.",
                "Example of using of the generating collection random strings.");
            PrintHelpers.PrintTestsRezults(genereatedValues);
        }

        static List<string> GenrateValues(IStringRandomizer randomizer, int numberOfExamples = 3)
        {
            var res = new List<string>();
            for (int i = 0; i < numberOfExamples; i++)
            {
                res.Add(randomizer.GetValue());
            }

            return res;
        }

        static List<string> GenrateRunTimeExactValue(IStringRandomizer randomizer, int numberOfExamples = 3)
        {
            var res = new List<string>();
            for (int i = 0; i < numberOfExamples; i++)
            {
                res.Add(randomizer.GetValue(7));
            }

            return res;
        }

        static List<string> GenrateRunTimeRangeValue(IStringRandomizer randomizer, int numberOfExamples = 3)
        {
            var res = new List<string>();
            for (int i = 0; i < numberOfExamples; i++)
            {
                res.Add(randomizer.GetValue(7,15));
            }

            return res;
        }

        static List<string> GenrateCollectionOfValues(IStringRandomizer randomizer, int numberOfExamples = 3, int numberOfItems = 4)
        {
            var res = new List<string>();
            for (int i = 0; i < numberOfExamples; i++)
            {
                var value = randomizer.GetValues(numberOfItems);
                var text = $"[{string.Join(", ", value.ToArray())}]";
                res.Add(text);
            }

            return res;
        }
    }
}
