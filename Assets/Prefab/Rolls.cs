using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rolls : MonoBehaviour
{
    public int roll = 0;
    public GameObject drum;
    public GameObject sample;

    TextMeshProUGUI textmeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GameObject.Find("Rolls").GetComponentInChildren<TextMeshProUGUI>();
        textmeshPro.text = "A";
        RollButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollButton() {
        if (roll == 0) {
            textmeshPro.text = "A";
            RectTransform drumRectTransform = drum.GetComponent<RectTransform>();
            drumRectTransform.localPosition = new Vector3(0, -117.93f, 0);
            RectTransform sampleRectTransform = sample.GetComponent<RectTransform>();
            sampleRectTransform.localPosition = new Vector3(0, 500, 0);             
            roll = 1;
        }
        else if (roll == 1) {
            textmeshPro.text = "B";
            RectTransform drumRectTransform = drum.GetComponent<RectTransform>();
            drumRectTransform.localPosition = new Vector3(0, 500, 0);
            RectTransform sampleRectTransform = sample.GetComponent<RectTransform>();
            sampleRectTransform.localPosition = new Vector3(0, -117.93f, 0);              
            roll = 0;
        }        
    }
}
