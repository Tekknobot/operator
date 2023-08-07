using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AudioHelm;

public class PlayButtonPro : MonoBehaviour
{
    TextMeshProUGUI textmeshPro;
    public GameObject currentPattern;
    public GameObject playButton;

    public float beatTime;
    public float nextbeatTime;
    public float timesincePlayed;

    public int currenStep;
    public int currentstepIndex;
    public int nextstepIndex;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;                      
        currentPattern = GameObject.Find("CurrentPattern");     
    }

    // Update is called once per frame
    void Update()
    {
        beatTime = 60/GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().bpm;
        currenStep = GameObject.Find("SynthSequencer").GetComponent<HelmSequencer>().currentIndex;
    } 

    public void PlayPattern() {
        nextbeatTime = 0;
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
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
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();  
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = false;         

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 1) {
            StartCoroutine(Loop_1_Bars());                         
        }

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 2) {
            StartCoroutine(Loop_2_Bars());   
        } 

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 3) {
            StartCoroutine(Loop_3_Bars());  
        } 

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 4) {
            StartCoroutine(Loop_4_Bars()); 
        }    
        GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();
        PlaySequencer();    
    }   

    public void PlaySequencer() {                 
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = false;
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
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();   
        playButton.GetComponent<Toggle>().enabled = false;         
    }     

    public void StopPattern() {         
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();           

        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;  
        GameObject.Find("Timer").GetComponent<TimerScript>().ResetTimer(); 
        GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>();     
        StopAllCoroutines();
    }

    public IEnumerator Loop_1_Bars() {
        while(true) {
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString(); 
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();         
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed);
        } 
    }

    public IEnumerator Loop_2_Bars() {
        while(true) {
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = true;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString(); 
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();         
            yield return new WaitUntil(()=> GameObject.Find("SynthSequencer").GetComponent<HelmSequencer>().currentIndex == 15);
            currentstepIndex = 0;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString(); 
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();     
            yield return new WaitUntil(()=> GameObject.Find("SynthSequencer").GetComponent<HelmSequencer>().currentIndex == 15);
            currentstepIndex = 0;
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
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString();
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();        
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 3.ToString(); 
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();       
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed);
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
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString();  
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();      
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 3.ToString();   
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();     
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 4.ToString();   
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();     
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed);                   
        }
    }    
}
