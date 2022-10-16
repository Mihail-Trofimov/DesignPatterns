using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Asteroids
{
    public sealed class PoolServiceLocator
    {
        private static readonly Dictionary<string, Pool<Ammunition>> _serviceŅontainer = new Dictionary<string, Pool<Ammunition>>();

        private static void AddValue(string name, Pool<Ammunition> value)
        {
            _serviceŅontainer.Add(name, value);
        }

        private static Pool<Ammunition> GetValue(string name)
        {
            return _serviceŅontainer[name];
        }

        private static bool Exist(string name)
        {
            if (_serviceŅontainer.ContainsKey(name))
            {
                return true;
            }
            return false;
        }


        public static void Add(string name, Pool<Ammunition> value)
        {
            if(!Exist(name))
            {
                AddValue(name, value);
            }
            else
            {
                throw new DataException(nameof(PoolServiceLocator) + " already contains " + name);
            }
        }

        public static Pool<Ammunition> Get(string name)
        {
            if (Exist(name))
            {
                return GetValue(name);
            }
            else
            {
                throw new DataException(nameof(PoolServiceLocator) + " does not contain " + name);
            }
        }
    }
}