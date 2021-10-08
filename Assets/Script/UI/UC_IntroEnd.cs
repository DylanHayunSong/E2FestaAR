using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UC_IntroEnd : UC_BaseComponent
{
    [SerializeField]
    private Button btn_intoAR = null;
    [SerializeField]
    private Button btn_InputAgain = null;
    [SerializeField]
    private Text nameInputText = null;
    [SerializeField]
    private Text companyInputText = null;
    [SerializeField]
    private Text contactInputText = null;
    [SerializeField]
    private Text messageInputText = null;

    public Action StartEventAction = null;



    public override void BindDelegates ()
    {
        btn_intoAR.onClick.AddListener(OnClick_StartEvent);
        btn_InputAgain.onClick.AddListener(OnClick_InputAgain);

        EventManager.inst.OnUserDataUpdated += UpdateInputString;
    }

    private void OnClick_StartEvent ()
    {
        if (StartEventAction != null)
        {
            StartEventAction.Invoke();
        }
    }

    private void OnClick_InputAgain()
    {
        if(EventManager.inst.OnResetTextInputs != null)
        {
            EventManager.inst.OnResetTextInputs.Invoke();
        }
    }

    private void UpdateInputString (UserDataManager.UserData newData)
    {
        nameInputText.text = newData.userName;
        companyInputText.text = newData.company;
        contactInputText.text = newData.contact;
        messageInputText.text = newData.message;
    }
}
