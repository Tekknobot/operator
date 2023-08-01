using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using UnityEngine.UI;
using TMPro;

public class DuplicateSynthSequencerScript : MonoBehaviour
{
    public int x = 0;
    public GameObject temp;
    TextMeshProUGUI textmeshPro;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DuplicateSynthSequencer() {
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true; 
        GameObject.Find("Play").GetComponent<Toggle>().isOn = false;
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset(); 
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        if (x >= 16) {
            return;
        }
        GameObject SynthSequencer = GameObject.Instantiate(GameObject.Find("SynthSequencer"), new Vector3(1000, 0, 0), Quaternion.identity);
        SynthSequencer.name = "SynthSequencer_"+ (x+1);
        SynthSequencer.GetComponent<AudioHelm.HelmSequencer>().enabled = true;
        SynthSequencer.GetComponent<AudioHelm.HelmSequencer>().loop = true;
        textmeshPro = GameObject.Find("TotalPatternsText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = (x+1).ToString(); 
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = (x+1).ToString();        
        x++;
    }

    public void DeleteSynthSequencer() {
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true; 
        GameObject.Find("Play").GetComponent<Toggle>().isOn = false;
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset(); 
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        if (x <= 0) {  
            temp = GameObject.Find("SynthSequencer_"+ x);
            Destroy(temp);
            x = 0;            
            return; 
        }
        else {           
            temp = GameObject.Find("SynthSequencer_"+ x);
            Destroy(temp);        
            textmeshPro = GameObject.Find("TotalPatternsText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = (x-1).ToString();
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = (x-1).ToString();
            x--; 
        }                  
    }    
}
