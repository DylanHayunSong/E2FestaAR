using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP_Main : UP_BasePage
{
    [SerializeField]
    private UC_TitleArea titleAreaCompo;
    [SerializeField]
    private UC_InputArea inputAreaCompo;
    [SerializeField]
    private UC_BottomButtons buttonsCompo;
    [SerializeField]
    private UC_Information infoCompo;

    protected override void Awake ()
    {
        base.Awake();

        buttonsCompo.InfoBtnClickAction += OnClick_InfoBtn;
        buttonsCompo.arBtnClickAction += OnClick_AREventBtn;
        MainSceneEventManager.inst.OnArSessionActivated += () => { gameObject.SetActive(false); };
    }

    private void OnClick_InfoBtn()
    {
        infoCompo.gameObject.SetActive(true);
    }

    private void OnClick_AREventBtn()
    {
        MainSceneEventManager.inst.ArSessionOn();
        gameObject.SetActive(false);
    }
}