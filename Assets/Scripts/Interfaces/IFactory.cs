namespace Asteroids
{
    public interface IFactory<T>
    {
        T Create(string path);
        T Create(T prefab);
    }
}