using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class LengthSlider_Synth : MonoBehaviour
{
    Slider mySlider = null;
    public GameObject seqBarContent;
    public GameObject synthSeqBarContent;
    public GameObject drumContent;
    public GameObject synthContent;

    public GameObject saveManager;
    public Toggle playButton;
 
    public GameObject loadingText;

    // Start is called before the first frame update
    void Start()
    {
        mySlider = GetComponent<Slider>();
        StartCoroutine(WaitFor());
    }

    public void UpdateSlider()
    {
        if (mySlider.value == 1) {
            loadingText.SetActive(true);
            playButton.isOn = false;
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length = 16;

            synthSeqBarContent.GetComponent<PopulateSeqBar>().PopulateSynthBar(16);
            synthContent.GetComponent<PopulateGrid_Synth>().rowCount = -1;
            synthContent.GetComponent<PopulateGrid_Synth>().PopulateSynthGridFunction(16);
            synthContent.GetComponent<GridLayoutGroup>().constraintCount = 16;

            StartCoroutine(saveManager.GetComponent<SaveManagerPro>().LoadNotesIntoSeq());
        }
        else if (mySlider.value == 2) {
            loadingText.SetActive(true);
            playButton.isOn = false;
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length = 32;

            synthSeqBarContent.GetComponent<PopulateSeqBar>().PopulateSynthBar(32);
            synthContent.GetComponent<PopulateGrid_Synth>().rowCount = -1;
            synthContent.GetComponent<PopulateGrid_Synth>().PopulateSynthGridFunction(32);
            synthContent.GetComponent<GridLayoutGroup>().constraintCount = 32;

            StartCoroutine(saveManager.GetComponent<SaveManagerPro>().LoadNotesIntoSeq());
        }
        else if (mySlider.value == 3) {
            loadingText.SetActive(true);
            playButton.isOn = false;
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length = 64;

            synthSeqBarContent.GetComponent<PopulateSeqBar>().PopulateSynthBar(64);
            synthContent.GetComponent<PopulateGrid_Synth>().rowCount = -1;
            synthContent.GetComponent<PopulateGrid_Synth>().PopulateSynthGridFunction(64);   
            synthContent.GetComponent<GridLayoutGroup>().constraintCount = 64;     

            StartCoroutine(saveManager.GetComponent<SaveManagerPro>().LoadNotesIntoSeq());               
        }                                    
    }    

    IEnumerator WaitFor() {
        yield return new WaitForSeconds(0.1f);
        UpdateSlider();
    }
}
