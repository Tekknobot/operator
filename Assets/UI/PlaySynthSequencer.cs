using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using UnityEngine.UI;

public class PlaySynthSequencer : MonoBehaviour
{
    public GameObject drumSampler;
    bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < drumSampler.GetComponent<SampleSequencer>().length; i++) {
            if (GameObject.Find("KICK " + i.ToString()).GetComponent<RawImage>().color == Color.red && drumSampler.GetComponent<SampleSequencer>().currentIndex == i && flag == false) {
                drumSampler.GetComponent<Sampler>().NoteOn(i+60);
                flag = true;
            }
            else if (GameObject.Find("KICK "+ i.ToString()) && drumSampler.GetComponent<SampleSequencer>().currentIndex != i) {
                drumSampler.GetComponent<Sampler>().NoteOff(i+60);
                flag = false;
            }
        }
    }
}
