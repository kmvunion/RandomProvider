namespace KMVUnion.RandomProvider.Common
{
    public abstract class BaseSymbolRandomizer : ISymbolRandomizer
    {
        protected readonly Lazy<char[]> _template;

        internal BaseSymbolRandomizer()
        {
            _template = new Lazy<char[]>(() => { return BuildTemplate(); });
        }

        public char[] AllowedSymbols { get; internal set; } = Array.Empty<char>();

        public string AllowedSymbolsFromString { get; internal set; } = String.Empty;

        public char[] DeniedSymbols { get; internal set; } = Array.Empty<char>();

        public string DeniedSymbolsFromString { get; internal set; } = String.Empty;

        protected List<char> GetAllAllowedSymbols()
        {
            var res = new List<char>();
            res.AddRange(AllowedSymbols);
            if (!string.IsNullOrEmpty(AllowedSymbolsFromString))
            {
                res.AddRange(AllowedSymbolsFromString.ToArray());
            }

            return res;
        }

        protected List<char> GetAllDeniedSymbols()
        {
            var res = new List<char>();
            res.AddRange(DeniedSymbols);
            if (!string.IsNullOrEmpty(DeniedSymbolsFromString))
            {
                res.AddRange(DeniedSymbolsFromString.ToArray());
            }

            return res;
        }

        protected List<char> ExcludeDeniedSymbolsFrom(List<char> initialSymbols)
        {
            var deniedSymbols = GetAllDeniedSymbols();
            initialSymbols = initialSymbols.Distinct().ToList();
            initialSymbols.RemoveAll(s => deniedSymbols.Contains(s));
            return initialSymbols;
        }

        private char[] BuildTemplate()
        {
            var symbols = GetAllAllowedSymbols();
            ModifyAllowedSymbols(ref symbols);
            return ExcludeDeniedSymbolsFrom(symbols).ToArray();
        }

        protected abstract void ModifyAllowedSymbols(ref List<char> items);
    }
}
