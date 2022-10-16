using UnityEngine;

namespace Asteroids
{
    public sealed class GameStart : MonoBehaviour
    {
        private void Awake()
        {
            Ammunition prefabBlasterPlayer = Resources.Load<Ammunition>(Constant.PREFAB_AMMUNITION_PLAYER_BLASTER);
            //Ammunition prefabBlasterPlayer = BuilderFactory.BuidBlaster;
            const int defaultPoolSize = 20;
            const int maxPoolSize = 30;
            Pool<Ammunition> ammunitionPool = new Pool<Ammunition>(Constant.NAME_POOL_PLAYER_BLASTER, prefabBlasterPlayer, defaultPoolSize, maxPoolSize);

            PoolServiceLocator.Add(Constant.NAME_POOL_PLAYER_BLASTER, ammunitionPool);

            Reference reference = new Reference();
            Player player = reference.Player;
            Camera camera = reference.MainCamera;
            InputController input = new InputController(player, camera);
            AsteroidSpawn spawner = reference.SpawnerAsteroid;
            GameController gameController = new GameController(player);

            GameLoopSingleton.AddExecute(spawner);
            GameLoopSingleton.AddExecute(input);
            GameLoopSingleton.AddFixExecute(input);
            GameLoopSingleton.AddExecute(player);

            ServiceLocator.SetService<IService>(new Service());

        }

        private void Start()
        {
            ServiceLocator.Resolve<IService>().Test();
        }
    }
}