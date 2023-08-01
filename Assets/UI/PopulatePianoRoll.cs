using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class PopulatePianoRoll : MonoBehaviour
{
    public GameObject prefab;
    public int numberToCreate = 8;
    public GameObject drumSampler;

    // Start is called before the first frame update
    void Start()
    {
        drumSampler = GameObject.Find("DrumSampler");
        PopulateRoll();
    }

    void Update() {

    }

    void PopulateRoll() {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = "DrumNote "+ i.ToString();  
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = "DrumNote "+ i.ToString(); 
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = "DrumNote "+ i.ToString();  
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = "DrumNote "+ i.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black;  
                newObj.name = "DrumNote "+ i.ToString();
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = "DrumNote "+ i.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = "DrumNote "+ i.ToString(); 
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = "DrumNote "+ i.ToString();
            }                                                                                                                                          
        }
    }                             
}
