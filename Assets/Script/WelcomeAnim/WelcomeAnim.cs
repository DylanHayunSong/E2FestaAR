using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeAnim : MonoBehaviour
{
    [Serializable]
    private enum AnimState { allOnce, separate}

    [SerializeField]
    private ObjRoot[] roots;
    

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

        //Invoke("AnimDone", 5);
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
        if (EventManager.inst.OnWelcomeAnimDone != null)
        {
            EventManager.inst.OnWelcomeAnimDone.Invoke();
        }
    }

    private void SetAnimCamRT()
    {
        //RenderTexture newRT = new RenderTexture(Screen.width, (int)(Screen.height * 0.8f), 0);

        //animCam.targetTexture = newRT;
        EventManager.inst.AnimRTUpdate(animCam.targetTexture);
    }

    private IEnumerator ShowAnimRoutine()
    {
        float duration = 1;
        float time = 0;
        while(time <= duration)
        {



            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }


    [Serializable]
    private struct ObjRoot
    {
        public GameObject objRoot;
        [SerializeField]
        public AnimState state;
    }
}
