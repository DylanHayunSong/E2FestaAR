using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : SingletonBehavior<EventManager>
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

    public Action OnUserInformationUpdated = null;

    protected override void Awake()
    {
        base.Awake();

        InitializeUI();
    }
    private void InitializeUI()
    {
        UP_BasePage[] uiPages = mainCanvas.GetComponentsInChildren<UP_BasePage>(true);
        foreach(var elem in uiPages)
        {
            elem.BindDelegates();
        }
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
