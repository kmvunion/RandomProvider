using KMVUnion.RandomProvider.Common;

namespace KMVUnion.RandomProvider.StringRandomizer
{
    /// <summary>
    /// String randomizer
    /// </summary>
    public interface IStringRandomizer : ISymbolRandomizer
    {
        /// <summary>
        /// Get configuration of the minimal length of generated strings.
        /// </summary>
        int? MinLength { get; }

        /// <summary>
        /// Get configuration of the maximal length of generated strings.
        /// </summary>
        int? MaxLength { get; }

        /// <summary>
        /// Get configuration of the exact length of generated strings.
        /// </summary>
        int? ExectLength { get; }

        /// <summary>
        /// Get configuration of the symbols cases for generated values.
        /// </summary>
        SymbolCases SymbolCases { get; }

        /// <summary>
        /// Generate random string value.
        /// </summary>
        /// <returns>Random string value.</returns>
        string GetValue();

        /// <summary>
        /// Generate random string value of exact length.
        /// </summary>
        /// <param name="exactLength">Exact length.</param>
        /// <returns>Random string value.</returns>
        string GetValue(int exactLength);

        /// <summary>
        /// Generate random string value with length from the range.
        /// </summary>
        /// <param name="minLength">Minimum length.</param>
        /// <param name="maxLength">Maximum length.</param>
        /// <returns>Random string value.</returns>
        string GetValue(int minLength, int maxLength);

        /// <summary>
        /// Generate IEnumerable of random string values.
        /// </summary>
        /// <param name="count">Count of generated values.</param>
        /// <returns>Enumerator of random string values.</returns>
        IEnumerable<string> GetValues(int count);
    }
}
