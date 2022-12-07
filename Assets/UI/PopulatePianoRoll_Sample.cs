using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class PopulatePianoRoll_Sample : MonoBehaviour
{
    public GameObject prefab;
    public int numberToCreate = 16;
    public GameObject sampleSequencer;

    // Start is called before the first frame update
    void Start()
    {
        PopulateRoll();
        sampleSequencer = GameObject.Find("SampleSequencer");
    }

    void Update() {

    }

    void PopulateRoll() {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = "SampleNote "+ i.ToString();  
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = "SampleNote "+ i.ToString(); 
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = "SampleNote "+ i.ToString();  
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = "SampleNote "+ i.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = "SampleNote "+ i.ToString();
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = "SampleNote "+ i.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = "SampleNote "+ i.ToString(); 
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.black;  
                newObj.name = "SampleNote "+ i.ToString();
            }   

            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = "SampleNote "+ i.ToString();  
            }  
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = "SampleNote "+ i.ToString(); 
            }    
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = "SampleNote "+ i.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = "SampleNote "+ i.ToString();  
            }    
            if (i == 12) {
                newObj.GetComponent<RawImage>().color = Color.black;  
                newObj.name = "SampleNote "+ i.ToString();
            }    
            if (i == 13) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = "SampleNote "+ i.ToString();  
            }    
            if (i == 14) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = "SampleNote "+ i.ToString(); 
            }    
            if (i == 15) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = "SampleNote "+ i.ToString();
            }                                                                                                                                                    
        }
    }                             
}
