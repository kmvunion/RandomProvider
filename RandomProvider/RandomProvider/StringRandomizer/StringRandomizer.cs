using KMVUnion.RandomProvider.Common;
using System.Text;
using KMVUnion.RandomProvider.Common.Extensions;

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
            var symbols = GetAllAllowedSymbols();

            switch (SymbolCases)
            {
                case SymbolCases.Lower: symbols = symbols.ToLower(); break;
                case SymbolCases.Upper: symbols = symbols.ToUpper(); break;
                case SymbolCases.Mixed: symbols = symbols.ToMixCase(); break;
                case SymbolCases.None: break;
            }

            return ExcludeDeniedSymbolsFrom(symbols).ToArray();
        }
    }
}
