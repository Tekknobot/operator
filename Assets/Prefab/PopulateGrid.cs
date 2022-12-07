using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab;
    public int length;

    // Start is called before the first frame update
    void Start()
    {
        PopulateGridFunction(length);
    }

    void PopulateRow(int numberToCreate) {
        for (int i = 0; i < numberToCreate; i++) {
            GameObject newObj;
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);  
            newObj.name = "Cell_"+ i.ToString();  
            newObj.tag = "cell"; 
            newObj.GetComponent<IndexObject>().step = i;                
            if (i % 4 == 0) {
                newObj.GetComponent<Outline>().effectColor = Color.white;
                newObj.GetComponent<Outline>().effectDistance = new Vector2(1, -1); 
            }                                   
        }
    }  

    public void PopulateGridFunction(int numberToPass) {
        GameObject[] cells = GameObject.FindGameObjectsWithTag("cell");
        foreach(GameObject cell in cells) { 
            GameObject.Destroy(cell);
        }

        PopulateRow(numberToPass);
    }                          
}
