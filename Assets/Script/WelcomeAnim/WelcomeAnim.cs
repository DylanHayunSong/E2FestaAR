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
    private Text welcomeText;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private GameObject rotateBone;

    private Vector3 leftEular = new Vector3(-8.358f, -26.46f, -11.691f);
    private Vector3 originEular = new Vector3(4.471f, 13.382f, -13.085f);
    private Vector3 rightEular = new Vector3(13.07f, 45.177f, -8.148f);

    public float currentEular = 0;

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
        SetNameText(UserDataManager.inst.GetUserData().company + " " + UserDataManager.inst.GetUserData().userName);


        EventManager.inst.OnWelcomeAnimDone += () => { EventManager.inst.OnDragAnim += SetEular; };
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

    public void ResetText ()
    {
        SetWelcomeText(UserDataManager.inst.GetUserData().message);
        SetNameText(UserDataManager.inst.GetUserData().userName);
        WelcomeTextOn();
        NameTextOn();
    }

    private void SetEular (float newFloat)
    {
        currentEular += newFloat;
        currentEular = Mathf.Clamp(currentEular, -1, 1);
        if (currentEular <= 0)
        {
            rotateBone.transform.localEulerAngles = Vector3.Lerp(originEular, leftEular, -currentEular);
        }
        else
        {
            rotateBone.transform.localEulerAngles = Vector3.Lerp(originEular, rightEular, currentEular);
        }
    }
}
