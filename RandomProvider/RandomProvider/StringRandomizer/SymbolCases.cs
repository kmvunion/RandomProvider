namespace KMVUnion.RandomProvider.StringRandomizer
{
    public enum SymbolCases
    {
        /// <summary>
        /// Not specified cases. Use symbol cases provided by template
        /// </summary>
        None = 0, 

        /// <summary>
        /// Mixed option includes both lower and upper cases for providing 
        /// </summary>
        Mixed = 1,

        /// <summary>
        /// Lower option provides all symbols in the lower case. 
        /// </summary>
        Lower = 2,

        /// <summary>
        /// Upper option provides all symbols in the upper case. 
        /// </summary>
        Upper = 3
    }
}
