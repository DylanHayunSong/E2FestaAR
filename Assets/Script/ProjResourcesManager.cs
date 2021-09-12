using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjResourcesManager : SingletonBehavior<ProjResourcesManager>
{
    public Color bgColor;
    public Texture btnImg;
    public Texture inputImg;
    public Texture areaImg;

    public ProjResources[] resources;
    


}

public struct ProjResources
{
    public Color bgColor;
    public Texture btnImg;
    public Texture imputIng;
    public Texture areaImg;
}
