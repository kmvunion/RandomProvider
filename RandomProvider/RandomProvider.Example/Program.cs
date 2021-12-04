using RandomProvider.StringRandomizer;

var randomizer = new StringRandomizerBuilder()
    .UseSymbols(new[] { '1', '2', '3', '4', '5', 'a', 'b', 'c', 'd', 'e', 'f' })
    .WithExectLength(20)
    .WithSymbolsCases(SymbolCases.Lower).Build();

PrintTestsRezults(randomizer, "Lowercase with length 20. ");

randomizer = new StringRandomizerBuilder()
    .UseSymbols(new[] { '1', '2', '3', '4', '5', 'a', 'b', 'c', 'd', 'e', 'f' })
    .WithExectLength(20)
    .WithSymbolsCases(SymbolCases.Upper).Build();
PrintTestsRezults(randomizer, "UpperCase with length 20. ");

randomizer = new StringRandomizerBuilder()
    .UseSymbols(new[] { '1', 'g', 'h', 'l', '5', 'a', 'b', 'c', 'd', 'e', 'f' })
    .WithExectLength(10)
    .WithSymbolsCases(SymbolCases.Mixed).Build();
PrintTestsRezults(randomizer, "Mixed with length 10. ");

randomizer = new StringRandomizerBuilder()
    .UseSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
    .WithExectLength(7).Build();
PrintTestsRezults(randomizer, "Use predefined chars with length 7.");

Console.ReadLine();

void PrintTestsRezults(IStringRandomizer randomizer, string title)
{
    Console.WriteLine();
    Console.WriteLine($"-- {title} -------------------");
    Console.WriteLine(randomizer.GetValue());
    Console.WriteLine(randomizer.GetValue());
    Console.WriteLine(randomizer.GetValue());
}




