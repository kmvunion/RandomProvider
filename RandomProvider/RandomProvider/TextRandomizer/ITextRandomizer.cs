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
        /// Get configuration of the symbols cases for generated values.
        /// </summary>
        SymbolCases SymbolCases { get; }

        /// <summary>
        /// Generate random noisy text.
        /// </summary>
        /// <param name="symbolsCount">Number of the symbols.</param>
        /// <returns>Enumerator of strings with generated string.</returns>
        IEnumerable<string> GetNoisyText(int symbolsCount);

        /// <summary>
        /// Generate random noisy text and store it into the file.
        /// </summary>
        /// <param name="symbolsCount">Number of the symbols.</param>
        /// <param name="filePath">storing file path.</param>
        void GetNoisyTextToFile(int symbolsCount, string filePath);

        /// <summary>
        /// Generate random wordy text.
        /// </summary>
        /// <param name="wordCount">Number of the words.</param>
        /// <returns>Enumerator of strings with generated string.</returns>
        IEnumerable<string> GetWordyText(int wordCount);

        /// <summary>
        /// Generate random wordy text and store it into the file.
        /// </summary>
        /// <param name="wordCount">Number of the words.</param>
        /// <param name="filePath">Storing file path.</param>
        /// <returns></returns>
        void GetWordyTextToFile(int wordCount, string filePath);

        /// <summary>
        /// Generate random and similar to the literature text.
        /// It contains sentences and, each of those sentences starts from a capital letter.
        /// </summary>
        /// <param name="wordCount">Number of words.</param>
        /// <returns>Enumerator of strings with generated string.</returns>
        IEnumerable<string> GetSentencesText(int wordCount);

        /// <summary>
        /// Generate random, similar to the literature text and store it into the file.
        /// It contains sentences and, each of those starts from a capital letter.        
        /// </summary>
        /// <param name="wordCount">Number of the words.</param>
        /// <param name="filePath">Storing file path.</param>
        void GetSentencesTextToFile(int wordCount, string filePath);
    }
}
