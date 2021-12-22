using KMVUnion.RandomProvider.Common;
using System.Text.Json;

namespace KMVUnion.RandomProvider.StringRandomizer
{
    public class StringRandomizerBuilder : IStringRandomizerBuilder
    {
        private StringRandomizer _randomizer = new();

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

        public IStringRandomizerBuilder WithExactLength(int? length)
        {
            _randomizer.ExectLength = length;
            return this;
        }

        public IStringRandomizerBuilder WithMaxLength(int? length)
        {
            _randomizer.MaxLength = length;
            return this;
        }

        public IStringRandomizerBuilder WithMinLength(int? length)
        {
            _randomizer.MinLength = length;
            return this;
        }

        public IStringRandomizerBuilder WithSymbolsCases(SymbolCases cases)
        {
            _randomizer.SymbolCases = cases;
            return this;
        }

        public IStringRandomizerBuilder RestoreFromJSON(string jsonString, JsonSerializerOptions? options = null)
        {
            return DeserializeRandomizerFromJSON(JsonSerializer.Deserialize<StringRandomizer>, jsonString, options);
        }

        public IStringRandomizerBuilder RestoreFromJSON(JsonDocument document, JsonSerializerOptions? options = null)
        {
            return DeserializeRandomizerFromJSON(JsonSerializer.Deserialize<StringRandomizer>, document, options);
        }

        public IStringRandomizerBuilder RestoreFromJSON(JsonElement element, JsonSerializerOptions? options = null)
        {
            return DeserializeRandomizerFromJSON(JsonSerializer.Deserialize<StringRandomizer>, element, options);
        }

        public IStringRandomizerBuilder RestoreFromJSON(Stream stream, JsonSerializerOptions? options = null)
        {
            return DeserializeRandomizerFromJSON(JsonSerializer.Deserialize<StringRandomizer>, stream, options);
        }

        public IStringRandomizerBuilder RestoreFromJSON(System.Text.Json.Nodes.JsonNode? node, JsonSerializerOptions? options = null)
        {            
            return DeserializeRandomizerFromJSON(JsonSerializer.Deserialize<StringRandomizer>, node, options);
        }

        private IStringRandomizerBuilder DeserializeRandomizerFromJSON<T>(Func<T, JsonSerializerOptions?, StringRandomizer?> deserializationMethod, T data, JsonSerializerOptions? options = null)
        {
            if (data == null)
                throw new ConfigurationException("String randomizer configuration cannot be restored from null JSON data object.");
            try
            {
                var restoredRandomizer = deserializationMethod(data, options);
                if (restoredRandomizer != null)
                    _randomizer = restoredRandomizer;
            }
            catch (Exception ex)
            {
                throw new ConfigurationException("Restoring randomizer configuration exception has occurred.", ex);
            }
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

            List<char> targetTemaplate = new();

            if (!string.IsNullOrEmpty(_randomizer.AllowedSymbolsFromString))
                targetTemaplate.AddRange(_randomizer.AllowedSymbolsFromString.ToArray());

            if (_randomizer.AllowedSymbols != null)
                targetTemaplate.AddRange(_randomizer.AllowedSymbols);

            targetTemaplate = targetTemaplate.Distinct().ToList();

            if (!targetTemaplate.Any())
                throw new ConfigurationException($"Allowed symbols do not configured. Please set either AllowedSymbols or AllowedSymbolsFromString.");

            if (targetTemaplate?.Count < minUniqLength)
                throw new ConfigurationException($"Allowed symbols do not configured or unique configuration length is lower then {minUniqLength}.");
        }

    }
}
