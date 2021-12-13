namespace KMVUnion.RandomProvider.StringRandomizer
{
    public interface IStringRandomizerBuilder : IBaseRandomizer<IStringRandomizer>
    {
        IStringRandomizerBuilder UseSymbols(char[] symbols);

        IStringRandomizerBuilder DontUseSymbols(char[] symbols);

        IStringRandomizerBuilder DontUseSymbolsFromString(string templateString);

        IStringRandomizerBuilder UseSymbolsFromString(string templateString);

        IStringRandomizerBuilder WithMinLength(int length);

        IStringRandomizerBuilder WithMaxLength(int length);

        IStringRandomizerBuilder WithExactLength(int length);

        IStringRandomizerBuilder WithSymbolsCases(SymbolCases cases);

    }
}
