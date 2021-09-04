using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneEventManager : SingletonBehavior<MainSceneEventManager>
{
    [SerializeField]
    private GameObject AR_Objects = null;

    public Action StartArEvent = null;
    public Action OnArSessionActivated = null;
    public Action OnArSessionDeActivated = null;

    [SerializeField]
    private UP_AREvent arEvent = null;

    public void ArSessionOn()
    {
        if(OnArSessionActivated != null)
        {
            OnArSessionActivated.Invoke();
        }

        AR_Objects.SetActive(true);
    }

    public void ArSessionOff()
    {
        if(OnArSessionDeActivated != null)
        {
            OnArSessionDeActivated.Invoke();
        }

        AR_Objects.SetActive(false);
    }
}
