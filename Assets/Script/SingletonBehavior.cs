using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehavior<T> : MonoBehaviour where T : SingletonBehavior<T>
{
    public static T inst = null;
    protected void Awake ()
    {
        if(inst != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            inst = (T)this;
            DontDestroyOnLoad(this.gameObject);

            Init();
        } 
    }

    protected virtual void Init()
    {

    }
}
