namespace KMVUnion.RandomProvider.StringRandomizer
{
    public interface IStringRandomizerBuilder : IBaseRandomizer<IStringRandomizer>
    {
        IStringRandomizerBuilder SetAllowedSymbols(char[] symbols);

        IStringRandomizerBuilder SetDeniedSymbols(char[] symbols);

        IStringRandomizerBuilder SetDeniedSymbolsFromString(string templateString);

        IStringRandomizerBuilder SetAllowedSymbolsFromString(string templateString);

        IStringRandomizerBuilder WithMinLength(int? length);

        IStringRandomizerBuilder WithMaxLength(int? length);

        IStringRandomizerBuilder WithExactLength(int? length);

        IStringRandomizerBuilder WithSymbolsCases(SymbolCases cases);

    }
}
