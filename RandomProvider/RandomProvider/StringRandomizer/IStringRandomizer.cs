namespace RandomProvider.StringRandomizer
{
    public interface IStringRandomizer
    {

        public int MinLength { get; }

        public int MaxLength { get; }

        public char[] AllowedSymbols { get; }

        public string AllowedSymbolsFromString { get;}

        public char[] DeniedSymbols { get; }

        public string DeniedSymbolsFromString { get; }

        string GetValue();
    }
}
