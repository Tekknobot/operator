using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class ChangeNoteColor_Synth : MonoBehaviour
{
    public RawImage img;
    public Color gridCellColor;
    public GameObject synthSequencer;
    bool flag = false;

    void Start() {
        gridCellColor = img.GetComponent<RawImage>().color;
        synthSequencer = GameObject.Find("SynthSequencer");
    }

    public void ChangeColorToRed() {
        if (this.GetComponent<RawImage>().color == Color.red) {
            RemoveNotesFromDrumSequencer(this.gameObject);
            img.GetComponent<RawImage>().color = gridCellColor;             
        }
        else {
            for (int i = 0; i < 84; i++) {
                img.GetComponent<RawImage>().color = Color.red;
                for (int h = 0; h < 16; h++) {
                    if (GameObject.Find("Row_"+i.ToString()+"_"+h).GetComponent<RawImage>().color == Color.red) {
                        synthSequencer.GetComponent<HelmSequencer>().AddNote(108-i, i, i+1);
                    }                             
                }                                      
            } 
            PlaySynthRoll();           
        }
    }

    public void ChangeColorBack() {
        img.GetComponent<RawImage>().color = gridCellColor;
        synthSequencer.GetComponent<HelmSequencer>().AllNotesOff();
    }    

    public void RemoveNotesFromDrumSequencer(GameObject cell) {
        for (int i = 0; i < 84; i++) {        
            if (cell.name == "KICK "+ i.ToString()) {
                synthSequencer.GetComponent<HelmSequencer>().RemoveNotesInRange(24+i, i, i+1);
            }                                                                
        }         
    }

    public void PlaySynthRoll() {
        for (int i = 0; i < 84; i++) {
            if (GameObject.Find("SynthNote "+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                synthSequencer.GetComponent<HelmSequencer>().NoteOn(108-i);
            }     
        }                        
    }    
}
