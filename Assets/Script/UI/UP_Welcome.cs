using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UP_Welcome : UP_BasePage
{
    [SerializeField]
    private RawImage animVideo = null;
    [SerializeField]
    private Button captureBtn = null;

    public override void BindDelegates ()
    {
        base.BindDelegates();

        EventManager.inst.OnAnimRTUpdated += AnimVideoSetRT;

        EventManager.inst.OnWelcomeAnimDone += OnWelcomeAnimDone;

        captureBtn.onClick.AddListener(OnClick_Capture);

        captureBtn.gameObject.SetActive(false);
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
