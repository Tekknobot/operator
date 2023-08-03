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
    public TextMeshProUGUI textmeshPro;

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
        if (x >= 4) {
            return;
        }        
        GameObject SynthSequencer = GameObject.Instantiate(GameObject.Find("SynthSequencer"), new Vector3(1000, 0, 0), Quaternion.identity);
        SynthSequencer.name = "SynthSequencer_"+ (x+1);
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = (x+1).ToString();       
        x++;
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1; 
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();         
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
        SynthSequencer.GetComponent<AudioHelm.HelmSequencer>().enabled = true;
        SynthSequencer.GetComponent<AudioHelm.HelmSequencer>().loop = true;
        StartCoroutine(GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().CopyNotesIntoSeq());      
    }

    public void DeleteSynthSequencer() {        
        if (x <= 1) {  
            GameObject.Find("SynthSequencer_"+ x).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            x = 1;            
            return; 
        }
        else {           
            temp = GameObject.Find("SynthSequencer_"+ x);
            Destroy(temp);        
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = (x-1).ToString();
            x--; 
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1; 
            GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
            GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();         
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
        }                          
    }    
}
