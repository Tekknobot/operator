using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using UnityEngine.UI;

public class SaveManagerPro : MonoBehaviour
{
    public GameObject synthSequencer;
    public GameObject drumSequencer;
    public GameObject sampleSequencer;

    public AudioHelm.Note noteTemp;

    public GameObject sequencerButton;

    public GameObject drumSeqContent;
    public GameObject synthSeqContent;
    public GameObject sampleSeqContent;

    public GameObject loadingText;

    void Awake() {
        //PlayerPrefs.DeleteAll();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LoadNotesIntoSeq() {
        synthSequencer.GetComponent<HelmSequencer>().Clear();
        yield return new WaitForSeconds(1f);
        //Load notes into Synth Sequencer
        for (int i = 0; i < 84; i++) {
            for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                for (int k = 0; k < 16; k++) {
                    if (PlayerPrefs.GetInt("Seq_1_" + (108-i) +"_"+ j +"_"+ (j+k)) == 1) {
                        synthSequencer.GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+k);
                        noteTemp = synthSequencer.GetComponent<AudioHelm.HelmSequencer>().GetNoteInRange(108-i, j, j+k);           
                        for (int h = 0; h < (noteTemp.end_ - noteTemp.start_); h++) { 
                            GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<RawImage>().color = Color.red;
                            GameObject.Find("Row_"+ i +"_"+(noteTemp.start_+h)).GetComponent<Outline>().effectDistance = new Vector2(0, -1);                                                           
                            GameObject.Find("Row_"+ (108-noteTemp.note) +"_"+(noteTemp.start_)).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        }                    
                    }
                }
            }	
        }         
    }  

    public IEnumerator LoadDrumNotesIntoSeq() {
        drumSequencer.GetComponent<SampleSequencer>().Clear();
        yield return new WaitForSeconds(1f);
        //Load notes into Synth Sequencer
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().length; j++) {
                if (PlayerPrefs.GetInt("Drum_1_" + (67-i) +"_"+ j) == 1) {
                    drumSequencer.GetComponent<SampleSequencer>().AddNote(67-i, j, j+1);           
                    GameObject.Find("DrumRow_"+i+"_"+ j).GetComponent<RawImage>().color = Color.red;                    
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
                if (PlayerPrefs.GetInt("Sample_1_" + (75-i) +"_"+ j) == 1) {
                    sampleSequencer.GetComponent<SampleSequencer>().AddNote(75-i, j, j+1);           
                    GameObject.Find("SampleRow_"+i+"_"+ j).GetComponent<RawImage>().color = Color.red;                    
                }
            }	
        }      
    }       

    public IEnumerator ClearSequencer() {
        loadingText.SetActive(true);
        yield return new WaitForSeconds(0);
        if (sequencerButton.GetComponent<SequencerButton>().sequencer == 1) {
            synthSequencer.GetComponent<HelmSequencer>().Clear();
            GameObject[] synthCells = GameObject.FindGameObjectsWithTag("synth_cell");
            synthSeqContent.GetComponent<PopulateGrid_Synth>().PopulateSynthGridFunction(GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length);         
            for (int i = 0; i < 84; i++) { 
                for (int h = 0; h < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; h++) {
                    for (int j = 0; j < 16; j++) {       
                        PlayerPrefs.SetInt("Seq_1_" + (108-i) +"_"+ h +"_"+ (h+j), 0);
                    }
                }                                                               
            }                  
        }
        if (sequencerButton.GetComponent<SequencerButton>().sequencer == 0) {
            drumSequencer.GetComponent<SampleSequencer>().Clear();
            GameObject[] drumCells = GameObject.FindGameObjectsWithTag("drum_cell");
            drumSeqContent.GetComponent<PopulateGrid_Drums>().PopulateGridFunction(GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().length);   
            foreach (GameObject cell in drumCells) {
                cell.GetComponent<ChangeCellColorPro>().RemoveNotesFromDrumSequencer(cell);
            }        
        }        
        if (sequencerButton.GetComponent<SequencerButton>().sequencer == 2) {
            sampleSequencer.GetComponent<SampleSequencer>().Clear();
            GameObject[] sampleCells = GameObject.FindGameObjectsWithTag("sample_cell");
            sampleSeqContent.GetComponent<PopulateGrid_Sample>().PopulateGridFunction(GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().length);                      
            foreach (GameObject cell in sampleCells) {
                cell.GetComponent<ChangeCellColor_Sample>().RemoveNotesFromSampleSequencer(cell);
            }         
        }
        loadingText.SetActive(false);
    }   
}
