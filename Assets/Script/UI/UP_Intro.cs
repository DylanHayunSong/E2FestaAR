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
    

    public override void BindDelegates ()
    {
        base.BindDelegates();

        startEvent.StartEventAction += StartEvent;

        Init();
    }

    private void Init()
    {
        inputPopup.gameObject.SetActive(false);
    }

    private void StartEvent()
    {
        //startEvent.gameObject.SetActive(false);
        inputPopup.Enable();
    }
}
