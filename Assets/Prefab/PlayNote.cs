using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using UnityEngine.UI;

public class PlayNote : MonoBehaviour
{
    public RawImage img;
    public Color gridCellColor;
    public GameObject synthSequencer;
    bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySynthRoll() {
        for (int i = 0; i < synthSequencer.GetComponent<HelmSequencer>().length; i++) {
            if (GameObject.Find("SynthNote "+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                synthSequencer.GetComponent<Sampler>().NoteOn(21+i);
            }     
        }                        
    }    
}
