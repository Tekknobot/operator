using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;
using TMPro;

public class PopulatePianoRoll_Labels : MonoBehaviour
{
    public GameObject prefab;
    public int numberToCreate = 12;
    public int numberOfGroups = 10;

    public string noteName = "Label_";
    int totalNotes = -1;

    TextMeshProUGUI textmeshPro;

    int octavelabel_7 = 7;
    int octavelabel_6 = 6;

    int z = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll(noteName);
            z++;
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
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "C"+(octavelabel_7-z); 
            }  
            if (i == 1) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "B"+(octavelabel_6-z);                  
            }    
            if (i == 2) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "A#"+(octavelabel_6-z);                   
            }    
            if (i == 3) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "A"+(octavelabel_6-z);                  
            }    
            if (i == 4) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "G#"+(octavelabel_6-z);                   
            }    
            if (i == 5) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "G"+(octavelabel_6-z);                  
            }    
            if (i == 6) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "F#"+(octavelabel_6-z);                  
            }    
            if (i == 7) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "F"+(octavelabel_6-z);  
            }  
            if (i == 8) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "E"+(octavelabel_6-z);                    
            }     
            if (i == 9) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "D#"+(octavelabel_6-z);     
            }   
            if (i == 10) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "D"+(octavelabel_6-z);                 
            }    
            if (i == 11) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "C#"+(octavelabel_6-z);    
            }                                                                                                                                                                                                   
        }
    }                             
}
