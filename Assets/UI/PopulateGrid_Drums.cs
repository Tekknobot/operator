using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class PopulateGrid_Drums : MonoBehaviour
{
    public GameObject prefab;
    public GameObject sequencerIndexObject;
    public GameObject drumSequencer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void PopulateRow1(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);  
            newObj.name = "DrumRow_0_"+ i.ToString();  
            newObj.tag = "drum_cell";                 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1); 
            }                                   
        }
    }

    void PopulateRow2(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);   
            newObj.name = "DrumRow_1_"+ i.ToString();   
            newObj.tag = "drum_cell";  
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                             
        }
    }

    void PopulateRow3(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
            newObj.name = "DrumRow_2_"+ i.ToString(); 
            newObj.tag = "drum_cell"; 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                    
        }
    }

    void PopulateRow4(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
            newObj.name = "DrumRow_3_"+ i.ToString();
            newObj.tag = "drum_cell";
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                      
        }
    }

    void PopulateRow5(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);  
            newObj.name = "DrumRow_4_"+ i.ToString();                                                       
            newObj.tag = "drum_cell";
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }             
        }
    }

    void PopulateRow6(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);  
            newObj.name = "DrumRow_5_"+ i.ToString();
            newObj.tag = "drum_cell"; 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                   
        }
    }

    void PopulateRow7(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f); 
            newObj.name = "DrumRow_6_"+ i.ToString(); 
            newObj.tag = "drum_cell";  
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                  
        }
    }    

    void PopulateRow8(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
            newObj.name = "DrumRow_7_"+ i.ToString(); 
            newObj.tag = "drum_cell"; 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                    
        }
    }    

    public void PopulateGridFunction(int numberToPass) {
        GameObject[] cells = GameObject.FindGameObjectsWithTag("drum_cell");
        foreach(GameObject cell in cells) { 
            GameObject.Destroy(cell);
        }

        PopulateRow1(numberToPass);
        PopulateRow2(numberToPass);
        PopulateRow3(numberToPass);
        PopulateRow4(numberToPass);
        PopulateRow5(numberToPass);
        PopulateRow6(numberToPass);
        PopulateRow7(numberToPass);
        PopulateRow8(numberToPass);
    }                          
}
