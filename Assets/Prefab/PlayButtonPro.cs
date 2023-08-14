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
    public float nextbeatTimeDrum;
    public float nextbeatTimeSample;
    public float timesincePlayed;

    public int currentStep;
    public int maxCount = 15;
    public int nextstepIndex;
    public bool flag;

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
        currentStep = GameObject.Find("SynthSequencer").GetComponent<HelmSequencer>().currentIndex;
        timesincePlayed = GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed;     
    }

    public void PlayPattern() {
        nextbeatTime = 0;
        nextbeatTimeDrum = 0;
        nextbeatTimeSample = 0;
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();  
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = false;

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

        //////////

        if (GameObject.Find("DrumSampler_1")) {
            GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("DrumSampler_1")) {
            GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("DrumSampler_1")) {
            GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("DrumSampler_1")) {
            GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        }  

        //////////

        if (GameObject.Find("SampleSequencer_1")) {
            GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("SampleSequencer_1")) {
            GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("SampleSequencer_1")) {
            GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("SampleSequencer_1")) {
            GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        }          

        //////////         

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 1) {
            GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();
            StartCoroutine(Loop_1_Bars());                         
        }

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 2) {
            GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();
            StartCoroutine(Loop_2_Bars());   
        } 

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 3) {
            GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();
            StartCoroutine(Loop_3_Bars());  
        } 

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 4) {
            GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();
            StartCoroutine(Loop_4_Bars()); 
        }

        /////////

        if (GameObject.Find("AddPattern_Drum").GetComponent<DuplicateSynthSequencerScript>().y == 1) {
            GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();
            StartCoroutine(Loop_1_Bars_Drum());                         
        }

        if (GameObject.Find("AddPattern_Drum").GetComponent<DuplicateSynthSequencerScript>().y == 2) {
            GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();
            StartCoroutine(Loop_2_Bars_Drum());   
        } 

        if (GameObject.Find("AddPattern_Drum").GetComponent<DuplicateSynthSequencerScript>().y == 3) {
            GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();
            StartCoroutine(Loop_3_Bars_Drum());  
        } 

        if (GameObject.Find("AddPattern_Drum").GetComponent<DuplicateSynthSequencerScript>().y == 4) {
            GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();
            StartCoroutine(Loop_4_Bars_Drum()); 
        }

        /////////

        if (GameObject.Find("AddPattern_Sample").GetComponent<DuplicateSynthSequencerScript>().z == 1) {
            GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();
            StartCoroutine(Loop_1_Bars_Sample());                         
        }

        if (GameObject.Find("AddPattern_Sample").GetComponent<DuplicateSynthSequencerScript>().z == 2) {
            GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();
            StartCoroutine(Loop_2_Bars_Sample());   
        } 

        if (GameObject.Find("AddPattern_Sample").GetComponent<DuplicateSynthSequencerScript>().z == 3) {
            GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();
            StartCoroutine(Loop_3_Bars_Sample());  
        } 

        if (GameObject.Find("AddPattern_Sample").GetComponent<DuplicateSynthSequencerScript>().z == 4) {
            GameObject.Find("Timer").GetComponent<TimerScript>().StartTimer();
            StartCoroutine(Loop_4_Bars_Sample()); 
        }        

        PlaySequencer();    
    }   

    public void PlaySequencer() {                 
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = false;
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1; 
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();   
        playButton.GetComponent<Toggle>().enabled = false; 
                
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

        ////////

        if (GameObject.Find("DrumSampler_1")) {
            GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("DrumSampler_2")) {
            GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("DrumSampler_3")) {
            GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("DrumSampler_4")) {
            GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        }      

        ////////

        if (GameObject.Find("SampleSequencer_1")) {
            GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("SampleSequencer_2")) {
            GameObject.Find("SampleSequencer_2").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("SampleSequencer_3")) {
            GameObject.Find("SampleSequencer_3").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        } 
        if (GameObject.Find("SampleSequencer_4")) {
            GameObject.Find("SampleSequencer_4").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        }                         
    }     

    public void StopPattern() {         
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();           

        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;  
        GameObject.Find("Timer").GetComponent<TimerScript>().ResetTimer(); 
        GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>();
        nextbeatTime = 0;
        nextbeatTimeDrum = 0; 
        nextbeatTimeSample = 0;    
        StopAllCoroutines();
    }

    public IEnumerator Loop_1_Bars() {
        while(true) {
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString(); 
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();         
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
        } 
    }

    public IEnumerator Loop_2_Bars() {
        while(true) {      
            nextbeatTime += beatTime*4;     
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = true;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString(); 
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();                    
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTime += beatTime*4;           
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString(); 
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();           
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
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
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString();
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();        
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 3.ToString(); 
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();       
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
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
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString();  
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();      
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 3.ToString();   
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();     
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTime += beatTime*4;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 4.ToString();   
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying();     
            yield return new WaitForSeconds(nextbeatTime - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);                   
        }
    }    


    public IEnumerator Loop_1_Bars_Drum() {
        while(true) {
            nextbeatTimeDrum += beatTime*4;
            GameObject.Find("DrumSampler_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText_Drum").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString(); 
            GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Drum();         
            yield return new WaitForSeconds(nextbeatTimeDrum - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
        } 
    }

    public IEnumerator Loop_2_Bars_Drum() {
        while(true) {      
            nextbeatTimeDrum += beatTime*4;     
            GameObject.Find("DrumSampler_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = true;  
            GameObject.Find("DrumSampler_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText_Drum").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString(); 
            GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Drum();                    
            yield return new WaitForSeconds(nextbeatTimeDrum - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTimeDrum += beatTime*4;           
            GameObject.Find("DrumSampler_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = false;  
            GameObject.Find("DrumSampler_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText_Drum").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString(); 
            GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Drum();           
            yield return new WaitForSeconds(nextbeatTimeDrum - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
        } 
    }

    public IEnumerator Loop_3_Bars_Drum() {
        while(true) {
            nextbeatTimeDrum += beatTime*4;
            GameObject.Find("DrumSampler_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = true;  
            GameObject.Find("DrumSampler_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            GameObject.Find("DrumSampler_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText_Drum").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString();
            GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Drum();         
            yield return new WaitForSeconds(nextbeatTimeDrum - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTimeDrum += beatTime*4;
            GameObject.Find("DrumSampler_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = false;  
            GameObject.Find("DrumSampler_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = true;
            GameObject.Find("DrumSampler_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            textmeshPro = GameObject.Find("CurrentPatternText_Drum").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString();
            GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Drum();        
            yield return new WaitForSeconds(nextbeatTimeDrum - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTimeDrum += beatTime*4;
            GameObject.Find("DrumSampler_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = false;  
            GameObject.Find("DrumSampler_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            GameObject.Find("DrumSampler_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText_Drum").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 3.ToString(); 
            GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Drum();       
            yield return new WaitForSeconds(nextbeatTimeDrum - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
        }           
    }

    public IEnumerator Loop_4_Bars_Drum() {
        while(true) {
            nextbeatTimeDrum += beatTime*4;
            GameObject.Find("DrumSampler_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = true;  
            GameObject.Find("DrumSampler_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            GameObject.Find("DrumSampler_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = false; 
            GameObject.Find("DrumSampler_" + 4).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            textmeshPro = GameObject.Find("CurrentPatternText_Drum").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString();   
            GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Drum();      
            yield return new WaitForSeconds(nextbeatTimeDrum - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTimeDrum += beatTime*4;
            GameObject.Find("DrumSampler_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = false;  
            GameObject.Find("DrumSampler_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = true;
            GameObject.Find("DrumSampler_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            GameObject.Find("DrumSampler_" + 4).GetComponent<AudioHelm.SampleSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText_Drum").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString();  
            GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Drum();      
            yield return new WaitForSeconds(nextbeatTimeDrum - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTimeDrum += beatTime*4;
            GameObject.Find("DrumSampler_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = false;  
            GameObject.Find("DrumSampler_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            GameObject.Find("DrumSampler_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = true; 
            GameObject.Find("DrumSampler_" + 4).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            textmeshPro = GameObject.Find("CurrentPatternText_Drum").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 3.ToString();   
            GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Drum();     
            yield return new WaitForSeconds(nextbeatTimeDrum - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTimeDrum += beatTime*4;
            GameObject.Find("DrumSampler_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = false;  
            GameObject.Find("DrumSampler_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            GameObject.Find("DrumSampler_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = false; 
            GameObject.Find("DrumSampler_" + 4).GetComponent<AudioHelm.SampleSequencer>().enabled = true;
            textmeshPro = GameObject.Find("CurrentPatternText_Drum").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 4.ToString();   
            GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Drum();     
            yield return new WaitForSeconds(nextbeatTimeDrum - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);                   
        }
    }  

    public IEnumerator Loop_1_Bars_Sample() {
        while(true) {
            nextbeatTimeSample += beatTime*4;
            GameObject.Find("SampleSequencer_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText_Sample").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString(); 
            GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Sample();         
            yield return new WaitForSeconds(nextbeatTimeSample - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
        } 
    }

    public IEnumerator Loop_2_Bars_Sample() {
        while(true) {      
            nextbeatTimeSample += beatTime*4;     
            GameObject.Find("SampleSequencer_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = true;  
            GameObject.Find("SampleSequencer_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText_Sample").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString(); 
            GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Sample();                    
            yield return new WaitForSeconds(nextbeatTimeSample - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTimeSample += beatTime*4;           
            GameObject.Find("SampleSequencer_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = false;  
            GameObject.Find("SampleSequencer_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText_Sample").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString(); 
            GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Sample();           
            yield return new WaitForSeconds(nextbeatTimeSample - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
        } 
    }

    public IEnumerator Loop_3_Bars_Sample() {
        while(true) {
            nextbeatTimeSample += beatTime*4;
            GameObject.Find("SampleSequencer_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = true;  
            GameObject.Find("SampleSequencer_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            GameObject.Find("SampleSequencer_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText_Sample").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString();
            GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Sample();         
            yield return new WaitForSeconds(nextbeatTimeSample - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTimeSample += beatTime*4;
            GameObject.Find("SampleSequencer_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = false;  
            GameObject.Find("SampleSequencer_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = true;
            GameObject.Find("SampleSequencer_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            textmeshPro = GameObject.Find("CurrentPatternText_Sample").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString();
            GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Sample();        
            yield return new WaitForSeconds(nextbeatTimeSample - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTimeSample += beatTime*4;
            GameObject.Find("SampleSequencer_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = false;  
            GameObject.Find("SampleSequencer_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            GameObject.Find("SampleSequencer_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = true; 
            textmeshPro = GameObject.Find("CurrentPatternText_Sample").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 3.ToString(); 
            GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Sample();       
            yield return new WaitForSeconds(nextbeatTimeSample - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
        }           
    }

    public IEnumerator Loop_4_Bars_Sample() {
        while(true) {
            nextbeatTimeSample += beatTime*4;
            GameObject.Find("SampleSequencer_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = true;  
            GameObject.Find("SampleSequencer_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            GameObject.Find("SampleSequencer_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = false; 
            GameObject.Find("SampleSequencer_" + 4).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            textmeshPro = GameObject.Find("CurrentPatternText_Sample").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 1.ToString();   
            GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Sample();      
            yield return new WaitForSeconds(nextbeatTimeSample - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTimeSample += beatTime*4;
            GameObject.Find("SampleSequencer_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = false;  
            GameObject.Find("SampleSequencer_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = true;
            GameObject.Find("SampleSequencer_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            GameObject.Find("SampleSequencer_" + 4).GetComponent<AudioHelm.SampleSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText_Sample").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 2.ToString();  
            GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Sample();      
            yield return new WaitForSeconds(nextbeatTimeSample - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTimeSample += beatTime*4;
            GameObject.Find("SampleSequencer_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = false;  
            GameObject.Find("SampleSequencer_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            GameObject.Find("SampleSequencer_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = true; 
            GameObject.Find("SampleSequencer_" + 4).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            textmeshPro = GameObject.Find("CurrentPatternText_Sample").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 3.ToString();   
            GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Sample();     
            yield return new WaitForSeconds(nextbeatTimeSample - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);
            nextbeatTimeSample += beatTime*4;
            GameObject.Find("SampleSequencer_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = false;  
            GameObject.Find("SampleSequencer_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
            GameObject.Find("SampleSequencer_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = false; 
            GameObject.Find("SampleSequencer_" + 4).GetComponent<AudioHelm.SampleSequencer>().enabled = true;
            textmeshPro = GameObject.Find("CurrentPatternText_Sample").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = 4.ToString();   
            GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().ShowCurrentPatternWhilePlaying_Sample();     
            yield return new WaitForSeconds(nextbeatTimeSample - GameObject.Find("Timer").GetComponent<TimerScript>().m_timePassed + beatTime);                   
        }
    }     
}
