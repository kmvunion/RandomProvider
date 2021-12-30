using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMVUnion.RandomProvider.Common
{
    public class BaseSymbolRandomizer : ISymbolRandomizer
    {
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
    }
}
