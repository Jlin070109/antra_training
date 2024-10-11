namespace hw3;

using System;
using System.Collections.Generic;

public class MyList<T>
{
    private List<T> _list = new List<T>();

    public void Add(T element)
    {
        _list.Add(element);
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= _list.Count)
            throw new ArgumentOutOfRangeException("Invalid index.");

        T item = _list[index];
        _list.RemoveAt(index);
        return item;
    }

    public bool Contains(T element)
    {
        return _list.Contains(element);
    }

    public void Clear()
    {
        _list.Clear();
    }

    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > _list.Count)
            throw new ArgumentOutOfRangeException("Invalid index.");

        _list.Insert(index, element);
    }

    public void DeleteAt(int index)
    {
        if (index < 0 || index >= _list.Count)
            throw new ArgumentOutOfRangeException("Invalid index.");

        _list.RemoveAt(index);
    }

    public T Find(int index)
    {
        if (index < 0 || index >= _list.Count)
            throw new ArgumentOutOfRangeException("Invalid index.");

        return _list[index];
    }
}
