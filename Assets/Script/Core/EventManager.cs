using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : SingletonBehavior<EventManager>
{
    [SerializeField]
    private Canvas mainCanvas = null;
    [SerializeField]
    private GameObject AR_Objects = null;
    [SerializeField]
    private GameObject[] AnimObjs = null;
    [SerializeField]
    private WelcomeAnim welcomeAnim = null;
    [SerializeField]
    private UC_Alert alertComponent = null;

    public Action StartArEvent = null;
    public Action OnArSessionActivated = null;
    public Action OnArSessionDeActivated = null;
    public Action OnWelcomeAnimDone = null;
    public Action<RenderTexture> OnAnimRTUpdated = null;
    public Action OnCaptureBtnClicked = null;
    public Action OnCaptureDone = null;
    public Action<string> OnAlertAction;
    public Action<string> OnCustomAlertAction;
    public Action<byte[]> FileUploadReq;

    public Action<UserDataManager.UserData> OnUserDataUpdated = null;

    public Action<string> OnNameTextChanged = null;
    public Action<string> OnWelcomeTextChanged = null;

    protected override void Awake()
    {
        base.Awake();

        AR_Objects.gameObject.SetActive(false);
        InitializeUI();
    }
    private void InitializeUI()
    {
        UP_BasePage[] uiPages = mainCanvas.GetComponentsInChildren<UP_BasePage>(true);
        foreach(var elem in uiPages)
        {
            elem.BindDelegates();
        }

        alertComponent.BindDelegates();

        mainCanvas.transform.GetChild(0).gameObject.SetActive(true);
        mainCanvas.transform.GetChild(1).gameObject.SetActive(false);
        mainCanvas.transform.GetChild(2).gameObject.SetActive(false);
        mainCanvas.transform.GetChild(3).gameObject.SetActive(false);
        alertComponent.gameObject.SetActive(false);
    }

    public void Alert(string text)
    {
        if(OnAlertAction != null)
        {
            OnAlertAction.Invoke(text);
        }
    }

    public void ArSessionOn()
    {
        if(OnArSessionActivated != null)
        {
            OnArSessionActivated.Invoke();
        }
#if UNITY_STANDALONE_WIN
        StartWelcomeAnim();
        mainCanvas.transform.GetChild(2).gameObject.SetActive(true);
#else
        mainCanvas.transform.GetChild(1).gameObject.SetActive(true);
#endif


        AR_Objects.SetActive(true);
    }

    public void ArSessionOff()
    {
        if(OnArSessionDeActivated != null)
        {
            OnArSessionDeActivated.Invoke();
        }
        mainCanvas.transform.GetChild(1).gameObject.SetActive(false);

        AR_Objects.SetActive(false);
    }

    public void StartWelcomeAnim()
    {
        welcomeAnim = AnimObjs[(int)UnityEngine.Random.Range(0, AnimObjs.Length)].GetComponent<WelcomeAnim>();
        welcomeAnim.gameObject.SetActive(true);
        welcomeAnim.StartAnim();
    }


    public void AnimRTUpdate(RenderTexture rt)
    {
        if(OnAnimRTUpdated != null)
        {
            OnAnimRTUpdated.Invoke(rt);
        }
    }

    public void CaptureBtnClicked()
    {
        if(OnCaptureBtnClicked != null)
        {
            OnCaptureBtnClicked.Invoke();
        }
    }

    public void CaptureDone()
    {
        if(OnCaptureDone != null)
        {
            OnCaptureDone.Invoke();
        }
    }
}
