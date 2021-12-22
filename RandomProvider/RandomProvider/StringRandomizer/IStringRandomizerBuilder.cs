using System.Text.Json;
using System.Text.Json.Nodes;

namespace KMVUnion.RandomProvider.StringRandomizer
{
    /// <summary>
    /// String randomizer builder
    /// </summary>
    public interface IStringRandomizerBuilder : IBaseRandomizer<IStringRandomizer>
    {
        /// <summary>
        /// Set allowed symbols from the array
        /// </summary>
        /// <param name="symbols">Array of the symbols which can be used for generating random string value</param>
        /// <returns>String randomizer builder</returns>
        IStringRandomizerBuilder SetAllowedSymbols(char[] symbols);

        /// <summary>
        /// Set denied symbols from the array
        /// </summary>
        /// <param name="symbols">Array of the symbols which can not be used for generating random string value</param>
        /// <returns></returns>
        IStringRandomizerBuilder SetDeniedSymbols(char[] symbols);

        /// <summary>
        /// Set denied symbols from the string
        /// </summary>
        /// <param name="templateString">String of the symbols which can not be used for generating random string value</param>
        /// <returns>String randomizer builder</returns>
        IStringRandomizerBuilder SetDeniedSymbolsFromString(string templateString);

        /// <summary>
        /// Set allowed symbols from the string
        /// </summary>
        /// <param name="templateString">String of the symbols which can be used for generating random string value</param>
        /// <returns>String randomizer builder</returns>
        IStringRandomizerBuilder SetAllowedSymbolsFromString(string templateString);

        /// <summary>
        /// Set minimal length for generated values. Uses in pair with the MaxLength property 
        /// </summary>
        /// <param name="length">Minimal length</param>
        /// <returns>String randomizer builder</returns>
        IStringRandomizerBuilder WithMinLength(int? length);

        /// <summary>
        /// Set maximal length for generated values. Uses in pair with the MinLength property
        /// </summary>
        /// <param name="length">Maximal length</param>
        /// <returns>String randomizer builder</returns>
        IStringRandomizerBuilder WithMaxLength(int? length);

        /// <summary>
        /// Set exact length for generated values.
        /// </summary>
        /// <param name="length">Exact length</param>
        /// <returns>String randomizer builder</returns>
        IStringRandomizerBuilder WithExactLength(int? length);

        /// <summary>
        /// Set symbols case option for configuration generated values
        /// </summary>
        /// <param name="cases"></param>
        /// <returns>String randomizer builder</returns>
        IStringRandomizerBuilder WithSymbolsCases(SymbolCases cases);

        /// <summary>
        /// Restore string randomizer configuration from json string
        /// </summary>
        /// <param name="jsonString"> Json configuration stored in the string </param>
        /// <param name="options">Json serializer options</param>
        /// <returns>String randomizer builder</returns>
        IStringRandomizerBuilder RestoreFromJSON(string jsonString, JsonSerializerOptions? options = null);

        /// <summary>
        /// Restore string randomizer configuration from json document
        /// </summary>
        /// <param name="document"> Json configuration stored in the Json document</param>
        /// <param name="options">Json serializer options</param>
        /// <returns>String randomizer builder</returns>
        IStringRandomizerBuilder RestoreFromJSON(JsonDocument document, JsonSerializerOptions? options = null);

        /// <summary>
        /// Restore string randomizer configuration from json element
        /// </summary>
        /// <param name="element"> Json configuration stored in the Json element</param>
        /// <param name="options">Json serializer options</param>
        /// <returns>String randomizer builder</returns>
        IStringRandomizerBuilder RestoreFromJSON(JsonElement element, JsonSerializerOptions? options = null);

        /// <summary>
        /// Restore string randomizer configuration from stream
        /// </summary>
        /// <param name="stream"> Json configuration from the stream</param>
        /// <param name="options">Json serializer options</param>
        /// <returns>String randomizer builder</returns>
        IStringRandomizerBuilder RestoreFromJSON(Stream stream, JsonSerializerOptions? options = null);

        /// <summary>
        /// Restore string randomizer configuration from JsonNode
        /// </summary>
        /// <param name="node"> Json configuration stored in the Json node</param>
        /// <param name="options">Json serializer options</param>
        /// <returns>String randomizer builder</returns>
        IStringRandomizerBuilder RestoreFromJSON(JsonNode? node, JsonSerializerOptions? options = null);
    }
}
