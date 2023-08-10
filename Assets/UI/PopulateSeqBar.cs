using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateSeqBar : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        PopulateBar(16);
        PopulateSampleBar(16);
        PopulateSynthBar(16);
    }

    public void PopulateBar(int numberToCycle) {
        GameObject[] cells = GameObject.FindGameObjectsWithTag("drumSeq_cell");
        foreach(GameObject cell in cells) { 
            GameObject.Destroy(cell);
        }

        GameObject newObj;
        for (int i = 0; i < numberToCycle; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.name = "SQPOS "+ i.ToString(); 
            newObj.tag = "drumSeq_cell";                                                       
        }        
    } 

    public void PopulateSampleBar(int numberToCycle) {
        GameObject[] cells = GameObject.FindGameObjectsWithTag("sampleSeq_cell");
        foreach(GameObject cell in cells) { 
            GameObject.Destroy(cell);
        }

        GameObject newObj;
        for (int i = 0; i < numberToCycle; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.name = "SQPOS_SAMPLE "+ i.ToString(); 
            newObj.tag = "sampleSeq_cell";                                                       
        }        
    }     

    public void PopulateSynthBar(int numberToCycle) {
        GameObject[] cells = GameObject.FindGameObjectsWithTag("synthSeq_cell");
        foreach(GameObject cell in cells) { 
            GameObject.Destroy(cell);
        }

        GameObject newObj;
        for (int i = 0; i < numberToCycle; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.name = "SQPOS_SYNTH "+ i.ToString(); 
            newObj.tag = "synthSeq_cell";                                                       
        }        
    }                               
}
