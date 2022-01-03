﻿using KMVUnion.RandomProvider.Common;
using KMVUnion.RandomProvider.Common.Extensions;
using KMVUnion.RandomProvider.StringRandomizer;
using System.Text;

namespace KMVUnion.RandomProvider.TextRandomizer
{
    public sealed class TextRandomizer : BaseSymbolRandomizer, ITextRandomizer
    {
        private IStringRandomizerBuilder _stringRandomizerBuilder = new StringRandomizerBuilder();
        private Lazy<IStringRandomizer> _noisyStringRandomizer;
        private Lazy<IStringRandomizer> _wordyStringRandomizer;
        private (int minLength, int maxLength)[] _wordLengthDistribution = new (int, int)[] { (1, 6), (7, 7), (8, 8), (9, 9), (10, 10), (11, 12), (13, 28) };

        public TextRandomizer()
        {
            _noisyStringRandomizer = new Lazy<IStringRandomizer>(() => { return NoisyRandomizer(); });
            _wordyStringRandomizer = new Lazy<IStringRandomizer>(() => { return WordyRandomizer(); });
        }

        public int RowLength { get; internal set; } = 80;

        public TextAlign Align { get; internal set; } = TextAlign.Left;

        public SymbolCases SymbolCases { get; internal set; } = SymbolCases.Mixed;

        public IEnumerable<string> GetNoisyText(int symbols)
        {
            var result = new List<string>();
            while ((result.Count + 1) * RowLength <= symbols)
            {
                result.Add(_noisyStringRandomizer.Value.GetValue(RowLength));
            }

            var restSymbols = symbols - result.Count * RowLength;
            if (restSymbols > 0)
            {
                var lastRow = _noisyStringRandomizer.Value.GetValue(restSymbols);
                result.Add(ApplyAlignPolicy(lastRow));
            }

            return result;
        }

        public IEnumerable<string> GetSentencefiedText(int words)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetWordyText(int wordCount)
        {
            List<string> words = new List<string>();
            StringBuilder row = new StringBuilder();
            for (int i = 0; i < wordCount; i++)
            {
                var rangeValue = GetWordLengthDistribution();
                var word = _wordyStringRandomizer.Value.GetValue(rangeValue.minLength, rangeValue.maxLength);

                if (row.Length + word.Length + 1 < RowLength)
                {
                    row.Append($" {word}");
                }
                else
                {
                    words.Add(ApplyAlignPolicy(row.ToString()));
                    row.Clear();
                }
            }
            return words;
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

        internal IStringRandomizer NoisyRandomizer()
        {
            return _stringRandomizerBuilder
                .SetAllowedSymbols(AllowedSymbols)
                .SetDeniedSymbols(DeniedSymbols)
                .SetAllowedSymbolsFromString(AllowedSymbolsFromString)
                .SetDeniedSymbolsFromString(DeniedSymbolsFromString)
                .WithExactLength(RowLength)
                .WithSymbolsCases((StringRandomizer.SymbolCases)SymbolCases)
                .Build();
        }

        internal IStringRandomizer WordyRandomizer()
        {
            return _stringRandomizerBuilder
                .SetAllowedSymbols(AllowedSymbols)
                .SetDeniedSymbols(DeniedSymbols)
                .SetAllowedSymbolsFromString(AllowedSymbolsFromString)
                .SetDeniedSymbolsFromString(DeniedSymbolsFromString)
                .WithExactLength(RowLength)
                .WithSymbolsCases((StringRandomizer.SymbolCases)SymbolCases)
                .Build();
        }

        internal (int minLength, int maxLength) GetWordLengthDistribution()
        {
            var combinationsCount = _wordLengthDistribution.Count();
            var randomizer = new Random();

            return _wordLengthDistribution[randomizer.Next(combinationsCount - 1)];
        }

        private string ApplyAlignPolicy(string item)
        {
            switch (Align)
            {
                case TextAlign.Justify: return item.Justify(RowLength, ' ');
                case TextAlign.Left: return item.PadRight(RowLength, ' ');
                case TextAlign.Right: return item.PadLeft(RowLength, ' ');
                case TextAlign.Center: return item.PadSides(RowLength, ' ');
                default: return item;
            }
        }
    }
}
