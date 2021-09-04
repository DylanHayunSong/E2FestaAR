using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UC_Information : UC_BaseComponent
{
    [SerializeField]
    private Button exitBtn = null;
    public override void BindDelegates ()
    {
        exitBtn.onClick.AddListener(OnClick_Exit);
    }

    private void OnClick_Exit()
    {
        gameObject.SetActive(false);
    }
}
