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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void PopulateRow1(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);  
            newObj.name = "SampleRow_0_"+ i.ToString();  
            newObj.tag = "sample_cell";                 
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
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);   
            newObj.name = "SampleRow_1_"+ i.ToString();   
            newObj.tag = "sample_cell";  
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
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);
            newObj.name = "SampleRow_2_"+ i.ToString(); 
            newObj.tag = "sample_cell"; 
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
            newObj.name = "SampleRow_3_"+ i.ToString();
            newObj.tag = "sample_cell";
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
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);  
            newObj.name = "SampleRow_4_"+ i.ToString();                                                       
            newObj.tag = "sample_cell";
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
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);  
            newObj.name = "SampleRow_5_"+ i.ToString();
            newObj.tag = "sample_cell"; 
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
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f); 
            newObj.name = "SampleRow_6_"+ i.ToString(); 
            newObj.tag = "sample_cell";  
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
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);
            newObj.name = "SampleRow_7_"+ i.ToString(); 
            newObj.tag = "sample_cell"; 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                    
        }
    }    

    void PopulateRow9(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
            newObj.name = "SampleRow_8_"+ i.ToString(); 
            newObj.tag = "sample_cell"; 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                    
        }
    }  

    void PopulateRow10(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);
            newObj.name = "SampleRow_9_"+ i.ToString(); 
            newObj.tag = "sample_cell"; 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                    
        }
    }     

    void PopulateRow11(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
            newObj.name = "SampleRow_10_"+ i.ToString(); 
            newObj.tag = "sample_cell"; 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                    
        }
    }   

    void PopulateRow12(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
            newObj.name = "SampleRow_11_"+ i.ToString(); 
            newObj.tag = "sample_cell"; 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                    
        }
    }   

    void PopulateRow13(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);
            newObj.name = "SampleRow_12_"+ i.ToString(); 
            newObj.tag = "sample_cell"; 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                    
        }
    }   

    void PopulateRow14(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
            newObj.name = "SampleRow_13_"+ i.ToString(); 
            newObj.tag = "sample_cell"; 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                    
        }
    }   

    void PopulateRow15(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);
            newObj.name = "SampleRow_14_"+ i.ToString(); 
            newObj.tag = "sample_cell"; 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                    
        }
    }   

    void PopulateRow16(int numberToCreate) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
            newObj.name = "SampleRow_15_"+ i.ToString(); 
            newObj.tag = "sample_cell"; 
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }                                                                    
        }
    }                            

    public void PopulateGridFunction(int numberToPass) {
        GameObject[] cells = GameObject.FindGameObjectsWithTag("sample_cell");
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

        PopulateRow9(numberToPass);
        PopulateRow10(numberToPass);
        PopulateRow11(numberToPass);
        PopulateRow12(numberToPass);
        PopulateRow13(numberToPass);
        PopulateRow14(numberToPass);
        PopulateRow15(numberToPass);
        PopulateRow16(numberToPass);                                                        
    }                          
}
