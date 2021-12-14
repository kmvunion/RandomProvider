namespace KMVUnion.RandomProvider
{
    public interface IBaseRandomizer<T>
    {
        T Build();
    }
}
