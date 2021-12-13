namespace KMVUnion.RandomProvider.StringRandomizer
{
    public class StringRandomizerBuilder : IStringRandomizerBuilder
    {
        private readonly StringRandomizer _randomizer = new StringRandomizer();

        public IStringRandomizer Build()
        {
            return _randomizer;
        }

        public IStringRandomizerBuilder DontUseSymbols(char[] symbols)
        {
            _randomizer.DeniedSymbols = symbols;
            return this;
        }

        public IStringRandomizerBuilder DontUseSymbolsFromString(string templateString)
        {
            _randomizer.DeniedSymbolsFromString = templateString;
            return this;
        }

        public IStringRandomizerBuilder UseSymbols(char[] symbols)
        {
            _randomizer.AllowedSymbols = symbols;
            return this;
        }

        public IStringRandomizerBuilder UseSymbolsFromString(string templateString)
        {
            _randomizer.AllowedSymbolsFromString = templateString;
            return this;
        }

        public IStringRandomizerBuilder WithExactLength(int length)
        {
            _randomizer.ExectLength = length;
            return this;
        }

        public IStringRandomizerBuilder WithMaxLength(int length)
        {
            _randomizer.MaxLength = length;
            return this;
        }

        public IStringRandomizerBuilder WithMinLength(int length)
        {
            _randomizer.MinLength = length;
            return this;
        }

        public IStringRandomizerBuilder WithSymbolsCases(SymbolCases cases)
        {
            _randomizer.SymbolCases = cases;
            return this;
        }
    }
}
