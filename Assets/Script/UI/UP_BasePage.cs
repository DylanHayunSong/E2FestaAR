using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP_BasePage : MonoBehaviour
{
    private List<UC_BaseComponent> components = new List<UC_BaseComponent>();

    protected virtual void Awake ()
    {
        for(int i = 0; i < transform.childCount; i++)
        {

            if(transform.GetChild(i).GetComponent<UC_BaseComponent>() != null)
            {
                components.Add(transform.GetChild(i).GetComponent<UC_BaseComponent>());
            }
        }

        foreach(UC_BaseComponent compo in components)
        {
            compo.parentPage = this;
            compo.BindDelegates();
        }
    }
}