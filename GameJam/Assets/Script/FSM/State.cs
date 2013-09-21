using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class State<T> 
{
    //public bool use = true;
    abstract public bool Enter(T entity);
    abstract public bool Execute(T entity);
    abstract public bool Exit(T entity);
}
