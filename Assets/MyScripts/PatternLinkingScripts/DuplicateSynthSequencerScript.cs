using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using UnityEngine.UI;
using TMPro;

public class DuplicateSynthSequencerScript : MonoBehaviour
{
    public int x = 0;
    public GameObject temp;
    TextMeshProUGUI textmeshPro;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DuplicateSynthSequencer() {
        GameObject SynthSequencer = GameObject.Instantiate(GameObject.Find("SynthSequencer"), new Vector3(1000, 0, 0), Quaternion.identity);
        SynthSequencer.name = "SynthSequencer_"+ (x+1);
        SynthSequencer.GetComponent<AudioHelm.HelmSequencer>().enabled = true;
        SynthSequencer.GetComponent<AudioHelm.HelmSequencer>().loop = true;
        textmeshPro = GameObject.Find("TotalPatternsText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = (x+1).ToString(); 
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = (x+1).ToString();        
        x++;
    }

    public void DeleteSynthSequencer() {
        if (x <= 0) {  
            temp = GameObject.Find("SynthSequencer_"+ x);
            Destroy(temp);
            x = 0;            
            return; 
        }
        temp = GameObject.Find("SynthSequencer_"+ x);
        Destroy(temp);        
        x--;
        textmeshPro = GameObject.Find("TotalPatternsText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = (x-1).ToString();
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = (x-1).ToString();                    
    }    
}
