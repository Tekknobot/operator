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
        if (x >= 16) {
            return;
        }        
        GameObject SynthSequencer = GameObject.Instantiate(GameObject.Find("SynthSequencer"), new Vector3(1000, 0, 0), Quaternion.identity);
        SynthSequencer.name = "SynthSequencer_"+ (x+1);
        textmeshPro = GameObject.Find("TotalPatternsText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = (x+1).ToString();       
        x++;
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1; 
        for (int i = 1; i > GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x; i++) {
            GameObject.Find("SynthSequencer_"+ i).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        }
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();         
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
        SynthSequencer.GetComponent<AudioHelm.HelmSequencer>().enabled = false;
        SynthSequencer.GetComponent<AudioHelm.HelmSequencer>().loop = true;
        StartCoroutine(GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().CopyNotesIntoSeq());      
    }

    public void DeleteSynthSequencer() {        
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
            x--; 
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1; 
            for (int i = 1; i > GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x; i++) {
                GameObject.Find("SynthSequencer_"+ x).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
            }
            GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
            GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();         
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
        }                          
    }    
}
