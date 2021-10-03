using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UP_Intro : UP_BasePage
{
    [SerializeField]
    private VideoPlayer video;
    [SerializeField]
    private UC_StartEventComponent startEvent;
    [SerializeField]
    private UC_InputPopup inputPopup;
    [SerializeField]
    private UC_IntroEnd startAR;

    public Action OnClickStartAR;

    private bool isVideoStarted = false;

    public override void BindDelegates ()
    {
        base.BindDelegates();

        startEvent.StartEventAction += StartEvent;
        inputPopup.finalBtnClickActin += EndInput;
        startAR.StartEventAction += StartAR;

        Init();
    }

    private void Update ()
    {
        if(!isVideoStarted)
        {
            VideoStartCheck();
        }

        if(video.gameObject.activeInHierarchy)
        {
            VideoDoneCheck();
        }
    }

    private void Init()
    {
        inputPopup.gameObject.SetActive(false);
        startAR.gameObject.SetActive(false);
        video.Play();
    }

    private void VideoStartCheck()
    {
        if(video.isPlaying)
        {
            isVideoStarted = true;
        }
    }

    private void VideoDoneCheck()
    {
       if(!video.isPlaying && isVideoStarted)
        {
            video.gameObject.SetActive(false);
        }
    }

    private void StartEvent()
    {
        //startEvent.gameObject.SetActive(false);
        inputPopup.Enable();
    }

    private void EndInput()
    {
        startEvent.gameObject.SetActive(false);
        startAR.gameObject.SetActive(true);
    }

    private void StartAR()
    {
        gameObject.SetActive(false);
        EventManager.inst.ArSessionOn();
    }
}
