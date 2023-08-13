using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using UnityEngine.UI;

public class SequencerPosPro : MonoBehaviour
{
    public GameObject drumSequencer;
    public GameObject synthSequencer;
    public GameObject sampleSequencer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.Find("SQPOS "+ drumSequencer.GetComponent<SampleSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
        //GameObject.Find("SQPOS_SYNTH "+ synthSequencer.GetComponent<HelmSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
        GameObject.Find("SQPOS_SAMPLE "+ sampleSequencer.GetComponent<SampleSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;

        if (GameObject.Find("SynthSequencer_1") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 1) {
            GameObject.Find("SQPOS_SYNTH "+ GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
        }
        if (GameObject.Find("SynthSequencer_2") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 2) {
            GameObject.Find("SQPOS_SYNTH "+ GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
        }
        if (GameObject.Find("SynthSequencer_3") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 3) {
            GameObject.Find("SQPOS_SYNTH "+ GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
        }
        if (GameObject.Find("SynthSequencer_4") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 4) {
            GameObject.Find("SQPOS_SYNTH "+ GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
        }       

        //////////

        if (GameObject.Find("DrumSampler_1") && GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().currentPatternDrum == 1) {
            GameObject.Find("SQPOS "+ GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
        }
        if (GameObject.Find("DrumSampler_2") && GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().currentPatternDrum == 2) {
            GameObject.Find("SQPOS "+ GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.SampleSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
        }
        if (GameObject.Find("DrumSampler_3") && GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().currentPatternDrum == 3) {
            GameObject.Find("SQPOS "+ GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.SampleSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
        }
        if (GameObject.Find("DrumSampler_4") && GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().currentPatternDrum == 4) {
            GameObject.Find("SQPOS "+ GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.SampleSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
        }                             
    }
}
