using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMVUnion.RandomProvider.Common
{
    public interface ISymbolRandomizerBuilder<T>
    {
        /// <summary>
        /// Set allowed symbols from the array
        /// </summary>
        /// <param name="symbols">Array of the symbols which can be used for generating random string value</param>
        /// <returns>Randomizer builder</returns>
        T SetAllowedSymbols(char[] symbols);

        /// <summary>
        /// Set denied symbols from the array
        /// </summary>
        /// <param name="symbols">Array of the symbols which can not be used for generating random string value</param>
        /// <returns>Randomizer builder</returns>
        T SetDeniedSymbols(char[] symbols);

        /// <summary>
        /// Set denied symbols from the string
        /// </summary>
        /// <param name="templateString">String of the symbols which can not be used for generating random string value</param>
        /// <returns>Randomizer builder</returns>
        T SetDeniedSymbolsFromString(string templateString);

        /// <summary>
        /// Set allowed symbols from the string
        /// </summary>
        /// <param name="templateString">String of the symbols which can be used for generating random string value</param>
        /// <returns>Randomizer builder</returns>
        T SetAllowedSymbolsFromString(string templateString);
    }
}
