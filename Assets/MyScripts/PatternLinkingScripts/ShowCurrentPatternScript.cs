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
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            GameObject.Find("SynthSequencer_" + 1).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
        }
        if (GameObject.Find("SynthSequencer_" + 2)) {
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            GameObject.Find("SynthSequencer_" + 2).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
        }
        if (GameObject.Find("SynthSequencer_" + 3)) {
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            GameObject.Find("SynthSequencer_" + 3).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
        }
        if (GameObject.Find("SynthSequencer_" + 4)) {
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            GameObject.Find("SynthSequencer_" + 4).GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1;  
        }    
        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();  
        StartCoroutine(LoadNotesIntoSeq());   
    }

    public void ShowCurrentPatternWhilePlaying() {    
        StartCoroutine(LoadNotesIntoGrid());   
    }    

    public IEnumerator LoadNotesIntoSeq() {
        loadingText.SetActive(true);
        currentPattern = Convert.ToInt32(textmeshPro.text);
        synthSeqContent.GetComponent<PopulateGrid_Synth>().ReColorGridFunction();
        yield return new WaitForSeconds(0f);
        //Load notes into Synth Sequencer

        if (GameObject.Find("SynthSequencer_1") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 1) {
            for (int i = 0; i < 84; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    //for (int k = 0; k < 16; k++) {
                        if (currentPattern == 1) {
                            if (GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                                GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                                noteTemp = GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().GetNoteInRange(108-i, j, j+1);
                                PlayerPrefs.SetInt("SynthSeq_1_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);            
                                for (int h = 0; h < (noteTemp.end_ - (noteTemp.start_)); h++) { 
                                    GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<RawImage>().color = Color.red;
                                    GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                                    GameObject.Find("Row_"+ (108-noteTemp.note) +"_"+(noteTemp.start_)).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                                }                   
                            }    
                        }
                        loadingText.SetActive(false);
                    //}
                }
            }
        }
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("SynthSequencer_2") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 2) {
            for (int i = 0; i < 84; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    //for (int k = 0; k < 16; k++) {        
                        if (currentPattern == 2) {
                            if (GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                                GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                                noteTemp = GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().GetNoteInRange(108-i, j, j+1);
                                PlayerPrefs.SetInt("SynthSeq_2_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);            
                                for (int h = 0; h < (noteTemp.end_ - (noteTemp.start_)); h++) { 
                                    GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<RawImage>().color = Color.red;
                                    GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                                    GameObject.Find("Row_"+ (108-noteTemp.note) +"_"+(noteTemp.start_)).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                                }                   
                            }  
                        }
                        loadingText.SetActive(false);
                    //}
                }
            }
        }
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("SynthSequencer_3") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 3) {
            for (int i = 0; i < 84; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    //for (int k = 0; k < 16; k++) {   
                        if (currentPattern == 3) {
                            if (GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                                GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                                noteTemp = GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().GetNoteInRange(108-i, j, j+1);
                                PlayerPrefs.SetInt("SynthSeq_3_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);            
                                for (int h = 0; h < (noteTemp.end_ - (noteTemp.start_)); h++) { 
                                    GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<RawImage>().color = Color.red;
                                    GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                                    GameObject.Find("Row_"+ (108-noteTemp.note) +"_"+(noteTemp.start_)).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                                }                   
                            }  
                        }
                        loadingText.SetActive(false);
                    //}
                }
            }
        }
        yield return new WaitForSeconds(0f);
        if (GameObject.Find("SynthSequencer_4") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 4) {
            for (int i = 0; i < 84; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    //for (int k = 0; k < 16; k++) {         
                        if (currentPattern == 4) {
                            if (GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                                GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                                noteTemp = GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().GetNoteInRange(108-i, j, j+1);
                                PlayerPrefs.SetInt("SynthSeq_4_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);            
                                for (int h = 0; h < (noteTemp.end_ - (noteTemp.start_)); h++) { 
                                    GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<RawImage>().color = Color.red;
                                    GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                                    GameObject.Find("Row_"+ (108-noteTemp.note) +"_"+(noteTemp.start_)).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                                }                   
                            }        
                        }  
                        loadingText.SetActive(false);                                                                                                          
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
                            noteTemp = GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().GetNoteInRange(108-i, j, j+1);
                            PlayerPrefs.SetInt("SynthSeq_1_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);            
                            for (int h = 0; h < (noteTemp.end_ - (noteTemp.start_)); h++) { 
                                GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<RawImage>().color = Color.red;
                                GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                                GameObject.Find("Row_"+ (108-noteTemp.note) +"_"+(noteTemp.start_)).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                            }                   
                        }
                    }
                    if(GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 2) {
                        if (GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                            GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                            noteTemp = GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().GetNoteInRange(108-i, j, j+1);
                            PlayerPrefs.SetInt("SynthSeq_2_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);           
                            for (int h = 0; h < (noteTemp.end_ - (noteTemp.start_)); h++) { 
                                GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<RawImage>().color = Color.red;
                                GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                                GameObject.Find("Row_"+ (108-noteTemp.note) +"_"+(noteTemp.start_)).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                            }                    
                        }
                    }
                    if(GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 3) {
                        if (GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                            GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                            noteTemp = GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().GetNoteInRange(108-i, j, j+1);  
                            PlayerPrefs.SetInt("SynthSeq_3_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);         
                            for (int h = 0; h < (noteTemp.end_ - (noteTemp.start_)); h++) { 
                                GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<RawImage>().color = Color.red;
                                GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                                GameObject.Find("Row_"+ (108-noteTemp.note) +"_"+(noteTemp.start_)).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                            }                    
                        }
                    }
                    if(GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x == 4) {
                        if (GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(108 - i, j, j+1)) {
                            GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                            noteTemp = GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().GetNoteInRange(108-i, j, j+1);
                            PlayerPrefs.SetInt("SynthSeq_4_" + (108-i) +"_"+ (j) +"_"+ (j+1), 1);           
                            for (int h = 0; h < (noteTemp.end_ - (noteTemp.start_)); h++) { 
                                GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<RawImage>().color = Color.red;
                                GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                                GameObject.Find("Row_"+ (108-noteTemp.note) +"_"+(noteTemp.start_)).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                            }                    
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
        //Load notes into Synth Sequencer

        if (GameObject.Find("SynthSequencer_1") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 1) {  
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
        if (GameObject.Find("SynthSequencer_2") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 2) {  
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
        if (GameObject.Find("SynthSequencer_3") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 3) {  
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
        if (GameObject.Find("SynthSequencer_4") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 4) {  
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
}
