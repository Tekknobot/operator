using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AudioHelm;

public class BPMSliderPro : MonoBehaviour
{
    TextMeshProUGUI textmeshPro;
    public float BPMnumber = 120;
 
    // Start is called before the first frame update
    void Awake()
    {
        BPMnumber = PlayerPrefs.GetFloat("BPM");
        if (BPMnumber == 0) {     
            BPMnumber = 120;
        }
        else if (BPMnumber != 0){
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelmClock>().bpm = BPMnumber;
        }
        textmeshPro = GameObject.Find("BPMTextPRO").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = BPMnumber.ToString();
    }

    void Update() {
        
    }

    public void LoadNextBPM () {  
        BPMnumber++;     
        if (BPMnumber >= 240) {
            BPMnumber = 240;
        }            
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelmClock>().bpm = BPMnumber; 
        PlayerPrefs.SetFloat("BPM", GameObject.Find("AudioHelmClock").GetComponent<AudioHelmClock>().bpm);
        textmeshPro.text = BPMnumber.ToString();           
    }    
    
    public void LoadPrevBPM () {  
        BPMnumber--;     
        if (BPMnumber <= 60) {
            BPMnumber = 60;
        }            
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelmClock>().bpm = BPMnumber; 
        PlayerPrefs.SetFloat("BPM", GameObject.Find("AudioHelmClock").GetComponent<AudioHelmClock>().bpm);  
        textmeshPro.text = BPMnumber.ToString();         
    }        

}
