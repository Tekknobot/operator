using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class PopulatePianoRoll_Synth : MonoBehaviour
{
    public GameObject prefab;
    public int numberToCreate = 12;
    public int numberOfGroups = 10;

    public string noteName = "SynthNote ";
    int totalNotes = -1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll(noteName);
        }
    }

    void Update() {

    }

    void PopulateRoll(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }                             
}
