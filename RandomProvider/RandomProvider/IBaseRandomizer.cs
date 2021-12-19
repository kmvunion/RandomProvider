namespace KMVUnion.RandomProvider
{
    public interface IBaseRandomizer<T>
    {
        /// <summary>
        /// Create an instance of the randomizer
        /// </summary>
        /// <returns>Instance of the randomizer</returns>
        T Build();
    }
}
