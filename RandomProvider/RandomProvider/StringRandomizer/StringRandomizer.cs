using System.Text;

namespace RandomProvider.StringRandomizer
{
    public sealed class StringRandomizer : IStringRandomizer
    {

        private char[] _template;

        public int MinLength { get; internal set; }

        public int MaxLength { get; internal set; }

        public int ExectLength { get; internal set; }

        public char[] AllowedSymbols { get; internal set; } = Array.Empty<char>();

        public string AllowedSymbolsFromString { get; internal set; } = String.Empty;

        public char[] DeniedSymbols { get; internal set; } = Array.Empty<char>();

        public string DeniedSymbolsFromString { get; internal set; } = String.Empty;

        public SymbolCases SymbolCases { get; internal set; } = SymbolCases.Mixed;

        public string GetValue()
        {
            

            _template = BuildTemplate();
            

            if (ExectLength > 0)
            {
                return GenerateRandomString(ExectLength);
            }
            else if (MaxLength > 0 && MinLength>0)
            {
                var random = new Random();
                
                if (MinLength > MaxLength)
                {
                    throw new ArgumentOutOfRangeException("Incorrect randomizer configuration. MinLength cannot be over MaxLength");
                }
                
                var dynamicLength = random.Next(MinLength, MaxLength);
                return GenerateRandomString(dynamicLength);

            }
            throw new ArgumentOutOfRangeException("Incorrect randomizer configuration");

        }

        private string GenerateRandomString( int length)
        {
            var ressult = new StringBuilder();
            var random = new Random();

            while (ressult.Length < length)
            {
                ressult.Append(_template[random.Next(_template.Length)]);
            }

            return ressult.ToString();
        }

        private char[] BuildTemplate()
        {
            var symbols = new List<char>();

            symbols.AddRange(AllowedSymbols);
            if (!string.IsNullOrEmpty(AllowedSymbolsFromString))
            {
                symbols.AddRange(AllowedSymbolsFromString.ToArray());
            }

            symbols = symbols.Distinct().ToList();            
            symbols.RemoveAll(s => DeniedSymbols.Contains(s));
           
            if (!string.IsNullOrEmpty(DeniedSymbolsFromString))
            {
                symbols.RemoveAll(s => DeniedSymbolsFromString.ToArray().Contains(s));
            }            

            switch (SymbolCases)
            {
                case SymbolCases.Lower:
                    return symbols.Select(x => Char.ToLower(x)).ToArray();
                    break;

                case SymbolCases.Upper:
                    return symbols.Select(x => Char.ToUpper(x)).ToArray();
                    break;

                case SymbolCases.Mixed:
                    return BuildMixed(symbols.ToArray());
                    break;
            }

            return symbols.ToArray();
        }

        private char[] BuildMixed(char[] symbols)
        {
            if (symbols == null || symbols.Length < 2)
            {
                return symbols;
            }

            var borderRange = Convert.ToInt32(Math.Floor((decimal)(symbols.Length / 2)));
            var result = symbols.Take(borderRange).Select(x => char.ToLower(x)).ToList();
            result.AddRange(symbols.Skip(borderRange).Select(x => char.ToUpper(x)).ToList());

            return result.ToArray();
        }
    }
}
