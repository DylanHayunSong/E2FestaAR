using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UP_Final : UP_BasePage
{
    [SerializeField]
    private Button GoSiteBtn;
    [SerializeField]
    private Button exitAppBtn;

    public override void BindDelegates ()
    {
        base.BindDelegates();

        gameObject.SetActive(false);

        EventManager.inst.OnCaptureBtnClicked += () => { gameObject.SetActive(true); };

        GoSiteBtn.onClick.AddListener(OnClickGoSite);
        exitAppBtn.onClick.AddListener(OnClickExitApp);
    }

    private void OnClickGoSite()
    {
        Application.OpenURL("http://e2festa.kr/");
    }

    private void OnClickExitApp()
    {
        Application.Quit();
    }


}
