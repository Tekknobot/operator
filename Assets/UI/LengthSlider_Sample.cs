using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class LengthSlider_Sample : MonoBehaviour
{
    Slider mySlider = null;
    public GameObject seqBarContent;
    public GameObject sampleContent;

    public GameObject saveManager;
    public Toggle playButton;
 
    // Start is called before the first frame update
    void Start()
    {
        mySlider = GetComponent<Slider>();
        //StartCoroutine(WaitFor());
    }
 
    public void UpdateSlider()
    {
        if (mySlider.value == 1) {
            playButton.isOn = false;
            GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().length = 16;            
            seqBarContent.GetComponent<PopulateSeqBar>().PopulateSampleBar(16);
            sampleContent.GetComponent<PopulateGrid_Sample>().PopulateGridFunction(16);
            sampleContent.GetComponent<GridLayoutGroup>().constraintCount = 16;

            //StartCoroutine(saveManager.GetComponent<SaveManager>().LoadSampleNotesIntoSeq());
        }
        if (mySlider.value == 2) {
            playButton.isOn = false;
            GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().length = 32;
            seqBarContent.GetComponent<PopulateSeqBar>().PopulateSampleBar(32);
            sampleContent.GetComponent<PopulateGrid_Sample>().PopulateGridFunction(32);
            sampleContent.GetComponent<GridLayoutGroup>().constraintCount = 32;

            //StartCoroutine(saveManager.GetComponent<SaveManager>().LoadSampleNotesIntoSeq());
        }
        if (mySlider.value == 3) {
            playButton.isOn = false;
            GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().length = 64;
            seqBarContent.GetComponent<PopulateSeqBar>().PopulateSampleBar(64);
            sampleContent.GetComponent<PopulateGrid_Sample>().PopulateGridFunction(64);
            sampleContent.GetComponent<GridLayoutGroup>().constraintCount = 64;    

            //StartCoroutine(saveManager.GetComponent<SaveManager>().LoadSampleNotesIntoSeq());             
        }                                    
    }

    IEnumerator WaitFor() {
        yield return new WaitForSeconds(0.1f);
        UpdateSlider();
    }
}
