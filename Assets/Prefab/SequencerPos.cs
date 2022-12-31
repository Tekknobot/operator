using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using UnityEngine.UI;

public class SequencerPos : MonoBehaviour
{
    public GameObject drumSeqeuncer;
    public GameObject synthSequencer;
    public GameObject sampleSequencer;
    public GameObject audioHelmClock;

    // Start is called before the first frame update
    void Awake()
    {
        audioHelmClock.GetComponent<AudioHelmClock>().pause = true;
        audioHelmClock.GetComponent<AudioHelmClock>().Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Cell_"+ drumSeqeuncer.GetComponent<SampleSequencer>().currentIndex)) {
            var colors = GameObject.Find("Cell_"+ drumSeqeuncer.GetComponent<SampleSequencer>().currentIndex.ToString()).GetComponent<Button>().colors;
            colors.normalColor = Color.grey;
            GameObject.Find("Cell_"+ drumSeqeuncer.GetComponent<SampleSequencer>().currentIndex.ToString()).GetComponent<Button>().colors = colors;
            //GameObject.Find("SQPOS_SYNTH "+ synthSequencer.GetComponent<HelmSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
            //GameObject.Find("SQPOS_SAMPLE "+ sampleSequencer.GetComponent<SampleSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
        }
    }
}
