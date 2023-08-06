using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayButtonPro : MonoBehaviour
{
    TextMeshProUGUI textmeshPro;
    public GameObject currentPattern;
    public GameObject playButton;

    public float beatTime;
    public float nextbeatTime;
    public float timesincePlayed;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1; 
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1; 

        if (GameObject.Find("SynthSequencer_1")) {
            GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("SynthSequencer_2")) {
            GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("SynthSequencer_3")) {
            GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("SynthSequencer_4")) {
            GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        }                         

        currentPattern = GameObject.Find("CurrentPattern");     
    }

    // Update is called once per frame
    void Update()
    {
        beatTime = 60f/GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().bpm;
    }

    public void PlaySequencer() {                 
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset(); 
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1; 
        if (GameObject.Find("SynthSequencer_" + 1)) {
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
        }
        if (GameObject.Find("SynthSequencer_" + 2)) {
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
        }
        if (GameObject.Find("SynthSequencer_" + 3)) {
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
        }
        if (GameObject.Find("SynthSequencer_" + 4)) {
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
        }             
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();  
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = false; 

        playButton.GetComponent<Toggle>().enabled = false;
        GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();         
    }  

    public void PlayPattern() {
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset(); 
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();  
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = false;         

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 0) {
            PlaySequencer(); 
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().enabled = false;            
        }

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 1) {
            PlaySequencer();  
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();                        
        }

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 2) {
            StartCoroutine(Loop_2_Bars());
            PlaySequencer();   
        } 

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 3) {
            StartCoroutine(Loop_3_Bars());
            PlaySequencer();  
        } 

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 4) {
            StartCoroutine(Loop_4_Bars());
            PlaySequencer();  
        }        
    }   

    public void StopPattern() {         
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset(); 
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();           

        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;        
        StopAllCoroutines();
        GameObject.Find("Timer").GetComponent<TimerScript>().IsTicking = false;
        GameObject.Find("Timer").GetComponent<TimerScript>().ResetTimer();
        nextbeatTime = 0;
    }

    public IEnumerator Loop_2_Bars() {
        while(true) {
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = true;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString(); 
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();         
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString(); 
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();       
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed);
        } 
    }

    public IEnumerator Loop_3_Bars() {
        while(true) {
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = true;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString(); 
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();         
            yield return new WaitForSeconds(nextbeatTime - Time.timeSinceLevelLoad);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString();
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();        
            yield return new WaitForSeconds(nextbeatTime - Time.timeSinceLevelLoad);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 3.ToString(); 
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();       
            yield return new WaitForSeconds(nextbeatTime - Time.timeSinceLevelLoad);
        }           
    }

    public IEnumerator Loop_4_Bars() {
        while(true) {
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = true;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString();   
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();      
            yield return new WaitForSeconds(nextbeatTime - Time.timeSinceLevelLoad);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString();  
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();      
            yield return new WaitForSeconds(nextbeatTime - Time.timeSinceLevelLoad);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 3.ToString();   
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();     
            yield return new WaitForSeconds(nextbeatTime - Time.timeSinceLevelLoad);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 4.ToString();   
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();     
            yield return new WaitForSeconds(nextbeatTime - Time.timeSinceLevelLoad);                   
        }
    }    
}
