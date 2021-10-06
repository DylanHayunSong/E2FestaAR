using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFunctions : MonoBehaviour
{
    public void AnimDone ()
    {
        if (EventManager.inst.OnWelcomeAnimDone != null)
        {
            EventManager.inst.OnWelcomeAnimDone.Invoke();
        }
    }
}
