using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class PopulateGrid_Synth : MonoBehaviour
{
    public GameObject cell;
    public int groupTotal = 7;
    public string noteName;
    public int rowCount = -1;
    public int stepCellsTotal = -1;

    public GameObject synthSequencer;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update() {
        
    }

    void PopulateWhiteRow(int numberToCreate) {
        GameObject newObj;
        rowCount++;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(cell, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f); 
            newObj.name = noteName+rowCount+"_"+i; 
            newObj.tag = "synth_cell"; 
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
            newObj.tag = "synth_cell";  
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                               
        } 
    }            

    public void PopulateSynthGridFunction(int numberToPass) {
        rowCount = -1;
        stepCellsTotal = -1;
        GameObject[] cells = GameObject.FindGameObjectsWithTag("synth_cell");
        foreach(GameObject cell in cells) { 
            GameObject.Destroy(cell);
        }    

        StartCoroutine(PopulateGroup(numberToPass));
    }      

    IEnumerator PopulateGroup(int numberToPass) {
        yield return new WaitForSeconds(0);

        for (int i = 0; i < groupTotal; i++) {
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
        }
    }             
}
