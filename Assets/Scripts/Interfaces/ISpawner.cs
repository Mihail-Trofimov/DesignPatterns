namespace Asteroids
{
    public interface ISpawner
    {
        void Spawn();

        void DestroyUnit(Unit unit);

    }
}