using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class LengthSlider : MonoBehaviour
{
    Slider mySlider = null;
    public GameObject seqBarContent;
    public GameObject synthSeqBarContent;
    public GameObject drumContent;
    public GameObject synthContent;

    public GameObject saveManager;
    public Toggle playButton;
 
    // Start is called before the first frame update
    // void Start()
    // {
    //     mySlider = GetComponent<Slider>();
    //     StartCoroutine(WaitFor());
    // }
 
    // public void UpdateSlider()
    // {
    //     if (mySlider.value == 1) {
    //         playButton.isOn = false;
    //         GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().length = 16;            
    //         seqBarContent.GetComponent<PopulateSeqBar>().PopulateBar(16);
    //         drumContent.GetComponent<PopulateGrid_Drums>().PopulateGridFunction(16);
    //         drumContent.GetComponent<GridLayoutGroup>().constraintCount = 16;

    //         StartCoroutine(saveManager.GetComponent<SaveManagerPro>().LoadDrumNotesIntoSeq());
    //     }
    //     if (mySlider.value == 2) {
    //         playButton.isOn = false;
    //         GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().length = 32;
    //         seqBarContent.GetComponent<PopulateSeqBar>().PopulateBar(32);
    //         drumContent.GetComponent<PopulateGrid_Drums>().PopulateGridFunction(32);
    //         drumContent.GetComponent<GridLayoutGroup>().constraintCount = 32;

    //         StartCoroutine(saveManager.GetComponent<SaveManagerPro>().LoadDrumNotesIntoSeq());
    //     }
    //     if (mySlider.value == 3) {
    //         playButton.isOn = false;
    //         GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().length = 64;
    //         seqBarContent.GetComponent<PopulateSeqBar>().PopulateBar(64);
    //         drumContent.GetComponent<PopulateGrid_Drums>().PopulateGridFunction(64);
    //         drumContent.GetComponent<GridLayoutGroup>().constraintCount = 64;    

    //         StartCoroutine(saveManager.GetComponent<SaveManagerPro>().LoadDrumNotesIntoSeq());             
    //     }                                    
    // }

    // IEnumerator WaitFor() {
    //     yield return new WaitForSeconds(0.1f);
    //     UpdateSlider();
    // }
}
