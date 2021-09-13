using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UP_AREvent : UP_BasePage
{
    [SerializeField]
    private GameObject[] AnimObjs = null;
    [SerializeField]
    private RawImage animVideo = null;
    [SerializeField]
    private Button captureBtn = null;

    private WelcomeAnim welcomeAnim = null;

    public override void BindDelegates ()
    {
        base.BindDelegates();

        EventManager.inst.OnAnimRTUpdated += AnimVideoSetRT;

        welcomeAnim = AnimObjs[(int)Random.Range(0, AnimObjs.Length)].GetComponent<WelcomeAnim>();
        welcomeAnim.gameObject.SetActive(true);
        welcomeAnim.StartAnim();

        EventManager.inst.OnWelcomeAnimDone += OnWelcomeAnimDone;

        captureBtn.onClick.AddListener(OnClick_Capture);
    }

    private void AnimVideoSetRT (RenderTexture rt)
    {
        animVideo.texture = rt;
    }

    private void OnWelcomeAnimDone ()
    {
        captureBtn.gameObject.SetActive(true);
    }

    private void OnClick_Capture ()
    {
        gameObject.SetActive(false);
        EventManager.inst.CaptureBtnClicked();
    }
}
