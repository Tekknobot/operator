using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RunMode
{    
    public static ApplicationRunMode Current
    {
        get
        {
        #if UNITY_EDITOR
            return Application.isEditor ? ApplicationRunMode.Editor : ApplicationRunMode.Simulator;
        #else
            return ApplicationRunMode.Device;
        #endif
        }
    }
}
 
public enum ApplicationRunMode
{
    Device,
    Editor,
    Simulator
}
