using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class PopulateGrid_Sample : MonoBehaviour
{
    public GameObject prefab;
    public GameObject sequencerIndexObject;
    public GameObject sampleSequencer;
    public int rowCount = -1;
    public GameObject cell;
    public string noteName;
    public int groupTotal = 1;
    public int stepCellsTotal = -1;    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PopulateGroup(16));
    }

    void PopulateWhiteRow(int numberToCreate) {
        GameObject newObj;
        rowCount++;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(cell, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f); 
            newObj.name = noteName+rowCount+"_"+i; 
            newObj.tag = "sample_cell_white"; 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                
        } 
    }   

    void PopulateBlackRow(int numberToCreate) {
        GameObject newObj;
        rowCount++;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(cell, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);   
            newObj.name = noteName+rowCount+"_"+i;
            newObj.tag = "sample_cell_black";  
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                               
        } 
    }                            

    public void PopulateSampleGridFunction(int numberToPass) {
        rowCount = -1;
        stepCellsTotal = -1;
        GameObject[] cells = GameObject.FindGameObjectsWithTag("sample_cell");
        foreach(GameObject cell in cells) { 
            GameObject.Destroy(cell);
        }    
        StartCoroutine(PopulateGroup(numberToPass));                                                        
    }                          

    public void ReColorGridFunction() {
        GameObject[] whitecells = GameObject.FindGameObjectsWithTag("sample_cell_white");
        foreach(GameObject cell in whitecells) { 
            cell.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f); 
        }  

        GameObject[] blackcells = GameObject.FindGameObjectsWithTag("sample_cell_black");
        foreach(GameObject cell in blackcells) { 
            cell.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);
        }         
    }    

    IEnumerator PopulateGroup(int numberToPass) {
        yield return new WaitForSeconds(0);

        for (int i = 0; i < groupTotal; i++) {
            PopulateBlackRow(numberToPass);
            PopulateWhiteRow(numberToPass);             
            PopulateBlackRow(numberToPass);            
            PopulateWhiteRow(numberToPass);
            PopulateWhiteRow(numberToPass);            
            PopulateBlackRow(numberToPass);
            PopulateWhiteRow(numberToPass);             
            PopulateBlackRow(numberToPass);
            PopulateWhiteRow(numberToPass);            
            PopulateBlackRow(numberToPass);
            PopulateWhiteRow(numberToPass);
            PopulateWhiteRow(numberToPass);
            PopulateBlackRow(numberToPass);
            PopulateWhiteRow(numberToPass);            
            PopulateBlackRow(numberToPass);
            PopulateWhiteRow(numberToPass);
        }                       
    }        
}
