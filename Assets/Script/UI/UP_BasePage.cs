using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP_BasePage : MonoBehaviour
{
    public virtual void BindDelegates()
    {
        UC_BaseComponent[] children = transform.GetComponentsInChildren<UC_BaseComponent>(true);
        foreach(UC_BaseComponent elem in children)
        {
            elem.parentPage = this;
            elem.BindDelegates();
        }
    }
}