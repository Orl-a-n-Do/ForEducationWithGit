using System.Collections.Generic;
using System;

public class ReactiveList<T>
{
    public event Action<T> Added;
    public event Action<T> Removed;


    public List<T> _elements = new List<T>();


    public IReadOnlyList<T> Elements => _elements;


    public virtual void Add(T element)
    {
        _elements.Add(element);
        Added?.Invoke(element);
    }


    public virtual void Remove(T element)
    {
        _elements.Remove(element);
        Removed?.Invoke(element);
    }
    

}
