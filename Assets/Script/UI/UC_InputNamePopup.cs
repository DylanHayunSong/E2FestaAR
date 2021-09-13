using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UC_InputNamePopup : UC_BasePopUp
{
    [SerializeField]
    private Button nextBtn = null;

    public Action nextBtnClickAction = null;

    public override void BindDelegates ()
    {
        print("Hello");

        nextBtn.onClick.AddListener(OnClickNext);
    }

    private void OnClickNext()
    {
        if(nextBtnClickAction != null)
        {
            nextBtnClickAction.Invoke();
        }
    }
}
