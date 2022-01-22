using KMVUnion.RandomProvider.TextRandomizer;

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

            var genereatedValues = GenrateNoisyValues(randomizer, 100);

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
                "Generating noisy text with aligning in the center.");
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
                "Example 4.",
                "Generating noisy text with aligning in the justify mode.");
            PrintHelpers.PrintTestsRezultsAsText(genereatedValues);
        }

        public static void Example5()
        {
            var randomizer = new TextRandomizerBuilder()
                        .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
                        .WithRowLength(40)
                        .WithTextAlign(TextAlign.Left)
                        .Build();

            var genereatedValues = GenrateWordyValues(randomizer, 40);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 5.",
                "Generating wordy text with aligning text from the left side.");
            PrintHelpers.PrintTestsRezultsAsText(genereatedValues);
        }

        public static void Example6()
        {
            var randomizer = new TextRandomizerBuilder()
                        .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
                        .WithRowLength(40)
                        .WithTextAlign(TextAlign.Right)
                        .Build();

            var genereatedValues = GenrateWordyValues(randomizer, 40);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 6.",
                "Generating wordy text with aligning text from the right side.");
            PrintHelpers.PrintTestsRezultsAsText(genereatedValues);
        }

        public static void Example7()
        {
            var randomizer = new TextRandomizerBuilder()
                        .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
                        .WithRowLength(40)
                        .WithTextAlign(TextAlign.Center)
                        .Build();

            var genereatedValues = GenrateWordyValues(randomizer, 40);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 7.",
                "Generating wordy text with aligning in the center.");
            PrintHelpers.PrintTestsRezultsAsText(genereatedValues);
        }

        public static void Example8()
        {
            var randomizer = new TextRandomizerBuilder()
                        .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
                        .WithRowLength(40)
                        .WithTextAlign(TextAlign.Justify)
                        .Build();

            var genereatedValues = GenrateWordyValues(randomizer, 40);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 8.",
                "Generating wordy text with aligning in the justify mode.");
            PrintHelpers.PrintTestsRezultsAsText(genereatedValues);
        }

        public static void Example9()
        {
            var randomizer = new TextRandomizerBuilder()
                        .SetAllowedSymbols(new[] { 'k', 'G', 'h', 'l', 'M', 'a', 'B', 'C', 'D', 'e', 'f' })
                        .WithRowLength(80)
                        .WithTextAlign(TextAlign.Left)
                        .Build();

            var genereatedValues = GenrateSentencesValues(randomizer, 40);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 9.",
                "Generating text which consist of set of sentences with aligning text from the left side.");
            PrintHelpers.PrintTestsRezultsAsText(genereatedValues);
        }

        public static void Example10()
        {
            var randomizer = new TextRandomizerBuilder()
                        .SetAllowedSymbols(new[] { 'k', 'G', 'h', 'l', 'M', 'a', 'B', 'C', 'D', 'e', 'f' })
                        .WithRowLength(80)
                        .WithTextAlign(TextAlign.Right)
                        .Build();

            var genereatedValues = GenrateSentencesValues(randomizer, 40);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 10.",
                "Generating text which consist of set of sentences with aligning text from the right side.");
            PrintHelpers.PrintTestsRezultsAsText(genereatedValues);
        }

        public static void Example11()
        {
            var randomizer = new TextRandomizerBuilder()
                        .SetAllowedSymbols(new[] { 'k', 'G', 'h', 'l', 'M', 'a', 'B', 'C', 'D', 'e', 'f' })
                        .WithRowLength(80)
                        .WithTextAlign(TextAlign.Center)
                        .Build();

            var genereatedValues = GenrateSentencesValues(randomizer, 40);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 11.",
                "Generating text which consist of set of sentences with aligning text in the center.");
            PrintHelpers.PrintTestsRezultsAsText(genereatedValues);
        }

        public static void Example12()
        {
            var randomizer = new TextRandomizerBuilder()
                        .SetAllowedSymbols(new[] { 'k', 'G', 'h', 'l', 'M', 'a', 'B', 'C', 'D', 'e', 'f' })
                        .WithRowLength(80)
                        .WithTextAlign(TextAlign.Justify)
                        .Build();

            var genereatedValues = GenrateSentencesValues(randomizer, 40);

            //Printing configuration and result 
            PrintHelpers.PrintConfiguration(randomizer,
                "Example 12.",
                "Generating text which consist of set of sentences with aligning in the justify mode.");
            PrintHelpers.PrintTestsRezultsAsText(genereatedValues);
        }

        private static List<List<string>> GenrateNoisyValues(ITextRandomizer randomizer, int symbolsCount, int numberOfExamples = 3)
        {
            var res = new List<List<string>>();
            for (int i = 0; i < numberOfExamples; i++)
            {
                res.Add(randomizer.GetNoisyText(symbolsCount).ToList());
            }

            return res;
        }

        private static List<List<string>> GenrateWordyValues(ITextRandomizer randomizer, int wordCount, int numberOfExamples = 3)
        {
            var res = new List<List<string>>();
            for (int i = 0; i < numberOfExamples; i++)
            {
                res.Add(randomizer.GetWordyText(wordCount).ToList());
            }

            return res;
        }

        private static List<List<string>> GenrateSentencesValues(ITextRandomizer randomizer, int wordCount, int numberOfExamples = 3)
        {
            var res = new List<List<string>>();
            for (int i = 0; i < numberOfExamples; i++)
            {
                res.Add(randomizer.GetSentencesText(wordCount).ToList());
            }

            return res;
        }
    }
}
