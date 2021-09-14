using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UP_Intro : UP_BasePage
{
    [SerializeField]
    private UC_StartEventComponent startEvent;
    [SerializeField]
    private UC_InputPopup inputPopup;
    [SerializeField]
    private UC_StartEventComponent startAR;

    public Action OnClickStartAR;

    public override void BindDelegates ()
    {
        base.BindDelegates();

        startEvent.StartEventAction += StartEvent;
        inputPopup.finalBtnClickActin += EndInput;
        startAR.StartEventAction += StartAR;

        Init();
    }

    private void Init()
    {
        inputPopup.gameObject.SetActive(false);
        startAR.gameObject.SetActive(false);
    }

    private void StartEvent()
    {
        //startEvent.gameObject.SetActive(false);
        inputPopup.Enable();
    }

    private void EndInput()
    {
        startEvent.gameObject.SetActive(false);
        startAR.gameObject.SetActive(true);
    }

    private void StartAR()
    {
        gameObject.SetActive(false);
        EventManager.inst.ArSessionOn();
    }
}
