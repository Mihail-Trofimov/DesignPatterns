namespace Asteroids
{
    public sealed class GameLoopSingleton
    {
        private static readonly GameLoop _gameLoop = Factory.Create<GameLoop>(Constant.PREFAB_GAME_LOOP);

        public static void AddExecute(IExecute _execute)
        {
            _gameLoop.AddExecute(_execute);
        }

        public static void RemoveExecute(IExecute _execute)
        {
            _gameLoop.RemoveExecute(_execute);
        }

        public static void AddFixExecute(IFixExecute _execute)
        {
            _gameLoop.AddFixExecute(_execute);
        }

        public static void RemoveFixExecute(IFixExecute _execute)
        {
            _gameLoop.RemoveFixExecute(_execute);
        }

    }
}