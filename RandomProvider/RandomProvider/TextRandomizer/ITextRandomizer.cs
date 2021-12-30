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
        /// <returns>Enumerator of strings with generated string</returns>
        IEnumerable<string> GetNoisyText(int symbols);

        /// <summary>
        /// Generate random wordy text
        /// </summary>
        /// <param name="words">number of the words</param>
        /// <returns>Enumerator of strings with generated string</returns>
        IEnumerable<string> GetWordyText(int words);

        /// <summary>
        /// Generate random and similar to the literature text.
        /// It contains sentences and, each of those starts from a capital letter.
        /// </summary>
        /// <param name="words">number of words</param>
        /// <returns>Enumerator of strings with generated string</returns>
        IEnumerable<string> GetSentencefiedText(int words);
    }
}
