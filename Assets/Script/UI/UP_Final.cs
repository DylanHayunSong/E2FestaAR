using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP_Final : UP_BasePage
{
    protected override void Awake ()
    {
        base.Awake();

        MainSceneEventManager.inst.OnCaptureBtnClicked += () => FinalPageActivate(true);
        FinalPageActivate(false);
    }

    private void FinalPageActivate (bool isActivate)
    {
        gameObject.SetActive(isActivate);
    }
}
