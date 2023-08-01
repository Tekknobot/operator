using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButton : MonoBehaviour
{
    public GameObject saveManager;
    public GameObject synthContent;
    public GameObject synthSeqVertBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearOnClick() {
        StartCoroutine(saveManager.GetComponent<SaveManagerPro>().ClearSequencer());
        synthContent.GetComponent<PopulatePianoRoll_Synth>().PopulateRollAgain("SynthNote ");
        PlayerPrefs.GetFloat("CurrentSynthBarValue ", synthSeqVertBar.GetComponent<ScrollbarStartTop>().currentBarValue);
    }
}
