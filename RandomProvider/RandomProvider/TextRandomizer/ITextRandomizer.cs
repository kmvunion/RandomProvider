using KMVUnion.RandomProvider.Common;

namespace KMVUnion.RandomProvider.TextRandomizer
{
    /// <summary>
    /// Text randomizer
    /// </summary>
    public interface ITextRandomizer : ISymbolRandomizer
    {
        /// <summary>
        /// Number of the symbols in the each row.
        /// </summary>
        int RowLength { get; }

        /// <summary>
        /// Text align mode.
        /// </summary>
        TextAlign Align { get; }

        /// <summary>
        /// Generate random noisy text
        /// </summary>
        /// <param name="sumbols">number of the symbols</param>
        /// <returns>Enumerator of strings with noisy text</returns>
        IEnumerable<string> GetNoisyText(int symbols);

        /// <summary>
        /// Generate random wordy text
        /// </summary>
        /// <param name="words">number of the words</param>
        /// <returns>Enumerator of strings with wordy text</returns>
        IEnumerable<string> GetWordyText(int words);
    }
}
