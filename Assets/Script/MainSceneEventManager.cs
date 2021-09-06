using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneEventManager : SingletonBehavior<MainSceneEventManager>
{
    [SerializeField]
    private Canvas mainCanvas = null;
    [SerializeField]
    private GameObject AR_Objects = null;

    public Action StartArEvent = null;
    public Action OnArSessionActivated = null;
    public Action OnArSessionDeActivated = null;
    public Action OnWelcomeAnimDone = null;
    public Action<RenderTexture> OnAnimRTUpdated = null;
    public Action OnCaptureBtnClicked = null;

    protected override void Init ()
    {
        mainCanvas.gameObject.SetActive(true);
    }

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

    public void AnimRTUpdate(RenderTexture rt)
    {
        if(OnAnimRTUpdated != null)
        {
            OnAnimRTUpdated.Invoke(rt);
        }
    }

    public void CaptureBtnClicked()
    {
        if(OnCaptureBtnClicked != null)
        {
            OnCaptureBtnClicked.Invoke();
        }
    }
}
