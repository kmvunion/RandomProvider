namespace KMVUnion.RandomProvider.StringRandomizer
{
    /// <summary>
    /// String randomizer
    /// </summary>
    public interface IStringRandomizer
    {
        /// <summary>
        /// Get configuration of the minimal length of generated strings
        /// </summary>
        int? MinLength { get; }

        /// <summary>
        /// Get configuration of the maximal length of generated strings
        /// </summary>
        int? MaxLength { get; }

        /// <summary>
        /// Get configuration of the exact length of generated strings
        /// </summary>
        int? ExectLength { get; }

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

        /// <summary>
        /// Get configuration of the symbols cases for generated values
        /// </summary>
        SymbolCases SymbolCases { get; }

        /// <summary>
        /// Generate random string value
        /// </summary>
        /// <returns>Random string value</returns>
        string GetValue();

        /// <summary>
        /// Generate IEnumerable of random string values
        /// </summary>
        /// <param name="count">Count of generated values</param>
        /// <returns>Enumerator of random string values</returns>
        IEnumerable<string> GetValues(int count);
    }
}
