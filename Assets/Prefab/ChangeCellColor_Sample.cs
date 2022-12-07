using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using AudioHelm;
using System.Text.RegularExpressions;

public class ChangeCellColor_Sample : MonoBehaviour
{
    public RawImage img;
    public Color gridCellColor;
    public GameObject sampleSequencer;
    bool flag = false;   

    public GameObject musicPlayer;
    public AudioSource musicPlayerAudioSource;    

    void Start() {
        gridCellColor = img.GetComponent<RawImage>().color;
        sampleSequencer = GameObject.Find("SampleSequencer");
        musicPlayer = GameObject.Find("MusicPlayer");
        musicPlayerAudioSource = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
    }

    public void ChangeColorToRed() {
        if (this.GetComponent<RawImage>().color == Color.red) {
            RemoveNotesFromSampleSequencer(this.gameObject);
            img.GetComponent<RawImage>().color = gridCellColor;             
        }
        else {
            for (int i = 0; i < sampleSequencer.GetComponent<SampleSequencer>().length; i++) {
                img.GetComponent<RawImage>().color = Color.red;
                
                if (GameObject.Find("SampleRow_0_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(75, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 75 +"_"+ i, 1);
                }     
                if (GameObject.Find("SampleRow_1_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(74, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 74 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("SampleRow_2_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(73, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 73 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("SampleRow_3_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(72, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 72 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("SampleRow_4_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(71, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 71 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("SampleRow_5_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(70, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 70 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("SampleRow_6_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(69, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 69 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("SampleRow_7_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(68, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 68 +"_"+ i, 1);
                } 


                if (GameObject.Find("SampleRow_8_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(67, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 67 +"_"+ i, 1);
                }     
                if (GameObject.Find("SampleRow_9_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(66, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 66 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("SampleRow_10_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(65, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 65 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("SampleRow_11_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(64, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 64 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("SampleRow_12_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(63, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 63 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("SampleRow_13_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(62, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 62 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("SampleRow_14_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(61, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 61 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("SampleRow_15_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(60, i, i+1);
                    PlayerPrefs.SetInt("Sample_1_" + 60 +"_"+ i, 1);
                } 
            } 
            PlaySampleRoll();           
        }
    }

    public void ChangeColorBack() {
        img.GetComponent<RawImage>().color = gridCellColor;
        flag = false;
    }    

    public void RemoveNotesFromSampleSequencer(GameObject cell) {
        for (int i = 0; i < sampleSequencer.GetComponent<SampleSequencer>().length; i++) {        
            if (cell.name == "SampleRow_0_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(75, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 75 +"_"+ i, 0);
            }   
            if (cell.name == "SampleRow_1_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(74, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 74 +"_"+ i, 0);
            } 
            if (cell.name == "SampleRow_2_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(73, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 73 +"_"+ i, 0);
            }   
            if (cell.name == "SampleRow_3_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(72, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 72 +"_"+ i, 0);
            }     
            if (cell.name == "SampleRow_4_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(71, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 71 +"_"+ i, 0);
            }   
            if (cell.name == "SampleRow_5_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(70, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 70 +"_"+ i, 0);
            }     
            if (cell.name == "SampleRow_6_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(69, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 69 +"_"+ i, 0);
            }   
            if (cell.name == "SampleRow_7_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(68, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 68 +"_"+ i, 0);
            }   


            if (cell.name == "SampleRow_8_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(67, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 67 +"_"+ i, 0);
            }   
            if (cell.name == "SampleRow_9_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(66, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 66 +"_"+ i, 0);
            } 
            if (cell.name == "SampleRow_10_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(65, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 65 +"_"+ i, 0);
            }   
            if (cell.name == "SampleRow_11_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(64, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 64 +"_"+ i, 0);
            }     
            if (cell.name == "SampleRow_12_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(63, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 63 +"_"+ i, 0);
            }   
            if (cell.name == "SampleRow_13_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(62, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 62 +"_"+ i, 0);
            }     
            if (cell.name == "SampleRow_14_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(61, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 61 +"_"+ i, 0);
            }   
            if (cell.name == "SampleRow_15_"+ i.ToString()) {
                sampleSequencer.GetComponent<SampleSequencer>().RemoveNotesInRange(60, i, i+1);
                PlayerPrefs.SetInt("Sample_1_" + 60 +"_"+ i, 0);
            }                                                                        
        }         
    }

    public void PlaySampleRoll() {
        for (int i = 0; i < sampleSequencer.GetComponent<SampleSequencer>().length; i++) {
            if (GameObject.Find("SampleNote "+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                musicPlayerAudioSource.time = musicPlayer.GetComponent<MusicPlayer>().chopTime[(16-i)];
                musicPlayerAudioSource.Play();  
                musicPlayerAudioSource.SetScheduledEndTime(AudioSettings.dspTime + (musicPlayer.GetComponent<MusicPlayer>().chopTime[(16-i)+1]-(musicPlayer.GetComponent<MusicPlayer>().chopTime[(16-i)])));                
            }     
        }                        
    }      
}
