using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeAnim : MonoBehaviour
{
    [SerializeField]
    private Camera animCam = null;
    [SerializeField]
    private Text welcomeText = null;
    [SerializeField]
    private Text nameText = null;

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

        Invoke("AnimDone", 5);
    }

    public void SetWelcomeText (string text)
    {
        welcomeText.text = text;
    }

    public void SetNameText (string text)
    {
        nameText.text = text;
    }

    public void AnimDone()
    {
        if (MainSceneEventManager.inst.OnWelcomeAnimDone != null)
        {
            MainSceneEventManager.inst.OnWelcomeAnimDone.Invoke();
        }
    }

    private void SetAnimCamRT()
    {
        //RenderTexture newRT = new RenderTexture(Screen.width, (int)(Screen.height * 0.8f), 0);
        //animCam.targetTexture = newRT;
        animCam.targetTexture.width = Screen.width;
        animCam.targetTexture.height = (int)(Screen.height * 0.8f);
        MainSceneEventManager.inst.AnimRTUpdate(animCam.targetTexture);
    }
}
