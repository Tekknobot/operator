using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AudioHelm;

public class BPMSlider : MonoBehaviour
{
    Slider mySlider = null;
    TextMeshProUGUI textmeshPro;
 
    // Start is called before the first frame update
    void Start()
    {
        mySlider = GetComponent<Slider>();
        mySlider.value = PlayerPrefs.GetFloat("BPM");
        textmeshPro = GameObject.Find("BPMText").GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        textmeshPro.text = mySlider.value.ToString();
    }
 
    public void UpdateSlider()
    {
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelmClock>().bpm = mySlider.value; 
        PlayerPrefs.SetFloat("BPM", GameObject.Find("AudioHelmClock").GetComponent<AudioHelmClock>().bpm);                       
    }
}
