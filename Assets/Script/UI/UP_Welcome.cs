using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UP_Welcome : UP_BasePage, IDragHandler
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

        EventManager.inst.OnCaptureDone += OnCaptureDone;

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
        //gameObject.SetActive(false);
        EventManager.inst.CaptureBtnClicked();
    }

    private void OnCaptureDone()
    {
        gameObject.SetActive(false);
    }

    private void Update ()
    {
        
    }

    public void OnDrag (PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject == animVideo.gameObject)
        {
            if(EventManager.inst.OnDragAnim != null)
            {
                EventManager.inst.OnDragAnim.Invoke(eventData.delta.x * 0.001f);
            }
        }
    }
}
