using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneEventManager : SingletonBehavior<MainSceneEventManager>
{
    [SerializeField]
    private GameObject AR_Objects = null;

    public Action StartArEvent = null;
    public Action<bool> AR_SetActiveAction = null;

    public void SetAR_Active(bool isActive)
    {
        AR_Objects.gameObject.SetActive(isActive);

        if(AR_SetActiveAction != null)
        {
            AR_SetActiveAction.Invoke(isActive);
        }
    }
}
