using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UC_BasePopUp : UC_BaseComponent
{
    private Coroutine enableAnimCoroutine = null;
    private Coroutine disableAnimCoroutine = null;

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

    private void Update ()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Enable();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Disable();
        }
    }

    public override abstract void BindDelegates ();

    public void Enable ()
    {
        gameObject.SetActive(true);
        enableAnimCoroutine = StartCoroutine(EnableRoutine());
    }

    public void Disable ()
    {
        disableAnimCoroutine = StartCoroutine(DisableRoutine());
    }

    IEnumerator EnableRoutine ()
    {
        if(disableAnimCoroutine != null)
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

    IEnumerator DisableRoutine ()
    {
        if(enableAnimCoroutine != null)
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
}
