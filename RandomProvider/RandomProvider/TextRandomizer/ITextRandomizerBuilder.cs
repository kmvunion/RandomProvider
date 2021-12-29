using KMVUnion.RandomProvider.Common;

namespace KMVUnion.RandomProvider.TextRandomizer
{
    /// <summary>
    /// Text randomizer builder
    /// </summary>
    public interface ITextRandomizerBuilder : IBaseRandomizer<ITextRandomizer>, ISymbolRandomizerBuilder<ITextRandomizerBuilder>
    {
        /// <summary>
        /// Set align text mode
        /// </summary>
        /// <param name="align">Text align</param>
        /// <returns>Randomizer builder</returns>
        ITextRandomizerBuilder WithTextAlign(TextAlign align);

        /// <summary>
        /// Set text row length
        /// </summary>
        /// <param name="rowLength">Row length</param>
        /// <returns>Randomizer builder</returns>
        ITextRandomizerBuilder WithRowLength(int rowLength);
    }
}
