using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class ShowCurrentPatternScript : MonoBehaviour
{
    public int x;
    public AudioHelm.Note noteTemp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().x;
    }

    public void ShowCurrentPattern() {
        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();
        StartCoroutine(GameObject.Find("SaveManager").GetComponent<SaveManagerPro>().ClearSequencer());     
        StartCoroutine(LoadNotesIntoSeq());   
    }

    public IEnumerator LoadNotesIntoSeq() {
        yield return new WaitForSeconds(1f);
        //Load notes into Synth Sequencer
        for (int i = 0; i < 84; i++) {
            for (int j = 0; j < GameObject.Find("SynthSequencer_" + x).GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                for (int k = 0; k < 16; k++) {
                    if (GameObject.Find("SynthSequencer_" + x).GetComponent<AudioHelm.HelmSequencer>().NoteExistsInRange(i, j, k)) {
                        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, k);
                        noteTemp = GameObject.Find("SynthSequencer_" + x).GetComponent<AudioHelm.HelmSequencer>().GetNoteInRange(108-i, j, k);           
                        for (int h = 0; h < (noteTemp.end_ - (noteTemp.start_)); h++) { 
                            GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<RawImage>().color = Color.red;
                            GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                            GameObject.Find("Row_"+ (108-noteTemp.note) +"_"+(noteTemp.start_)).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        }                    
                    }
                }
            }	
        }      
    }     
}
