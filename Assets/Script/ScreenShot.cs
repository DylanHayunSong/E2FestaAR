using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    private RenderTexture selectedRT;
    public Texture test;

    private void Start ()
    {
        EventManager.inst.OnAnimRTUpdated += (rt) => { selectedRT = rt; };
        EventManager.inst.OnCaptureBtnClicked += () => CaptureScreen(selectedRT);
    }

    public void CaptureScreen (RenderTexture rt)
    {
        TakeScreenshot();
    }

    //private Texture2D toTexture2D (RenderTexture rTex)
    //{
    //    Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
    //    RenderTexture.active = rTex;
    //    tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
    //    tex.Apply();
    //    return tex;
    //}

    private void TakeScreenshot ()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }

    private IEnumerator TakeScreenshotAndSave ()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        byte[] bytes = ss.EncodeToPNG();
        if (EventManager.inst.FileUploadReq != null)
        {
            EventManager.inst.FileUploadReq.Invoke(bytes);
        }

        test = ss;

        // Save the screenshot to Gallery/Photos
        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(ss, "E2FestaAR", "CapturedImage" + System.DateTime.Now.ToString("_MMddHHmm") + ".png", (success, path) => Debug.Log("Media save result: " + success + " " + path));

        Debug.Log("Permission result: " + permission);

        EventManager.inst.CaptureDone();

        //EventManager.inst.OnCustomAlertAction("참가 등록이");

        // To avoid memory leaks
        //Destroy(ss);
    }
}
