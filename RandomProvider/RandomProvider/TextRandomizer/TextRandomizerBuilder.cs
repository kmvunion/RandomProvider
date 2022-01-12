using KMVUnion.RandomProvider.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMVUnion.RandomProvider.TextRandomizer
{
    public class TextRandomizerBuilder : ITextRandomizerBuilder
    {

        private readonly TextRandomizer _randomizer = new();

        public ITextRandomizer Build()
        {
            Validate();
            return _randomizer;
        }

        public ITextRandomizerBuilder SetAllowedSymbols(char[] symbols)
        {
            _randomizer.AllowedSymbols = symbols;
            return this;
        }

        public ITextRandomizerBuilder SetAllowedSymbolsFromString(string templateString)
        {
            _randomizer.AllowedSymbolsFromString = templateString;
            return this;
        }

        public ITextRandomizerBuilder SetDeniedSymbols(char[] symbols)
        {
            _randomizer.DeniedSymbols = symbols;
            return this;
        }

        public ITextRandomizerBuilder SetDeniedSymbolsFromString(string templateString)
        {
            _randomizer.DeniedSymbolsFromString = templateString;
            return this;
        }

        public ITextRandomizerBuilder WithRowLength(int rowLength)
        {
            _randomizer.RowLength = rowLength;
            return this;
        }

        public ITextRandomizerBuilder WithTextAlign(TextAlign align)
        {
            _randomizer.Align = align;
            return this;
        }

        private void Validate()
        {
            byte minUniqLength = 2;
            List<char> targetTemaplate = new();

            if (_randomizer.RowLength < 1)
                throw new ConfigurationException("Length of the rows cannot be less 0.");

            if (!string.IsNullOrEmpty(_randomizer.AllowedSymbolsFromString))
                targetTemaplate.AddRange(_randomizer.AllowedSymbolsFromString.ToArray());

            if (_randomizer.AllowedSymbols != null)
                targetTemaplate.AddRange(_randomizer.AllowedSymbols);

            targetTemaplate = targetTemaplate.Distinct().ToList();

            if (!targetTemaplate.Any())
                throw new ConfigurationException("Allowed symbols do not configured. Please set either AllowedSymbols or AllowedSymbolsFromString.");

            if (targetTemaplate?.Count < minUniqLength)
                throw new ConfigurationException($"Allowed symbols do not configured or unique configuration length is lower then {minUniqLength}.");
        }
    }
}
