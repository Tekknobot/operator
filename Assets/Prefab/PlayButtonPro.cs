using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayButtonPro : MonoBehaviour
{
    public float beatsInSec;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1; 
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().currentIndex);
        //Debug.Log(GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().currentIndex);
    }

    public void PlayPattern() {
        if (GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause == false) {
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset(); 
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
            GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
            GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();               
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
            return;
        }

         if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 0) {
            PlaySequencer(); 
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().enabled = true;            
        }

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 1) {
            PlaySequencer(); 
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().enabled = false;            
        }

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 2) {
            PlaySequencer();  
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            StartCoroutine(Loop_2_Bars());
        }         
    }

    public void PlaySequencer() {
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset(); 
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;

        GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
        GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1; 

        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();     
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = false;     
    }     

    IEnumerator Loop_2_Bars() {
        GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = true;  
        GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;   
        yield return new WaitForSeconds((60f/GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().bpm*4));
        Debug.Log("First Wait");
        GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
        GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
        yield return new WaitForSeconds((60f/GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().bpm*4));
        Debug.Log("Second Wait");    
        StartCoroutine(Loop_2_Bars());
    }
}
