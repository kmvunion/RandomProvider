using KMVUnion.RandomProvider.Common;

namespace KMVUnion.RandomProvider.StringRandomizer
{
    /// <summary>
    /// String randomizer builder
    /// </summary>
    public interface IStringRandomizerBuilder : IBaseRandomizer<IStringRandomizer>, ISymbolRandomizerBuilder<IStringRandomizerBuilder>
    {       
        /// <summary>
        /// Set minimal length for generated values. Uses in pair with the MaxLength property. 
        /// </summary>
        /// <param name="length">Minimal length.</param>
        /// <returns>Randomizer builder.</returns>
        IStringRandomizerBuilder WithMinLength(int? length);

        /// <summary>
        /// Set maximal length for generated values. Uses in pair with the MinLength property.
        /// </summary>
        /// <param name="length">Maximal length.</param>
        /// <returns>Randomizer builder.</returns>
        IStringRandomizerBuilder WithMaxLength(int? length);

        /// <summary>
        /// Set exact length for generated values.
        /// </summary>
        /// <param name="length">Exact length.</param>
        /// <returns>Randomizer builder.</returns>
        IStringRandomizerBuilder WithExactLength(int? length);

        /// <summary>
        /// Set symbols case option for configuration generated values.
        /// </summary>
        /// <param name="cases">Symbols cases.</param>
        /// <returns>Randomizer builder.</returns>
        IStringRandomizerBuilder WithSymbolsCases(SymbolCases cases);
    }
}
