using KMVUnion.RandomProvider.Common;

namespace KMVUnion.RandomProvider.StringRandomizer
{
    public class StringRandomizerBuilder : IStringRandomizerBuilder
    {
        private readonly StringRandomizer _randomizer = new StringRandomizer();

        public IStringRandomizer Build()
        {
            ValidateLength();
            ValidateTemplate();
            return _randomizer;
        }

        public IStringRandomizerBuilder SetDeniedSymbols(char[] symbols)
        {
            _randomizer.DeniedSymbols = symbols;
            return this;
        }

        public IStringRandomizerBuilder SetDeniedSymbolsFromString(string templateString)
        {
            _randomizer.DeniedSymbolsFromString = templateString;
            return this;
        }

        public IStringRandomizerBuilder SetAllowedSymbols(char[] symbols)
        {
            _randomizer.AllowedSymbols = symbols;
            return this;
        }

        public IStringRandomizerBuilder SetAllowedSymbolsFromString(string templateString)
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

        private void ValidateLength()
        {
            if (!_randomizer.MaxLength.HasValue &&
                !_randomizer.MinLength.HasValue &&
                !_randomizer.ExectLength.HasValue)
                throw new ConfigurationException("Not specified length for randomizer. Either ExactLength or (MinLenfth + MaxLength) must be configured");

            if (_randomizer.MaxLength.HasValue &&
                _randomizer.MinLength.HasValue &&
                _randomizer.ExectLength.HasValue)
                throw new ConfigurationException("Randomizer length cannot be configured by ExactLength and (MinLenfth + MaxLength) simultaneously.");

            if (_randomizer.MaxLength.HasValue &&
                _randomizer.MinLength.HasValue &&
                _randomizer.MaxLength < _randomizer.MinLength)
                throw new ConfigurationException("In randomizer configuration MaxLength can not be greater then MinLength.");

            if ((_randomizer.MaxLength.HasValue && _randomizer.MaxLength.Value < 1) ||
                (_randomizer.MinLength.HasValue && _randomizer.MinLength.Value < 1) ||
                (_randomizer.ExectLength.HasValue && _randomizer.ExectLength.Value < 1))
                throw new ConfigurationException("Length of randomizer cannot be less 0.");


        }

        private void ValidateTemplate()
        {
            byte minUniqLength = 2;
            if (
                string.IsNullOrWhiteSpace(_randomizer.AllowedSymbolsFromString) ||
                _randomizer.AllowedSymbolsFromString?.ToList().Distinct().Count() < minUniqLength ||
                _randomizer.AllowedSymbols.Distinct().ToList().Count < minUniqLength)
                throw new ConfigurationException($"Allowed symbols does not configured or unique configuration length is lower then {minUniqLength} ");


        }
    }

}
