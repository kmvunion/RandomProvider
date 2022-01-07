using KMVUnion.RandomProvider.Common;
using System.Text;
using KMVUnion.RandomProvider.Common.Extensions;

namespace KMVUnion.RandomProvider.StringRandomizer
{
    public sealed class StringRandomizer : BaseSymbolRandomizer, IStringRandomizer
    {
        public int? MinLength { get; internal set; } = null;

        public int? MaxLength { get; internal set; } = null;

        public int? ExectLength { get; internal set; } = null;

        public SymbolCases SymbolCases { get; internal set; } = SymbolCases.Mixed;

        public string GetValue()
        {
            if (ExectLength.HasValue && ExectLength > 0)
            {
                return GetValue(ExectLength.Value);
            }
            else if (MaxLength.HasValue && MaxLength > 0 && MinLength.HasValue && MinLength > 0)
            {
                return GetValue(MinLength.Value, MaxLength.Value);
            }

            throw new ConfigurationException("Incorrect randomizer configuration");
        }

        public string GetValue(int exactLength)
        {
            if (exactLength > 0)
            {
                return GenerateRandomString(exactLength);
            }

            throw new ArgumentOutOfRangeException(nameof(exactLength));
        }

        public string GetValue(int minLength, int maxLength)
        {
            if (maxLength < 0)
                throw new ArgumentOutOfRangeException(nameof(maxLength));
            if (minLength < 0)
                throw new ArgumentOutOfRangeException(nameof(minLength));

            if (minLength > maxLength)
            {
                throw new ConfigurationException("Incorrect randomizer configuration, minLength can not be over maxLength");
            }

            var random = new Random();

            var dynamicLength = random.Next(minLength, maxLength);
            return GenerateRandomString(dynamicLength);
        }

        public IEnumerable<string> GetValues(int count)
        {
            if (count < 1)
                throw new ArgumentOutOfRangeException(nameof(count));

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

        protected override void ModifyAllowedSymbols(ref List<char> items)
        {
            switch (SymbolCases)
            {
                case SymbolCases.Lower: items = items.ToLower(); break;
                case SymbolCases.Upper: items = items.ToUpper(); break;
                case SymbolCases.Mixed: items = items.ToMixCase(); break;
                case SymbolCases.None: break;
            }
        }
    }
}
