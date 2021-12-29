using KMVUnion.RandomProvider.Common;
using System.Text;

namespace KMVUnion.RandomProvider.StringRandomizer
{
    public sealed class StringRandomizer : BaseSymbolRandomizer, IStringRandomizer
    {

        private readonly Lazy<char[]> _template;

        internal StringRandomizer()
        {
            _template = new Lazy<char[]>(() => { return BuildTemplate(); });
        }

        public int? MinLength { get; internal set; } = null;

        public int? MaxLength { get; internal set; } = null;

        public int? ExectLength { get; internal set; } = null;

        public SymbolCases SymbolCases { get; internal set; } = SymbolCases.Mixed;

        public string GetValue()
        {
            if (ExectLength.HasValue && ExectLength > 0)
            {
                return GenerateRandomString(ExectLength.Value);
            }
            else if (MaxLength.HasValue && MaxLength > 0 && MinLength.HasValue && MinLength > 0)
            {                
                if (MinLength > MaxLength)
                {
                    throw new ArgumentOutOfRangeException("Incorrect randomizer configuration. MinLength cannot be over MaxLength");
                }
                
                var random = new Random();

                var dynamicLength = random.Next(MinLength.Value, MaxLength.Value);
                return GenerateRandomString(dynamicLength);
            }

            throw new ArgumentOutOfRangeException("Incorrect randomizer configuration");
        }

        public IEnumerable<string> GetValues(int count)
        {
            if (count < 1)
                throw new ArgumentOutOfRangeException("Argument 'count' must have value greater than 0.");

            List<string> result = new();
            for (int i = 0; i < count; i++)
            {
                result.Add(GetValue());
            }
            return result;
        }

        private string GenerateRandomString(int length)
        {
            var ressult = new StringBuilder();
            var random = new Random();
            var currentTemplate = _template.Value;

            while (ressult.Length < length)
            {
                ressult.Append(currentTemplate[random.Next(currentTemplate.Length)]);
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

            switch (SymbolCases)
            {
                case SymbolCases.Lower:
                    symbols = symbols.Select(x => Char.ToLower(x)).ToList(); break;
                case SymbolCases.Upper:
                    symbols = symbols.Select(x => Char.ToUpper(x)).ToList(); break;
                case SymbolCases.Mixed:
                    symbols = BuildMixed(symbols); break;
                case SymbolCases.None:
                    break;
            }

            symbols = symbols.Distinct().ToList();
            symbols.RemoveAll(s => DeniedSymbols.Contains(s));

            if (!string.IsNullOrEmpty(DeniedSymbolsFromString))
            {
                symbols.RemoveAll(s => DeniedSymbolsFromString.ToArray().Contains(s));
            }

            return symbols.ToArray();
        }

        private static List<char> BuildMixed(List<char> symbols)
        {
            if (symbols == null || symbols.Count < 2)
            {
                return new();
            }

            var borderRange = Convert.ToInt32(Math.Floor((decimal)(symbols.Count / 2)));
            var result = symbols.Take(borderRange).Select(x => char.ToLower(x)).ToList();
            result.AddRange(symbols.Skip(borderRange).Select(x => char.ToUpper(x)).ToList());

            return result;
        }
    }
}
