using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameLoop : MonoBehaviour
    {
        private readonly List<IExecute> _listExecutes = new List<IExecute>();
        private readonly List<IFixExecute> _listFixExecutes = new List<IFixExecute>();

        public void AddExecute(IExecute _execute)
        {
            if (!_listExecutes.Contains(_execute))
            {
                _listExecutes.Add(_execute);
            }
        }

        public void RemoveExecute(IExecute _execute)
        {
            if (_listExecutes.Contains(_execute))
            {
                _listExecutes.Remove(_execute);
            }
        }

        public void AddFixExecute(IFixExecute _execute)
        {
            if (!_listFixExecutes.Contains(_execute))
            {
                _listFixExecutes.Add(_execute);
            }
        }

        public void RemoveFixExecute(IFixExecute _execute)
        {
            if (_listFixExecutes.Contains(_execute))
            {
                _listFixExecutes.Remove(_execute);
            }
        }

        public void Update()
        {
            for (int i = 0; i < _listExecutes.Count; i++)
            {
                _listExecutes[i].Execute();
            }
        }

        public void FixedUpdate()
        {
            for (int i = 0; i < _listFixExecutes.Count; i++)
            {
                _listFixExecutes[i].FixExecute();
            }
        }

    }
}