using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarStartTop : MonoBehaviour {
 
    public Scrollbar bar;
    public float currentBarValue;

    void Start() {
        currentBarValue = PlayerPrefs.GetFloat("CurrentSynthBarValue ");
    }    

    public void ValueChange() {
        bar = GetComponent<Scrollbar>();
        currentBarValue = bar.value;
        PlayerPrefs.SetFloat("CurrentSynthBarValue ", bar.value);
    }

    public void StartScroll()
    {
        Debug.Log("Now scroll called");
        bar = GetComponent<Scrollbar>();
        currentBarValue = PlayerPrefs.GetFloat("CurrentSynthBarValue ");
        bar.value = currentBarValue;
        Debug.Log("Now scroll set");        
    }
 
}
 
