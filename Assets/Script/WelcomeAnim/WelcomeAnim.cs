using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeAnim : MonoBehaviour
{
    [SerializeField]
    private Camera animCam = null;
    [SerializeField]
    private TextMeshProUGUI welcomeText;
    [SerializeField]
    private TextMeshProUGUI nameText;

    private Camera originalMainCamera = null;

    private void Awake ()
    {
        originalMainCamera = Camera.main;
    }

    public void StartAnim ()
    {
        Debug.Log("anim started!");

        //originalMainCamera.gameObject.SetActive(false);
        SetAnimCamRT();

        //Invoke("AnimDone", 5);

        SetWelcomeText(UserDataManager.inst.GetUserData().message);
        SetNameText(UserDataManager.inst.GetUserData().userName);

    }

    public void SetWelcomeText (string text)
    {
        if (welcomeText != null)
            welcomeText.text = text;
    }

    public void SetNameText (string text)
    {
        if (nameText != null)
            nameText.text = text;
    }

    public void AnimDone ()
    {
        if (EventManager.inst.OnWelcomeAnimDone != null)
        {
            EventManager.inst.OnWelcomeAnimDone.Invoke();
        }
    }

    private void SetAnimCamRT ()
    {
        //RenderTexture newRT = new RenderTexture(Screen.width, (int)(Screen.height * 0.8f), 0);

        //animCam.targetTexture = newRT;
        EventManager.inst.AnimRTUpdate(animCam.targetTexture);
    }

    public void WelcomeTextOn ()
    {
        if (welcomeText != null)
            welcomeText.gameObject.SetActive(true);
    }

    public void NameTextOn ()
    {
        if (nameText != null)
            nameText.gameObject.SetActive(true);
    }

    public void ResetText()
    {
        SetWelcomeText(UserDataManager.inst.GetUserData().message);
        SetNameText(UserDataManager.inst.GetUserData().userName);
    }
}
