using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UP_Final : UP_BasePage
{
    [SerializeField]
    private string link;
    [SerializeField]
    private Button hyperLink;

    protected override void Awake ()
    {
        base.Awake();

        MainSceneEventManager.inst.OnCaptureBtnClicked += () => FinalPageActivate(true);
        FinalPageActivate(false);

        hyperLink.onClick.AddListener(() => Application.OpenURL(link));
    }

    private void FinalPageActivate (bool isActivate)
    {
        gameObject.SetActive(isActivate);
    }
}
