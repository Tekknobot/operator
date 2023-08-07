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

        if (PlayerPrefs.GetInt("SequencerCount") > 0) {
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern = PlayerPrefs.GetInt("SequencerCount");
            LoadPatternSequencers();
        }        
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
        yield return new WaitForSeconds(0.1f);
        //Load notes into Synth Sequencer
        for (int i = 0; i < 84; i++) {
            for (int j = 0; j < GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                for (int k = 0; k < 16; k++) {
                    if (PlayerPrefs.GetInt("Seq_1_" + (108-i) +"_"+ j +"_"+ (j+1)) == 1) {
                        synthSequencer.GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                        noteTemp = synthSequencer.GetComponent<AudioHelm.HelmSequencer>().GetNoteInRange(108-i, j, j+1);           
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

    public IEnumerator LoadDrumNotesIntoSeq() {
        drumSequencer.GetComponent<SampleSequencer>().Clear();
        yield return new WaitForSeconds(0.1f);
        //Load notes into Drumn Sequencer
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
        yield return new WaitForSeconds(0.1f);
        //Load notes into Sample Sequencer
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

        if (GameObject.Find("SynthSequencer_1") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 1) {
            GameObject.Find("SynthSequencer_1").GetComponent<HelmSequencer>().Clear();
            GameObject[] synthCells = GameObject.FindGameObjectsWithTag("synth_cell");
            //synthSeqContent.GetComponent<PopulateGrid_Synth>().PopulateSynthGridFunction(GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length);         
            synthSeqContent.GetComponent<PopulateGrid_Synth>().ReColorGridFunction();                     
            for (int i = 0; i < 84; i++) { 
                for (int h = 0; h < GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().length; h++) {
                    for (int j = 0; j < 16; j++) {       
                        PlayerPrefs.SetInt("SynthSeq_1_" + (108-i) +"_"+ h +"_"+ (h+j), 0);
                    }
                    loadingText.SetActive(false);
                }                                                               
            }                  
        }  
        if (GameObject.Find("SynthSequencer_2") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 2) {
            GameObject.Find("SynthSequencer_2").GetComponent<HelmSequencer>().Clear();
            GameObject[] synthCells = GameObject.FindGameObjectsWithTag("synth_cell");
            //synthSeqContent.GetComponent<PopulateGrid_Synth>().PopulateSynthGridFunction(GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length);         
            synthSeqContent.GetComponent<PopulateGrid_Synth>().ReColorGridFunction();
            for (int i = 0; i < 84; i++) { 
                for (int h = 0; h < GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().length; h++) {
                    for (int j = 0; j < 16; j++) {       
                        PlayerPrefs.SetInt("SynthSeq_2_" + (108-i) +"_"+ h +"_"+ (h+j), 0);
                    }
                    loadingText.SetActive(false);
                }                                                               
            }                  
        }    
        if (GameObject.Find("SynthSequencer_3") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 3) {
            GameObject.Find("SynthSequencer_3").GetComponent<HelmSequencer>().Clear();
            GameObject[] synthCells = GameObject.FindGameObjectsWithTag("synth_cell");
            //synthSeqContent.GetComponent<PopulateGrid_Synth>().PopulateSynthGridFunction(GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length);         
            synthSeqContent.GetComponent<PopulateGrid_Synth>().ReColorGridFunction();
            for (int i = 0; i < 84; i++) { 
                for (int h = 0; h < GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().length; h++) {
                    for (int j = 0; j < 16; j++) {       
                        PlayerPrefs.SetInt("SynthSeq_3_" + (108-i) +"_"+ h +"_"+ (h+j), 0);
                    }
                    loadingText.SetActive(false);
                }                                                               
            }                  
        }    
        if (GameObject.Find("SynthSequencer_4") && GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 4) {
            GameObject.Find("SynthSequencer_4").GetComponent<HelmSequencer>().Clear();
            GameObject[] synthCells = GameObject.FindGameObjectsWithTag("synth_cell");
            //synthSeqContent.GetComponent<PopulateGrid_Synth>().PopulateSynthGridFunction(GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length);         
            synthSeqContent.GetComponent<PopulateGrid_Synth>().ReColorGridFunction();
            for (int i = 0; i < 84; i++) { 
                for (int h = 0; h < GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().length; h++) {
                    for (int j = 0; j < 16; j++) {       
                        PlayerPrefs.SetInt("SynthSeq_4_" + (108-i) +"_"+ h +"_"+ (h+j), 0);
                    }
                    loadingText.SetActive(false);
                }                                                               
            }                  
        }      
    }

    public void LoadPatternSequencers() {
        int loop = PlayerPrefs.GetInt("SequencerCount");
        for (int i = 0; i < loop; i++) { 
            GameObject.Find("AddPattern").GetComponent<DuplicateSynthSequencerScript>().DuplicateSynthSequencer();        
        }
        StartCoroutine(LoadPatternNotesIntoSeq());
    }

    public IEnumerator LoadPatternNotesIntoSeq() {
        synthSequencer.GetComponent<HelmSequencer>().Clear();
        yield return new WaitForSeconds(1f);
        //Load notes into Synth Sequencer

        if (GameObject.Find("SynthSequencer_1")) {
            for (int i = 0; i < 84; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    for (int k = 0; k < 16; k++) {
                        if (PlayerPrefs.GetInt("SynthSeq_1_" + (108-i) +"_"+ j +"_"+ (j+1)) == 1) {
                            GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                        }
                    }	
                }      
            } 
        }

        if (GameObject.Find("SynthSequencer_2")) {
            for (int i = 0; i < 84; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    for (int k = 0; k < 16; k++) {
                        if (PlayerPrefs.GetInt("SynthSeq_2_" + (108-i) +"_"+ j +"_"+ (j+1)) == 1) {
                            GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                        }
                    }	
                }      
            }
        }

        if (GameObject.Find("SynthSequencer_3")) {
            for (int i = 0; i < 84; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    for (int k = 0; k < 16; k++) {
                        if (PlayerPrefs.GetInt("SynthSeq_3_" + (108-i) +"_"+ j +"_"+ (j+1)) == 1) {
                            GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                        }
                    }	
                }      
            }
        }

        if (GameObject.Find("SynthSequencer_4")) {
            for (int i = 0; i < 84; i++) {
                for (int j = 0; j < GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().length; j++) {
                    for (int k = 0; k < 16; k++) {
                        if (PlayerPrefs.GetInt("SynthSeq_4_" + (108-i) +"_"+ j +"_"+ (j+1)) == 1) {
                            GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>().AddNote(108 - i, j, j+1);
                        }
                    }	
                }      
            } 
        }   
        GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPattern();                 
    }  
}
