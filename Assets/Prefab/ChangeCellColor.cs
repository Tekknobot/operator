using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using AudioHelm;
using System.Text.RegularExpressions;
using TMPro;

public class ChangeCellColor : MonoBehaviour
{
    public static ChangeCellColor instance;
    private static ChangeCellColor previousSelected = null;

    public RawImage img;
    public Color gridCellColor;
    public static float selectedColor_r;
    public static float selectedColor_g;
    public static float selectedColor_b;

    public static int sample;
    public static int sampleChop;

    public GameObject drumSampler;
    public GameObject chopSampler;
    bool flag = false;

    public static Note note;

    public int startCell;
    public int startStep;
    public int dragCellCount = 0;

    string myString;//string with your numbers
    public int[] myNumbers;
    int number;     

    public GameObject musicPlayer;
    public AudioSource musicPlayerAudioSource; 
    
    TextMeshProUGUI textmeshPro;      

    void Start() {
        gridCellColor = img.GetComponent<RawImage>().color;
        drumSampler = GameObject.Find("DrumSequencer");
        chopSampler = GameObject.Find("SampleSequencer");
        musicPlayer = GameObject.Find("MusicPlayer");
        musicPlayerAudioSource = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();        
    }

    public void ChangeColor() {
        PlayDrumRoll();
        PlaySampleRoll();
        if (this.gameObject.tag != "cell") {
            return;
        }   

        if (GameObject.Find("Rolls").GetComponent<Rolls>().roll == 1) {  
            if (this.gameObject.GetComponent<RawImage>().color == new Color(selectedColor_r, selectedColor_g, selectedColor_b)) {
                RemoveNotesFromDrumSequencer();
            }               
            else {
                this.gameObject.GetComponent<RawImage>().color = new Color(selectedColor_r, selectedColor_g, selectedColor_b);
                drumSampler.GetComponent<SampleSequencer>().AddNote(60+sample, this.gameObject.GetComponent<IndexObject>().step, this.gameObject.GetComponent<IndexObject>().step+1);
                PlayerPrefs.SetInt("Drum_" + (60+sample) +"_"+ this.gameObject.GetComponent<IndexObject>().step, 1);
            }
        }
        else if (GameObject.Find("Rolls").GetComponent<Rolls>().roll == 0) {
            if (this.gameObject.GetComponent<RawImage>().color == new Color(0.3f, 0.3f, 0.3f)) {
                RemoveNotesFromSampleSequencer(this.gameObject.GetComponent<IndexObject>().midiNote);
                Debug.Log(this.gameObject.GetComponent<IndexObject>().midiNote);
            }               
            else {
                this.gameObject.GetComponent<RawImage>().color = new Color(0.3f, 0.3f, 0.3f);
                this.gameObject.GetComponent<IndexObject>().midiNote = 60+sampleChop;
                this.gameObject.GetComponent<IndexObject>().samplePadNum = sampleChop;
                chopSampler.GetComponent<SampleSequencer>().AddNote(this.gameObject.GetComponent<IndexObject>().midiNote, this.gameObject.GetComponent<IndexObject>().step, this.gameObject.GetComponent<IndexObject>().step+1);
                textmeshPro = this.gameObject.GetComponentInChildren<TextMeshProUGUI>(); 
                textmeshPro.text = (sampleChop+1).ToString();
                PlayerPrefs.SetInt("Sample_" + (60+sampleChop) +"_"+ this.gameObject.GetComponent<IndexObject>().step, 1);
            }            
        }
    }

    public void ChangeColorBack() {
        for (int i = 0; i < drumSampler.GetComponent<SampleSequencer>().length; i++) { 
            if (this.gameObject.name == "Cell_"+ i.ToString()) {
                img.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
            }
        }
        flag = false;
    }    

    public void RemoveNotesFromDrumSequencer() {
        this.gameObject.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
        drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(60+sample, this.gameObject.GetComponent<IndexObject>().step, this.gameObject.GetComponent<IndexObject>().step+1);                                                                       
        PlayerPrefs.SetInt("Drum_" + (60+sample) +"_"+ this.gameObject.GetComponent<IndexObject>().step, 0);
        
    }

    public void RemoveNotesFromSampleSequencer(int midiNote) {
        this.gameObject.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
        chopSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(midiNote, this.gameObject.GetComponent<IndexObject>().step, this.gameObject.GetComponent<IndexObject>().step+1);                                                                       
        PlayerPrefs.SetInt("Sample_" + (midiNote) +"_"+ this.gameObject.GetComponent<IndexObject>().step, 0);
        textmeshPro = this.gameObject.GetComponentInChildren<TextMeshProUGUI>(); 
        textmeshPro.text = " ";          
    }    

    public void PlayDrumRoll() {
        for (int i = 0; i < 8; i++) {
            if (this.gameObject.name == "DrumCell_"+ i.ToString()) {
                drumSampler.GetComponent<Sampler>().NoteOn(60+i);
                sample = i;
                if (i == 0) { selectedColor_r = 0.92549f; selectedColor_g = 0.00000f; selectedColor_b = 0.54902f; }
                if (i == 1) { selectedColor_r = 0.40000f; selectedColor_g = 0.17647f; selectedColor_b = 0.56863f; }
                if (i == 2) { selectedColor_r = 0.00000f; selectedColor_g = 0.32941f; selectedColor_b = 0.65098f; }
                if (i == 3) { selectedColor_r = 0.00000f; selectedColor_g = 0.68235f; selectedColor_b = 0.93725f; }
                if (i == 4) { selectedColor_r = 0.00000f; selectedColor_g = 0.65098f; selectedColor_b = 0.31765f; }
                if (i == 5) { selectedColor_r = 0.55294f; selectedColor_g = 0.77647f; selectedColor_b = 0.24706f; }
                if (i == 6) { selectedColor_r = 0.96863f; selectedColor_g = 0.58039f; selectedColor_b = 0.11373f; }
                if (i == 7) { selectedColor_r = 0.92941f; selectedColor_g = 0.10980f; selectedColor_b = 0.14118f; }
                DisplayActiveBoard(sample);
            }     
        }                        
    }  

    public void PlaySampleRoll() {
        for (int i = 0; i < 16; i++) {
            if (this.gameObject.name == "SampleCell_"+ i.ToString()) {
                musicPlayerAudioSource.time = musicPlayer.GetComponent<MusicPlayer>().chopTime[(i)];
                musicPlayerAudioSource.Play();  
                musicPlayerAudioSource.SetScheduledEndTime(AudioSettings.dspTime + (musicPlayer.GetComponent<MusicPlayer>().chopTime[i+1]-(musicPlayer.GetComponent<MusicPlayer>().chopTime[i])));                
                sampleChop = i;
                DisplaySampleBoard();
            }     
        }                        
    }     

    public void DisplayActiveBoard(int sample) {
        for (int i = 0; i < drumSampler.GetComponent<SampleSequencer>().length; i++) {
            textmeshPro = GameObject.Find("Cell_"+i).GetComponentInChildren<TextMeshProUGUI>(); 
            textmeshPro.text = " ";  
            GameObject.Find("Cell_"+i).GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
            List<Note> notes = drumSampler.GetComponent<SampleSequencer>().GetAllNoteOnsInRange(0, drumSampler.GetComponent<SampleSequencer>().length);
            foreach (Note note in notes) {
                if (sample == 0 && note.note == 60) {
                    GameObject.Find("Cell_"+note.start_).GetComponent<RawImage>().color = new Color(selectedColor_r, selectedColor_g, selectedColor_b);
                }
                if (sample == 1 && note.note == 61) {
                    GameObject.Find("Cell_"+note.start_).GetComponent<RawImage>().color = new Color(selectedColor_r, selectedColor_g, selectedColor_b);
                }  
                if (sample == 2 && note.note == 62) {
                    GameObject.Find("Cell_"+note.start_).GetComponent<RawImage>().color = new Color(selectedColor_r, selectedColor_g, selectedColor_b);
                }  
                if (sample == 3 && note.note == 63) {
                    GameObject.Find("Cell_"+note.start_).GetComponent<RawImage>().color = new Color(selectedColor_r, selectedColor_g, selectedColor_b);
                }      
                if (sample == 4 && note.note == 64) {
                    GameObject.Find("Cell_"+note.start_).GetComponent<RawImage>().color = new Color(selectedColor_r, selectedColor_g, selectedColor_b);
                }   
                if (sample == 5 && note.note == 65) {
                    GameObject.Find("Cell_"+note.start_).GetComponent<RawImage>().color = new Color(selectedColor_r, selectedColor_g, selectedColor_b);
                }   
                if (sample == 6 && note.note == 66) {
                    GameObject.Find("Cell_"+note.start_).GetComponent<RawImage>().color = new Color(selectedColor_r, selectedColor_g, selectedColor_b);
                }   
                if (sample == 7 && note.note == 67) {
                    GameObject.Find("Cell_"+note.start_).GetComponent<RawImage>().color = new Color(selectedColor_r, selectedColor_g, selectedColor_b);
                }                                                                                                   
            }
        }        
    }    

    public void DisplaySampleBoard() {
        for (int i = 0; i < drumSampler.GetComponent<SampleSequencer>().length; i++) {
            GameObject.Find("Cell_"+i).GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);                                                                                                                
            List<Note> notes = chopSampler.GetComponent<SampleSequencer>().GetAllNoteOnsInRange(0, chopSampler.GetComponent<SampleSequencer>().length);
            foreach (Note note in notes) {
                GameObject.Find("Cell_"+note.start_).GetComponent<RawImage>().color = new Color(0.3f, 0.3f, 0.3f);
                GameObject.Find("Cell_"+note.start_).GetComponent<IndexObject>().samplePadNum = note.note-60+1;
                GameObject.Find("Cell_"+note.start_).GetComponent<IndexObject>().midiNote = note.note;
                textmeshPro = GameObject.Find("Cell_"+note.start_).GetComponentInChildren<TextMeshProUGUI>(); 
                textmeshPro.text = (note.note-60+1).ToString();                  
            }       
        }     
    }    
}
