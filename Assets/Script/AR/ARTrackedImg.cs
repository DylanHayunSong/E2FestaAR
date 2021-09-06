using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ARTrackedImg : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    [SerializeField]
    private GameObject toActiveObj;

    private void Awake ()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        toActiveObj.SetActive(true);
        MainSceneEventManager.inst.ArSessionOff();
    }
}
