using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UC_StartEventComponent : UC_BaseComponent
{
    [SerializeField]
    private Button btn_intoAR;

    public Action StartEventAction;

    public override void BindDelegates ()
    {
        btn_intoAR.onClick.AddListener(OnClick_StartEvent);
    }

    private void OnClick_StartEvent()
    {
        if(StartEventAction != null)
        {
            StartEventAction.Invoke();
        }
    }
}
