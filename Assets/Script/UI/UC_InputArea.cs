using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UC_InputArea : UC_BaseComponent
{
    [SerializeField]
    private InputField inp_name;
    [SerializeField]
    private InputField inp_company;
    [SerializeField]
    private InputField inp_phoneFirst;
    [SerializeField]
    private InputField inp_phoneMiddle;
    [SerializeField]
    private InputField inp_phoneEnd;
    [SerializeField]
    private InputField inp_message;

    public override void BindDelegates ()
    {

    }
}
