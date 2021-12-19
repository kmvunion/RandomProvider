using KMVUnion.RandomProvider.Example;
using KMVUnion.RandomProvider.StringRandomizer;

Example1();
Example2();
Example3();

Console.ReadLine();

void Example1()
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

void Example2()
{
    var randomizer = new StringRandomizerBuilder()
    .SetAllowedSymbolsFromString("This is string of symbols from which will be used as a template for generating random string.")
    .WithMinLength(3)
    .WithMaxLength(10)
    .WithSymbolsCases(SymbolCases.Lower)
    .Build();
    var genereatedValues = GenrateValues(randomizer);

    //Printing configuration and result 
    PrintHelpers.PrintConfiguration(randomizer,
        "Example 2.",
        "Example of using symbols from the string. Variable length and only in lower case. ");
    PrintHelpers.PrintTestsRezults(genereatedValues);
}

void Example3()
{
    var randomizer = new StringRandomizerBuilder()
    .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f', '$', '%', '#' })
    .SetDeniedSymbolsFromString("A5$#")
    .WithSymbolsCases(SymbolCases.Upper)
    .WithExactLength(15)
    .Build();
    var genereatedValues = GenrateValues(randomizer);

    //Printing configuration and result 
    PrintHelpers.PrintConfiguration(randomizer,
        "Example 3.",
        "Example of using only symbols configuration and do not use symbols from excluding string. Also only Upper character cases has applied. ");
    PrintHelpers.PrintTestsRezults(genereatedValues);
}

void Example4()
{
    var randomizer = new StringRandomizerBuilder()
        .SetAllowedSymbols(new[] { '1', '2', '3' })
        .WithExactLength(50)
        .Build();

    var genereatedValues = GenrateValues(randomizer);

    //Printing configuration and result 
    PrintHelpers.PrintConfiguration(randomizer,
        "Example 3.",
        "Example of using only symbols configuration and do not use symbols from excluding string. Also only Upper character cases has applied. ");
    PrintHelpers.PrintTestsRezults(genereatedValues);
}

List<string> GenrateValues(IStringRandomizer randomizer, int numberOfExamples = 3)
{
    var res = new List<string>();
    for (int i = 0; i < numberOfExamples; i++)
    {
        res.Add(randomizer.GetValue());
    }

    return res;
}
