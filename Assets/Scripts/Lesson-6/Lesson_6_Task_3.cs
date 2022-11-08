using System;
using System.Data;
using System.IO;
using UnityEngine;
using UnityRest;

namespace Lesson_6.Task_3
{
    public class Lesson_6_Task_3 : MonoBehaviour
    {
        private const string _path = "Assets/Scripts/Lesson-6/config.json";
        private Factory _factory;

        private void Awake()
        {
            _factory = new Factory();

            Root[] roots = LoadFromJsonFile<Root>(_path);

            foreach (Root root in roots)
            {
                _factory.Create(root.unit.type, root.unit.health);
            }
        }

        private T[] LoadFromJsonFile<T> (string path)
        {
            string json = File.ReadAllText(path);
            T[] value = JsonHelper.FromJson<T>(json);
            return value;
        }
    }

    public class Factory
    {
        private readonly FactoryInfantry _factoryInfantry = new FactoryInfantry();
        private readonly FactoryMag _factoryMag = new FactoryMag();

        public GameUnit Create(string type, string health)
        {
            if (type == FactoryInfantry.type)
            {
                return _factoryInfantry.Create(health);
            }
            else if (type == FactoryMag.type)
            {
                return _factoryMag.Create(health);
            }
            else
            {
                throw new DataException(nameof(Factory) + " does not contain " + type);
            }
        }

        public GameUnit CreateMag(string health)
        {
            GameUnit _unit = _factoryMag.Create(health);
            return _unit;
        }

        public GameUnit CreateInfantry(string health)
        {
            GameUnit _unit = _factoryInfantry.Create(health);
            return _unit;
        }
    }

    public class FactoryInfantry : IFactory
    {
        public static string type = "infantry";

        public GameUnit Create(string health)
        {
            GameUnit _unit = new GameUnit(type, health, new GameObject());
            return _unit;
        }
    }

    public class FactoryMag : IFactory
    {
        public static string type = "mag";

        public GameUnit Create(string health)
        {
            GameUnit _unit = new GameUnit(type, health, new GameObject());
            return _unit;
        }
    }

    public interface IFactory
    {
        GameUnit Create(string health);
    }


    [Serializable]
    public class RootArray
    {
        public Root[] roots;

        public RootArray(Root[] roots)
        {
            this.roots = roots;
        }
    }

    [Serializable] public class Root
    {
        public Unit unit;

        public Root(Unit unit)
        {
            this.unit = unit;
        }
    }

    [Serializable] public class Unit
    {
        public string type;
        public string health;

        public Unit(string type, string health)
        {
            this.type = type;
            this.health = health;
        }
    }

    public class GameUnit
    {
        public readonly string Type;
        public string Health;
        private GameObject _gameObject;

        public GameUnit(string type, string health, GameObject gameObject)
        {
            Type = type;
            Health = health;
            _gameObject = gameObject;
        }
    }
}