using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UC_BottomButtons : UC_BaseComponent
{
    [SerializeField]
    private Button infoBtn = null;
    [SerializeField]
    private Button arEventBtn = null;

    public Action InfoBtnClickAction = null;
    public Action arBtnClickAction = null;

    public override void BindDelegates ()
    {
        infoBtn.onClick.AddListener(OnClick_Info);
        arEventBtn.onClick.AddListener(OnClick_AREvent);
    }

    private void OnClick_Info()
    {
        if(InfoBtnClickAction != null)
        {
            InfoBtnClickAction.Invoke();
        }
    }

    private void OnClick_AREvent()
    {
        if(arBtnClickAction != null)
        {
            arBtnClickAction.Invoke();
        }
    }
}
