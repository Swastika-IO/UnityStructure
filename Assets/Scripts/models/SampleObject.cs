using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ref: https://docs.unity3d.com/Manual/JSONSerialization.html

[Serializable]
public class SampleObject  {

    private static SampleObject currentObject;

    public int level;
    public string playerName;

    //public SampleObject GetCurrentObject()
    //{
    //    if(currentObject = null)
    //    {
    //        currentObject = MyDBImpl.GetInstance().GetObject<SampleObject>()
    //    }
    //}
}
