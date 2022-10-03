using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop: IExecute
{
    private List<IExecute> _listExecutes = new List<IExecute>();

    public void Add(IExecute _execute)
    {
        if (!_listExecutes.Contains(_execute))
        {
            _listExecutes.Add(_execute);
        }
    }

    public void Remove(IExecute _execute)
    {
        if(_listExecutes.Contains(_execute))
        {
            _listExecutes.Remove(_execute);
        }
    }

    public void Execute()
    {
        for(int i = 0; i < _listExecutes.Count; i++)
        {
            _listExecutes[i].Execute();
        }
    }

}
