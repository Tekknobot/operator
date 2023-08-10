using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;
using TMPro;
using System.Linq;
using System;

public class ShowCurrentPatternScript : MonoBehaviour
{
    public int x;
    public AudioHelm.Note noteTemp;
    public GameObject synthSequencer;
    public int currentPattern;
    public int currentPatternDrum;
    public TextMeshProUGUI textmeshPro;

    public GameObject loadingText;

    public GameObject drumSeqContent;
    public GameObject synthSeqContent;
    public GameObject sampleSeqContent;   

    public GameObject playButton; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowCurrentPattern() {
        playButton.GetComponent<Toggle>().enabled = true;
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        currentPattern = Convert.ToInt32(textmeshPro.text);  
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;      
        if (GameObject.Find("SynthSequencer_" + 1)) {
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
        }
        if (GameObject.Find("SynthSequencer_" + 2)) {
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
        }
        if (GameObject.Find("SynthSequencer_" + 3)) {
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
        }
        if (GameObject.Find("SynthSequencer_" + 4)) {
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = false;
        }    
        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();  
        StartCoroutine(LoadNotesIntoSeq()); 
        StartCoroutine(LoadNotesIntoGrid());  
    }

    ////////////

    public void ShowCurrentPattern_Drum() {
        playButton.GetComponent<Toggle>().enabled = true;
        textmeshPro = GameObject.Find("CurrentPatternText_Drum").GetComponent<TextMeshProUGUI>();
        currentPatternDrum = Convert.ToInt32(textmeshPro.text);  
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;      
        if (GameObject.Find("DrumSampler_" + 1)) {
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("DrumSampler_" + 1).GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;  
            GameObject.Find("DrumSampler_" + 1).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
        }
        if (GameObject.Find("DrumSampler_" + 2)) {
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("DrumSampler_" + 2).GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;  
            GameObject.Find("DrumSampler_" + 2).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
        }
        if (GameObject.Find("DrumSampler_" + 3)) {
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("DrumSampler_" + 3).GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;  
            GameObject.Find("DrumSampler_" + 3).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
        }
        if (GameObject.Find("DrumSampler_" + 4)) {
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("DrumSampler_" + 4).GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;  
            GameObject.Find("DrumSampler_" + 4).GetComponent<AudioHelm.SampleSequencer>().enabled = false;
        }    
        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();  
        StartCoroutine(LoadNotesIntoSeq_Drum()); 
        StartCoroutine(LoadNotesIntoGrid_Drum());  
    }    

    public void ShowCurrentPatternWhilePlaying() {    
        StartCoroutine(LoadNotesIntoGrid());   
    } 

    public void ShowCurrentPatternWhilePlaying_Drum() {    
        StartCoroutine(LoadNotesIntoGrid_Drum());   
    }  

    /////////////     

    public IEnumerator LoadNotesIntoSeq() {
        loadingText.SetActive(true);
        synthSeqContent.GetComponent<PopulateGrid_Synth>().ReColorGridFunction();
        yield return new WaitForSeconds(0f);
        //Load notes into Synth Sequencer

        if (GameObject.Find("SynthSequencer_1")) {
            for (int i = 0; i < 84; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    //for (int k = 0; k < 16; k++) {
                        if (currentPattern == 1) {
                            if (GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                                GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                                PlayerPrefs.SetInt("SynthSeq_1_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);                             
                            }    
                        }
                        loadingText.SetActive(false);
                        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();
                    //}
                }
            }
        }
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("SynthSequencer_2")) {
            for (int i = 0; i < 84; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    //for (int k = 0; k < 16; k++) {        
                        if (currentPattern == 2) {
                            if (GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                                GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                                PlayerPrefs.SetInt("SynthSeq_2_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);                               
                            }  
                        }
                        loadingText.SetActive(false);
                        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();
                    //}
                }
            }
        }
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("SynthSequencer_3")) {
            for (int i = 0; i < 84; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    //for (int k = 0; k < 16; k++) {   
                        if (currentPattern == 3) {
                            if (GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                                GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                                PlayerPrefs.SetInt("SynthSeq_3_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);                              
                            }  
                        }
                        loadingText.SetActive(false);
                        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();
                    //}
                }
            }
        }
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("SynthSequencer_4")) {
            for (int i = 0; i < 84; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    //for (int k = 0; k < 16; k++) {         
                        if (currentPattern == 4) {
                            if (GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                                GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                                PlayerPrefs.SetInt("SynthSeq_4_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);                              
                            }        
                        }  
                        loadingText.SetActive(false);
                        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();                                                                                                          
                    //}
                }               
            }	
        }  
    }   

    public IEnumerator CopyNotesIntoSeq() {
        loadingText.SetActive(true);
        yield return new WaitForSeconds(0f);
        for (int i = 0; i < 84; i++) {
            for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                //for (int k = 0; k < 16; k++) {
                    if(GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 1) {
                        if (GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                            GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                            PlayerPrefs.SetInt("SynthSeq_1_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);                               
                        }
                    }
                    if(GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 2) {
                        if (GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                            GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                            PlayerPrefs.SetInt("SynthSeq_2_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);                              
                        }
                    }
                    if(GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 3) {
                        if (GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                            GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                            PlayerPrefs.SetInt("SynthSeq_3_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);                             
                        }
                    }
                    if(GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 4) {
                        if (GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                            GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                            PlayerPrefs.SetInt("SynthSeq_4_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);                               
                        }   
                    }                                                         
                //}
                loadingText.SetActive(false);
            } 
        }       
    }  

    public IEnumerator LoadNotesIntoGrid() {
        loadingText.SetActive(true);
        currentPattern = Convert.ToInt32(textmeshPro.text);
        synthSeqContent.GetComponent<PopulateGrid_Synth>().ReColorGridFunction();
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("SynthSequencer_1")) {  
            for (int i = 0; i < 84; i++) {             
                for (int j = 0; j < 16; j++) { 
                    if (GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                        GameObject.Find("Row_"+ i +"_"+ j).GetComponent<RawImage>().color = Color.red;
                        GameObject.Find("Row_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                        GameObject.Find("Row_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                    }
                }                   
            }
        }
        yield return new WaitForSeconds(0f);        
        if (GameObject.Find("SynthSequencer_2")) {  
            for (int i = 0; i < 84; i++) {             
                for (int j = 0; j < 16; j++) { 
                    if (GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                        GameObject.Find("Row_"+ i +"_"+ j).GetComponent<RawImage>().color = Color.red;
                        GameObject.Find("Row_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                        GameObject.Find("Row_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                    }
                }                   
            }
        }
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("SynthSequencer_3")) {  
            for (int i = 0; i < 84; i++) {             
                for (int j = 0; j < 16; j++) { 
                    if (GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                        GameObject.Find("Row_"+ i +"_"+ j).GetComponent<RawImage>().color = Color.red;
                        GameObject.Find("Row_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                        GameObject.Find("Row_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                    }
                }                   
            }
        }
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("SynthSequencer_4")) {  
            for (int i = 0; i < 84; i++) {             
                for (int j = 0; j < 16; j++) { 
                    if (GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                        GameObject.Find("Row_"+ i +"_"+ j).GetComponent<RawImage>().color = Color.red;
                        GameObject.Find("Row_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                        GameObject.Find("Row_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                    }
                }                   
            }
        }                                          
    }    

    /////////////

    public IEnumerator LoadNotesIntoSeq_Drum() {
        loadingText.SetActive(true);
        drumSeqContent.GetComponent<PopulateGrid_Drums>().ReColorGridFunction();
        yield return new WaitForSeconds(0f);
        //Load notes into Synth Sequencer

        if (GameObject.Find("DrumSampler_1")) {
            for (int i = 0; i < 68; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    //for (int k = 0; k < 16; k++) {
                        if (currentPatternDrum == 1) {
                            if (GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                                GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.SampleSequencer>().AddNote(108 - i, j, j+1);
                                PlayerPrefs.SetInt("DrumSeq_1_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);                             
                            }    
                        }
                        loadingText.SetActive(false);
                        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();
                    //}
                }
            }
        }
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("DrumSampler_2")) {
            for (int i = 0; i < 68
            ; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    //for (int k = 0; k < 16; k++) {        
                        if (currentPatternDrum == 2) {
                            if (GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                                GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.SampleSequencer>().AddNote(108 - i, j, j+1);
                                PlayerPrefs.SetInt("DrumSeq_2_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);                               
                            }  
                        }
                        loadingText.SetActive(false);
                        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();
                    //}
                }
            }
        }
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("DrumSampler_3")) {
            for (int i = 0; i < 68; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    //for (int k = 0; k < 16; k++) {   
                        if (currentPatternDrum == 3) {
                            if (GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                                GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.SampleSequencer>().AddNote(108 - i, j, j+1);
                                PlayerPrefs.SetInt("DrumSeq_3_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);                              
                            }  
                        }
                        loadingText.SetActive(false);
                        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();
                    //}
                }
            }
        }
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("DrumSampler_4")) {
            for (int i = 0; i < 68; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    //for (int k = 0; k < 16; k++) {         
                        if (currentPatternDrum == 4) {
                            if (GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                                GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.SampleSequencer>().AddNote(108 - i, j, j+1);
                                PlayerPrefs.SetInt("DrumSeq_4_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);                              
                            }        
                        }  
                        loadingText.SetActive(false);
                        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();                                                                                                          
                    //}
                }               
            }	
        }  
    }   

    public IEnumerator CopyNotesIntoSeq_Drum() {
        loadingText.SetActive(true);
        yield return new WaitForSeconds(0f);
        for (int i = 0; i < 68; i++) {
            for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                //for (int k = 0; k < 16; k++) {
                    if(GameObject.Find("AddPattern_Drum").GetComponent<DuplicateSynthSequencerScript>().x == 1) {
                        if (GameObject.Find("DrumSequencer").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                            GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                            PlayerPrefs.SetInt("DrumSeq_1_" + (68-i) +"_"+ (j) +"_"+ (j+1), 1);                               
                        }
                    }
                    if(GameObject.Find("AddPattern_Drum").GetComponent<DuplicateSynthSequencerScript>().x == 1) {
                        if (GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                            GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                            PlayerPrefs.SetInt("DrumSeq_2_" + (68-i) +"_"+ (j) +"_"+ (j+1), 1);                               
                        }
                    }
                    if(GameObject.Find("AddPattern_Drum").GetComponent<DuplicateSynthSequencerScript>().x == 1) {
                        if (GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                            GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                            PlayerPrefs.SetInt("DrumSeq_3_" + (68-i) +"_"+ (j) +"_"+ (j+1), 1);                               
                        }
                    }
                    if(GameObject.Find("AddPattern_Drum").GetComponent<DuplicateSynthSequencerScript>().x == 1) {
                        if (GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                            GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                            PlayerPrefs.SetInt("DrumSeq_4_" + (68-i) +"_"+ (j) +"_"+ (j+1), 1);                               
                        }
                    }                                                     
                //}
                loadingText.SetActive(false);
            } 
        }       
    }  

    public IEnumerator LoadNotesIntoGrid_Drum() {
        loadingText.SetActive(true);
        currentPatternDrum = Convert.ToInt32(textmeshPro.text);
        drumSeqContent.GetComponent<PopulateGrid_Drums>().ReColorGridFunction();
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("DrumSampler_1")) {  
            for (int i = 0; i < 8; i++) {             
                for (int j = 0; j < 16; j++) { 
                    if (GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(68 - i, j, j+1)) {
                        GameObject.Find("DrumRow_"+ i +"_"+ j).GetComponent<RawImage>().color = Color.red;
                        GameObject.Find("DrumRow_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                        GameObject.Find("DrumRow_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        Debug.Log("FIRED 2");
                    }
                }                   
            }
            Debug.Log("FIRED 1");
        }
        yield return new WaitForSeconds(0f);        
        if (GameObject.Find("DrumSampler_2")) {  
            for (int i = 0; i < 8; i++) {             
                for (int j = 0; j < 16; j++) { 
                    if (GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(68 - i, j, j+1)) {
                        GameObject.Find("DrumRow_"+ i +"_"+ j).GetComponent<RawImage>().color = Color.red;
                        GameObject.Find("DrumRow_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                        GameObject.Find("DrumRow_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                    }
                }                   
            }
        }
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("DrumSampler_3")) {  
            for (int i = 0; i < 8; i++) {             
                for (int j = 0; j < 16; j++) { 
                    if (GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(68 - i, j, j+1)) {
                        GameObject.Find("DrumRow_"+ i +"_"+ j).GetComponent<RawImage>().color = Color.red;
                        GameObject.Find("DrumRow_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                        GameObject.Find("DrumRow_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                    }
                }                   
            }
        }
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("DrumSampler_4")) {  
            for (int i = 0; i < 8; i++) {             
                for (int j = 0; j < 16; j++) { 
                    if (GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(68 - i, j, j+1)) {
                        GameObject.Find("DrumRow_"+ i +"_"+ j).GetComponent<RawImage>().color = Color.red;
                        GameObject.Find("DrumRow_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                        GameObject.Find("DrumRow_"+ i +"_"+ j).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                    }
                }                   
            }
        }                                         
    }     
}
