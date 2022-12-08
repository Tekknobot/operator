using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;
using TMPro;

public class PopulateRoll : MonoBehaviour
{
    public GameObject prefab;
    public int length;

    public bool sampleRoll;
    TextMeshProUGUI textmeshPro;

    // Start is called before the first frame update
    void Start()
    {
        PopulateRollFunction(length);
    }

    void PopulateRow(int numberToCreate) {
        for (int i = 0; i < numberToCreate; i++) {
            GameObject newObj;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) { newObj.GetComponent<RawImage>().color = new Color(0.92549f,  0.00000f,  0.54902f); }
            if (i == 1) { newObj.GetComponent<RawImage>().color = new Color(0.40000f,  0.17647f,  0.56863f); }
            if (i == 2) { newObj.GetComponent<RawImage>().color = new Color(0.00000f,  0.32941f,  0.65098f); }
            if (i == 3) { newObj.GetComponent<RawImage>().color = new Color(0.00000f,  0.68235f,  0.93725f); }
            if (i == 4) { newObj.GetComponent<RawImage>().color = new Color(0.00000f,  0.65098f,  0.31765f); }
            if (i == 5) { newObj.GetComponent<RawImage>().color = new Color(0.55294f,  0.77647f,  0.24706f); }
            if (i == 6) { newObj.GetComponent<RawImage>().color = new Color(0.96863f,  0.58039f,  0.11373f); }
            if (i == 7) { newObj.GetComponent<RawImage>().color = new Color(0.92941f,  0.10980f,  0.14118f); }  
            newObj.name = "DrumCell_"+ i.ToString();  
            newObj.tag = "drum_cell";                                                   
        }
    } 

    void PopulateSampleRow(int numberToCreate) {
        for (int i = 0; i < numberToCreate; i++) {
            GameObject newObj;
            newObj = (GameObject)Instantiate(prefab, transform); 
            newObj.GetComponent<RawImage>().color = new Color(0.3f, 0.3f, 0.3f); 
            newObj.name = "SampleCell_"+ i.ToString();  
            newObj.tag = "sample_cell"; 
            textmeshPro = GameObject.Find("SampleCell_"+ i.ToString()).GetComponentInChildren<TextMeshProUGUI>(); 
            textmeshPro.text = (i+1).ToString(); 
            newObj.GetComponent<IndexObject>().samplePad = true;  
            newObj.GetComponent<IndexObject>().samplePadNum = i;                                              
        }
    }     

    public void PopulateRollFunction(int numberToPass) {
        if (sampleRoll == true) {
            PopulateSampleRow(numberToPass);
        }
        else {
            PopulateRow(numberToPass);
        }
    }                          
}
