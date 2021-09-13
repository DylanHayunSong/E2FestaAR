using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UC_InputPopup : UC_BaseComponent
{
    [Serializable]
    private enum InputState { name, company, contact, message, done }
    [SerializeField]
    private InputState inputState = InputState.name;

    [SerializeField]
    private RectTransform nameIcon = null;
    [SerializeField]
    private RectTransform companyIcon = null;
    [SerializeField]
    private RectTransform contactIcon = null;
    [SerializeField]
    private RectTransform messageIcon = null;

    [SerializeField]
    private InputField inputName = null;
    [SerializeField]
    private InputField inputCompany = null;
    [SerializeField]
    private InputField inputContact = null;
    [SerializeField]
    private InputField inputMessage = null;

    [SerializeField]
    private Button nextBtn = null;

    public Action finalBtnClickActin = null;

    [Header("ForAnim")]

    [SerializeField]
    private AnimCurveManager.CurveType enableType = AnimCurveManager.CurveType.outBack;
    [SerializeField]
    private AnimCurveManager.CurveType disableType = AnimCurveManager.CurveType.inOutQuart;

    [SerializeField]
    private float enableDuration = 0.5f;
    [SerializeField]
    private float disableDuration = 0.5f;

    [SerializeField]
    private GameObject scaleObj = null;
    [SerializeField]
    private RawImage blurBG = null;
    [SerializeField]
    private float blurAlphaMax = 0.5f;

    private Coroutine enableAnimCoroutine = null;
    private Coroutine disableAnimCoroutine = null;



    public override void BindDelegates ()
    {
        nextBtn.onClick.AddListener(OnClickNext);

        Init();
    }

    private void Init()
    {
        companyIcon.gameObject.SetActive(false);
        contactIcon.gameObject.SetActive(false);
        messageIcon.gameObject.SetActive(false);
        inputCompany.transform.parent.gameObject.SetActive(false);
        inputContact.transform.parent.gameObject.SetActive(false);
        inputMessage.transform.parent.gameObject.SetActive(false);
    }

    private void OnClickNext ()
    {
        nextBtn.interactable = false;
        switch (inputState)
        {
            case InputState.name:
                StartCoroutine(EnableObjRoutine(companyIcon.gameObject));
                StartCoroutine(EnableObjRoutine(inputCompany.transform.parent.gameObject, true));

                StartCoroutine(DisableObjRoutine(nameIcon.GetComponentInChildren<RawImage>(true)));

                inputState = InputState.company;
                break;
            case InputState.company:
                StartCoroutine(EnableObjRoutine(contactIcon.gameObject));
                StartCoroutine(EnableObjRoutine(inputContact.transform.parent.gameObject, true));

                StartCoroutine(DisableObjRoutine(companyIcon.GetComponentInChildren<RawImage>(true)));

                inputState = InputState.contact;
                break;
            case InputState.contact:
                StartCoroutine(EnableObjRoutine(messageIcon.gameObject));
                StartCoroutine(EnableObjRoutine(inputMessage.transform.parent.gameObject, true));

                StartCoroutine(DisableObjRoutine(contactIcon.GetComponentInChildren<RawImage>(true)));

                inputState = InputState.message;
                break;
            case InputState.message:
                Disable();

                inputState = InputState.done;
                break;
            case InputState.done:
                
                break;
        }
        Invoke("NextBtnEnable", enableDuration);
    }

    private void NextBtnEnable ()
    {
        nextBtn.interactable = true;
    }

    public void Enable ()
    {
        gameObject.SetActive(true);
        enableAnimCoroutine = StartCoroutine(EnableRoutine());
    }

    public void Disable ()
    {
        disableAnimCoroutine = StartCoroutine(DisableRoutine());
    }

    private IEnumerator EnableRoutine ()
    {
        if (disableAnimCoroutine != null)
        {
            yield return new WaitUntil(() => disableAnimCoroutine == null);
        }

        float time = 0;
        float duration = enableDuration;
        Vector3 newScale = Vector3.zero;
        AnimationCurve animCurve = AnimCurveManager.inst.GetCurveType(enableType);
        GameObject obj = scaleObj == null ? gameObject : scaleObj;
        Color newColor = blurBG.color;

        while (time <= duration)
        {
            float animFactor = time / duration;

            newScale = Vector3.LerpUnclamped(Vector3.zero, Vector3.one, animCurve.Evaluate(animFactor));
            newColor.a = Mathf.Lerp(0, blurAlphaMax, animFactor);

            obj.transform.localScale = newScale;
            blurBG.color = newColor;

            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        obj.transform.localScale = Vector3.one;
        newColor.a = blurAlphaMax;
        blurBG.color = newColor;
        enableAnimCoroutine = null;
    }

    private IEnumerator DisableRoutine ()
    {
        if (enableAnimCoroutine != null)
        {
            yield return new WaitUntil(() => enableAnimCoroutine == null);
        }

        float time = 0;
        float duration = disableDuration;
        Vector3 newScale = Vector3.zero;
        AnimationCurve animCurve = AnimCurveManager.inst.GetCurveType(disableType);
        GameObject obj = scaleObj == null ? gameObject : scaleObj;
        Color newColor = blurBG.color;

        while (time <= duration)
        {
            float animFactor = time / duration;

            newScale = Vector3.Lerp(Vector3.one, Vector3.zero, animCurve.Evaluate(time / duration));
            newColor.a = Mathf.Lerp(blurAlphaMax, 0, animFactor);

            obj.transform.localScale = newScale;
            blurBG.color = newColor;

            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        obj.transform.localScale = Vector3.zero;
        newColor.a = 0;
        blurBG.color = newColor;
        disableAnimCoroutine = null;

        gameObject.SetActive(false);
    }

    private IEnumerator EnableObjRoutine (GameObject obj, bool isOnlyY = false)
    {
        float time = 0;
        float duration = enableDuration;
        Vector3 newScale;
        Vector3 startScale = isOnlyY ? obj.transform.localScale - Vector3.up * obj.transform.localScale.y : Vector3.zero;
        AnimationCurve animCurve = AnimCurveManager.inst.GetCurveType(enableType);
        obj.SetActive(true);

        while (time <= duration)
        {
            float animFactor = time / duration;
            newScale = Vector3.LerpUnclamped(startScale, Vector3.one, animCurve.Evaluate(animFactor));

            obj.transform.localScale = newScale;

            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        obj.transform.localScale = Vector3.one;
    }

    private IEnumerator DisableObjRoutine (RawImage obj)
    {
        float time = 0;
        float duration = enableDuration;
        Color newColor = Color.gray;
        obj.gameObject.SetActive(true);

        while (time <= duration)
        {
            float animFactor = time / duration;

            newColor.a = Mathf.Lerp(0, 1, animFactor);
            obj.color = newColor;

            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        obj.color = Color.gray;
    }
}
