using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCurveManager : SingletonBehavior<AnimCurveManager>
{
    public enum CurveType { linear, inSine, outSine, inOutSine, inQuart, outQuart, inOutQuart, outBack, outBounce}

    [SerializeField]
    public AnimationCurve linear;
    [SerializeField]
    public AnimationCurve inSine;
    [SerializeField]
    public AnimationCurve outSine;
    [SerializeField]
    public AnimationCurve inOutSine;
    [SerializeField]
    public AnimationCurve inQuart;
    [SerializeField]
    public AnimationCurve outQuart;
    [SerializeField]
    public AnimationCurve inOutQuart;
    [SerializeField]
    public AnimationCurve outBack;
    [SerializeField]
    public AnimationCurve outBounce;

    public AnimationCurve GetCurveType(CurveType curveType)
    {
        switch (curveType)
        {
            default:
                return linear;
            case CurveType.linear:
                return linear;
            case CurveType.outSine:
                return outSine;
            case CurveType.inOutSine:
                return inOutSine;
            case CurveType.inQuart:
                return inQuart;
            case CurveType.outQuart:
                return outQuart;
            case CurveType.inOutQuart:
                return inOutQuart;
            case CurveType.outBack:
                return outBack;
            case CurveType.outBounce:
                return outBounce;
        }
    }
}
