using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using AudioHelm;
using System.Text.RegularExpressions;

public class ChangeCellColorPro : MonoBehaviour
{
    public RawImage img;
    public Color gridCellColor;
    public GameObject drumSampler;
    bool flag = false;

    public int startCell;
    public int startStep;
    public int dragCellCount = 0;

    string myString;//string with your numbers
    public int[] myNumbers;
    int number;        

    void Start() {
        gridCellColor = img.GetComponent<RawImage>().color;
        drumSampler = GameObject.Find("DrumSampler");
    }

    public void ChangeColorToRed() {
        if (this.GetComponent<RawImage>().color == Color.red) {
            RemoveNotesFromDrumSequencer(this.gameObject);
            img.GetComponent<RawImage>().color = gridCellColor;             
        }
        else {
            for (int i = 0; i < drumSampler.GetComponent<SampleSequencer>().length; i++) {
                img.GetComponent<RawImage>().color = Color.red;
                
                if (GameObject.Find("DrumRow_0_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(67, i, i+1);
                    PlayerPrefs.SetInt("Drum_1_" + 67 +"_"+ i, 1);
                }     
                if (GameObject.Find("DrumRow_1_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(66, i, i+1);
                    PlayerPrefs.SetInt("Drum_1_" + 66 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("DrumRow_2_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(65, i, i+1);
                    PlayerPrefs.SetInt("Drum_1_" + 65 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("DrumRow_3_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(64, i, i+1);
                    PlayerPrefs.SetInt("Drum_1_" + 64 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("DrumRow_4_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(63, i, i+1);
                    PlayerPrefs.SetInt("Drum_1_" + 63 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("DrumRow_5_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(62, i, i+1);
                    PlayerPrefs.SetInt("Drum_1_" + 62 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("DrumRow_6_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(61, i, i+1);
                    PlayerPrefs.SetInt("Drum_1_" + 61 +"_"+ i, 1);
                                    } 
                if (GameObject.Find("DrumRow_7_"+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(60, i, i+1);
                    PlayerPrefs.SetInt("Drum_1_" + 60 +"_"+ i, 1);
                }                                                                   
            } 
            PlayDrumRoll();           
        }
    }

    public void ChangeColorBack() {
        img.GetComponent<RawImage>().color = gridCellColor;
        flag = false;
    }    

    public void RemoveNotesFromDrumSequencer(GameObject cell) {
        for (int i = 0; i < drumSampler.GetComponent<SampleSequencer>().length; i++) {        
            if (cell.name == "DrumRow_0_"+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(67, i, i+1);
                PlayerPrefs.SetInt("Drum_1_" + 67 +"_"+ i, 0);
            }   
            if (cell.name == "DrumRow_1_"+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(66, i, i+1);
                PlayerPrefs.SetInt("Drum_1_" + 66 +"_"+ i, 0);
            } 
            if (cell.name == "DrumRow_2_"+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(65, i, i+1);
                PlayerPrefs.SetInt("Drum_1_" + 65 +"_"+ i, 0);
            }   
            if (cell.name == "DrumRow_3_"+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(64, i, i+1);
                PlayerPrefs.SetInt("Drum_1_" + 64 +"_"+ i, 0);
            }     
            if (cell.name == "DrumRow_4_"+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(63, i, i+1);
                PlayerPrefs.SetInt("Drum_1_" + 63 +"_"+ i, 0);
            }   
            if (cell.name == "DrumRow_5_"+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(62, i, i+1);
                PlayerPrefs.SetInt("Drum_1_" + 62 +"_"+ i, 0);
            }     
            if (cell.name == "DrumRow_6_"+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(61, i, i+1);
                PlayerPrefs.SetInt("Drum_1_" + 61 +"_"+ i, 0);
            }   
            if (cell.name == "DrumRow_7_"+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(60, i, i+1);
                PlayerPrefs.SetInt("Drum_1_" + 60 +"_"+ i, 0);
            }                                                              
        }         
    }

    public void PlayDrumRoll() {
        for (int i = 0; i < drumSampler.GetComponent<SampleSequencer>().length; i++) {
            if (GameObject.Find("DrumNote "+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                drumSampler.GetComponent<Sampler>().NoteOn(67-i);
            }     
        }                        
    }      
}
