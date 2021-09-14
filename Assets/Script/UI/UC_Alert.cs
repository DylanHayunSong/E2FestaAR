using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UC_Alert : UC_BaseComponent
{
    [SerializeField]
    private Image img;
    [SerializeField]
    private Text txt;

    public override void BindDelegates ()
    {
        EventManager.inst.OnAlertAction += AlertOn;
    }

    private void AlertOn (string text)
    {
        gameObject.SetActive(true);
        StartCoroutine(AlertAnim(text));
    }

    private IEnumerator AlertAnim (string text)
    {
        float time = 0;
        float duration = 0.5f;

        txt.text = string.Format("{0}입력해주세요", text);
        Color newImgColor = img.color;
        Color newTxtColor = txt.color;
        float imgColorAlpha;
        float txtColorAlpha;

        while (time <= duration)
        {
            imgColorAlpha = Mathf.Lerp(0, 0.6f, time / duration);
            txtColorAlpha = Mathf.Lerp(0, 1, time / duration);
            newImgColor.a = imgColorAlpha;
            newTxtColor.a = txtColorAlpha;
            img.color = newImgColor;
            txt.color = newTxtColor;

            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSecondsRealtime(duration*2);

        time = 0;

        while (time <= duration)
        {
            imgColorAlpha = Mathf.Lerp(0.6f, 0, time / duration);
            txtColorAlpha = Mathf.Lerp(1, 0, time / duration);
            newImgColor.a = imgColorAlpha;
            newTxtColor.a = txtColorAlpha;
            img.color = newImgColor;
            txt.color = newTxtColor;

            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        gameObject.SetActive(false);
    }
}
