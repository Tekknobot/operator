using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public GameObject drumSequencer;
    public GameObject sampleSequencer;
    public AudioHelm.Note noteTemp;

    void Awake() {
        //PlayerPrefs.DeleteAll();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadDrumNotesIntoSeq());
        StartCoroutine(LoadSampleNotesIntoSeq());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LoadDrumNotesIntoSeq() {
        drumSequencer.GetComponent<SampleSequencer>().Clear();
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < GameObject.Find("DrumSequencer").GetComponent<AudioHelm.SampleSequencer>().length; j++) {
                if (PlayerPrefs.GetInt("Drum_" + (60+i) +"_"+ j) == 1) {
                    drumSequencer.GetComponent<SampleSequencer>().AddNote(60+i, j, j+1);                               
                }
            }	
        }      
    }  

    public IEnumerator LoadSampleNotesIntoSeq() {
        sampleSequencer.GetComponent<SampleSequencer>().Clear();
        yield return new WaitForSeconds(1f);
        //Load notes into Synth Sequencer
        for (int i = 0; i < 16; i++) {
            for (int j = 0; j < GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().length; j++) {
                if (PlayerPrefs.GetInt("Sample_" + (60+i) +"_"+j) == 1) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(60+i, j, j+1);           
                    //GameObject.Find("Cell_"+i).GetComponent<RawImage>().color = new Color(0.3f, 0.3f, 0.3f);                    
                }
            }	
        }      
    }            
}
