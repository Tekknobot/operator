using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public GameObject drumSequencer;
    public AudioHelm.Note noteTemp;

    void Awake() {
        //PlayerPrefs.DeleteAll();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadDrumNotesIntoSeq());
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
}
