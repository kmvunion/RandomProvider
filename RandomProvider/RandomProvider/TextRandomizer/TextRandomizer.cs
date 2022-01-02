﻿using KMVUnion.RandomProvider.Common;
using KMVUnion.RandomProvider.Common.Extensions;
using KMVUnion.RandomProvider.StringRandomizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMVUnion.RandomProvider.TextRandomizer
{
    public sealed class TextRandomizer : BaseSymbolRandomizer, ITextRandomizer
    {
        private IStringRandomizerBuilder _stringRandomizerBuilder = new StringRandomizerBuilder();
        private Lazy<IStringRandomizer> _noisyStringRandomizer;

        public TextRandomizer()
        {
            _noisyStringRandomizer = new Lazy<IStringRandomizer>(() => { return NoisyRandomizer(); });
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
                switch (Align)
                {
                    case TextAlign.Justify:
                    case TextAlign.Left: result.Add(lastRow.PadRight(RowLength, ' ')); break;
                    case TextAlign.Right: result.Add(lastRow.PadLeft(RowLength, ' ')); break;
                    case TextAlign.Center: result.Add(lastRow.PadSides(RowLength, ' ')); break;                    
                }
            }

            return result;
        }

        public IEnumerable<string> GetSentencefiedText(int words)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetWordyText(int words)
        {
            throw new NotImplementedException();
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
    }
}
