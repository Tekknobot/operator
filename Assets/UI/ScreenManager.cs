using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    static public ScreenManager SM { get; set; }
    
    void Update() {
        
    }

    private void Awake()
    {
        SM = this;
    }

    public float getScreenHeight()
    {
        return Camera.main.orthographicSize * 2.0f;

    }
    public float getScreenWidth()
    {
        return getScreenHeight() * Screen.width / Screen.height;
    }

}