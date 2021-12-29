using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMVUnion.RandomProvider.Common
{
    public interface ISymbolRandomizer
    {
        /// <summary>
        /// Get configuration of allowed symbols from the array
        /// </summary>
        char[] AllowedSymbols { get; }

        /// <summary>
        /// Get configuration of allowed symbols from the string
        /// </summary>
        string AllowedSymbolsFromString { get; }

        /// <summary>
        /// Get configuration of denied symbols from the array
        /// </summary>
        char[] DeniedSymbols { get; }

        /// <summary>
        /// Get configuration of denied symbols from the string
        /// </summary>
        string DeniedSymbolsFromString { get; }
    }
}
