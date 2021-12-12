namespace RandomProvider.StringRandomizer
{
    public interface IStringRandomizer
    {

        public int MinLength { get; }

        public int MaxLength { get; }

        public int ExectLength { get; }

        public char[] AllowedSymbols { get; }

        public string AllowedSymbolsFromString { get; }

        public char[] DeniedSymbols { get; }

        public string DeniedSymbolsFromString { get; }

        public SymbolCases SymbolCases { get; }

        string GetValue();
    }
}
