using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using UnityEngine.UI;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    void Update() {
        if (Camera.main.aspect >= 2.1f) {
            Debug.Log("19:9");
            GameObject.Find("Canvas").GetComponent<CanvasScaler>().matchWidthOrHeight = 0f;
        }        
        else if (Camera.main.aspect >= 1.7f) {
            Debug.Log("16:9");
            GameObject.Find("Canvas").GetComponent<CanvasScaler>().matchWidthOrHeight = 0.138f;
        }
        else if (Camera.main.aspect >= 1.5f) {
            Debug.Log("3:2");
            GameObject.Find("Canvas").GetComponent<CanvasScaler>().matchWidthOrHeight = 0.26f;
        }
        else if (Camera.main.aspect >= 1.3f) {
            Debug.Log("4:3");
            GameObject.Find("Canvas").GetComponent<CanvasScaler>().matchWidthOrHeight = 0.315f;
        }
    }
}