using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayButtonPro : MonoBehaviour
{
    TextMeshProUGUI textmeshPro;

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
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
    }

    public void PlayPattern() {
        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 0) {
            PlaySequencer(); 
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().enabled = true;            
        }

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 1) {
            PlaySequencer(); 
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            //textmeshPro.text = 1.ToString();                        
        }

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 2) {
            PlaySequencer();  
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            StartCoroutine(Loop_2_Bars());
        } 

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 3) {
            PlaySequencer();  
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            StartCoroutine(Loop_3_Bars());
        } 

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 4) {
            PlaySequencer();  
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().enabled = false;
            StartCoroutine(Loop_4_Bars());
        }         
    }

    public void PlaySequencer() {
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset(); 
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();     
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = false;         

        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 1) {
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
        }
        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 2) {
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
        }
        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 3) {
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
        }
        if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 4) {
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
        }          
    }     

    public void StopPattern() {
        StopAllCoroutines();
        if (GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause == false) {
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset(); 
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
            if (GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x > 0) {
                for (int i = 1; i > GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x; i++) {
                    GameObject.Find("SynthSequencer_"+ i).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;
                }      
            }      
            GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
            GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();               
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
        }
    }    

    IEnumerator Loop_2_Bars() {
        GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = true;  
        GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = 1.ToString();          
        yield return new WaitForSeconds((60f/GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().bpm*4));
        GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
        GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = 2.ToString();        
        yield return new WaitForSeconds((60f/GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().bpm*4));   
        StartCoroutine(Loop_2_Bars());
    }

    IEnumerator Loop_3_Bars() {
        GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = true;  
        GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
        GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = 1.ToString();          
        yield return new WaitForSeconds((60f/GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().bpm*4));
        GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
        GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
        GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = 2.ToString();        
        yield return new WaitForSeconds((60f/GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().bpm*4));
        GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
        GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
        GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = 3.ToString();        
        yield return new WaitForSeconds((60f/GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().bpm*4));           
        StartCoroutine(Loop_3_Bars());
    }

    IEnumerator Loop_4_Bars() {
        GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = true;  
        GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
        GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
        GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = 1.ToString();         
        yield return new WaitForSeconds((60f/GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().bpm*4));
        GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
        GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
        GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
        GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = 2.ToString();        
        yield return new WaitForSeconds((60f/GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().bpm*4));
        GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
        GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
        GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = true; 
        GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = 3.ToString();        
        yield return new WaitForSeconds((60f/GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().bpm*4));
        GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;  
        GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
        GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false; 
        GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = 4.ToString();        
        yield return new WaitForSeconds((60f/GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().bpm*4));                   
        StartCoroutine(Loop_4_Bars());
    }    
}
