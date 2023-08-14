using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using AudioHelm;
using System.Text.RegularExpressions;
using TMPro;
using System.Linq;
using System;

public class CellDrag : MonoBehaviour
{
    public RawImage img;
    public Color gridCellColor;
    public GameObject synthSequencer;
    public GameObject drumSequencer;

    public int startCell;
    public int startStep;
    public int dragCellCount = 0;

    public int noteStart_temp;
    public int noteEnd_temp;

    string myString;//string with your numbers
    public int[] myNumbers;
    int number;
    
    public GameObject tempStartCell;

    public AudioHelm.Note noteTemp;	
    bool flag = false;
    PointerEventData mousePos;

    public int currentPattern;
    public int currentPatternDrum;
    public TextMeshProUGUI textmeshPro;
    public TextMeshProUGUI textmeshProDrum;    

	private string m_MyVar = null;
	public string MyVar
	{
		get {return m_MyVar;}
		set {
			if (m_MyVar == value) return;
			m_MyVar = value;
			if (OnVariableChange != null)
				OnVariableChange(m_MyVar);
		}
	}
	public delegate void OnVariableChangeDelegate(string newVal);
	public event OnVariableChangeDelegate OnVariableChange;	    

    public static bool PointerIsOverUI(Vector2 screenPos)
    {
        var hitObject = UIRaycast(ScreenPosToPointerData(screenPos));
        return hitObject != null && hitObject.layer == LayerMask.NameToLayer("UI");
    }
    
    static GameObject UIRaycast (PointerEventData pointerData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
    
        return results.Count < 1 ? null : results[0].gameObject;
    }
    
    static PointerEventData ScreenPosToPointerData (Vector2 screenPos)
        => new(EventSystem.current){position = screenPos};


    // Start is called before the first frame update
    void Start()
    {
        gridCellColor = img.GetComponent<RawImage>().color;
        synthSequencer = GameObject.Find("SynthSequencer");
        this.GetComponent<CellDrag>().OnVariableChange += VariableChangeHandler;         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
    private void VariableChangeHandler(string newVal) {
        dragCellCount++;
    }   

    public void MouseClick() {
        if (GameObject.Find("SequencerButtonText").GetComponent<TextMeshProUGUI>().text == "SYNTH") {      
            if (GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 1) {
                if (this.GetComponent<RawImage>().color == Color.red) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    noteTemp = GameObject.Find("SynthSequencer_1").GetComponent<HelmSequencer>().GetNoteInRange(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);           
                    this.GetComponent<RawImage>().color = gridCellColor;
                    UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);      
                    PlayerPrefs.SetInt("SynthSeq_1_" + (108-DecodeStringRow()) +"_"+ DecodeStringStep() +"_"+ (DecodeStringStep()+1), 0); 
                    for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                        GameObject.Find("Row_"+DecodeStringRow().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                        GameObject.Find("Row_"+DecodeStringRow().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        PlayerPrefs.SetInt("SynthSeq_1_" + (108-DecodeStringRow()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_), 0);
                        noteStart_temp = (int)noteTemp.start_+k;
                        noteEnd_temp = (int)noteTemp.end_;
                    }               
                    GameObject.Find("SynthSequencer_1").GetComponent<HelmSequencer>().RemoveNotesInRange(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);
                    PlayerPrefs.SetInt("SynthSeq_1_" + (108-DecodeStringRow()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp), 0);
                    return;
                } 
                else if (this.GetComponent<RawImage>().color == gridCellColor) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    startStep = DecodeStringStep();          
                    this.GetComponent<RawImage>().color = Color.red;
                    GameObject.Find("SynthSequencer_" + 1).GetComponent<HelmSequencer>().AddNote(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);  
                    PlayerPrefs.SetInt("SynthSeq_1_" + (108-DecodeStringRow()) +"_"+ DecodeStringStep() +"_"+ (DecodeStringStep()+1), 1); 
                } 
            }   
            if (GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 2) {
                if (this.GetComponent<RawImage>().color == Color.red) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    noteTemp = GameObject.Find("SynthSequencer_2").GetComponent<HelmSequencer>().GetNoteInRange(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);           
                    this.GetComponent<RawImage>().color = gridCellColor;
                    UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);      
                    PlayerPrefs.SetInt("SynthSeq_2_" + (108-DecodeStringRow()) +"_"+ DecodeStringStep() +"_"+ (DecodeStringStep()+1), 0); 
                    for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                        GameObject.Find("Row_"+DecodeStringRow().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                        GameObject.Find("Row_"+DecodeStringRow().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        PlayerPrefs.SetInt("SynthSeq_2_" + (108-DecodeStringRow()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_), 0);
                        Debug.Log("SynthSeq_2_" + (108-DecodeStringRow()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_));
                        noteStart_temp = (int)noteTemp.start_+k;
                        noteEnd_temp = (int)noteTemp.end_;
                    }               
                    GameObject.Find("SynthSequencer_2").GetComponent<HelmSequencer>().RemoveNotesInRange(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);
                    PlayerPrefs.SetInt("SynthSeq_2_" + (108-DecodeStringRow()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp), 0);
                    Debug.Log("SynthSeq_2_" + (108-DecodeStringRow()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp));
                    return;
                } 
                else if (this.GetComponent<RawImage>().color == gridCellColor) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    startStep = DecodeStringStep();          
                    this.GetComponent<RawImage>().color = Color.red;
                    GameObject.Find("SynthSequencer_2").GetComponent<HelmSequencer>().AddNote(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);  
                    PlayerPrefs.SetInt("SynthSeq_2_" + (108-DecodeStringRow()) +"_"+ DecodeStringStep() +"_"+ (DecodeStringStep()+1), 1); 
                } 
            }    
            if (GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 3) {
                if (this.GetComponent<RawImage>().color == Color.red) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    noteTemp = GameObject.Find("SynthSequencer_3").GetComponent<HelmSequencer>().GetNoteInRange(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);           
                    this.GetComponent<RawImage>().color = gridCellColor;
                    UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);      
                    PlayerPrefs.SetInt("SynthSeq_3_" + (108-DecodeStringRow()) +"_"+ DecodeStringStep() +"_"+ (DecodeStringStep()+1), 0); 
                    for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                        GameObject.Find("Row_"+DecodeStringRow().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                        GameObject.Find("Row_"+DecodeStringRow().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        PlayerPrefs.SetInt("SynthSeq_3_" + (108-DecodeStringRow()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_), 0);
                        Debug.Log("SynthSeq_3_" + (108-DecodeStringRow()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_));
                        noteStart_temp = (int)noteTemp.start_+k;
                        noteEnd_temp = (int)noteTemp.end_;
                    }               
                    GameObject.Find("SynthSequencer_3").GetComponent<HelmSequencer>().RemoveNotesInRange(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);
                    PlayerPrefs.SetInt("SynthSeq_3_" + (108-DecodeStringRow()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp), 0);
                    Debug.Log("SynthSeq_3_" + (108-DecodeStringRow()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp));
                    return;
                } 
                else if (this.GetComponent<RawImage>().color == gridCellColor) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    startStep = DecodeStringStep();          
                    this.GetComponent<RawImage>().color = Color.red;
                    GameObject.Find("SynthSequencer_3").GetComponent<HelmSequencer>().AddNote(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);  
                    PlayerPrefs.SetInt("SynthSeq_3_" + (108-DecodeStringRow()) +"_"+ DecodeStringStep() +"_"+ (DecodeStringStep()+1), 1); 
                } 
            }    
            if (GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().currentPattern == 4) {
                if (this.GetComponent<RawImage>().color == Color.red) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    noteTemp = GameObject.Find("SynthSequencer_4").GetComponent<HelmSequencer>().GetNoteInRange(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);           
                    this.GetComponent<RawImage>().color = gridCellColor;
                    UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);      
                    PlayerPrefs.SetInt("SynthSeq_4_" + (108-DecodeStringRow()) +"_"+ DecodeStringStep() +"_"+ (DecodeStringStep()+1), 0); 
                    for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                        GameObject.Find("Row_"+DecodeStringRow().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                        GameObject.Find("Row_"+DecodeStringRow().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        PlayerPrefs.SetInt("SynthSeq_4_" + (108-DecodeStringRow()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_), 0);
                        Debug.Log("SynthSeq_4_" + (108-DecodeStringRow()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_));
                        noteStart_temp = (int)noteTemp.start_+k;
                        noteEnd_temp = (int)noteTemp.end_;
                    }               
                    GameObject.Find("SynthSequencer_4").GetComponent<HelmSequencer>().RemoveNotesInRange(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);
                    PlayerPrefs.SetInt("SynthSeq_4_" + (108-DecodeStringRow()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp), 0);
                    Debug.Log("SynthSeq_4_" + (108-DecodeStringRow()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp));
                    return;
                } 
                else if (this.GetComponent<RawImage>().color == gridCellColor) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    startStep = DecodeStringStep();          
                    this.GetComponent<RawImage>().color = Color.red;
                    GameObject.Find("SynthSequencer_4").GetComponent<HelmSequencer>().AddNote(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);  
                    PlayerPrefs.SetInt("SynthSeq_4_" + (108-DecodeStringRow()) +"_"+ DecodeStringStep() +"_"+ (DecodeStringStep()+1), 1); 
                } 
            }  
        }

        ///////////////////

        if (GameObject.Find("SequencerButtonText").GetComponent<TextMeshProUGUI>().text == "DRUM") {       
            if (GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().currentPatternDrum == 1) {
                if (this.GetComponent<RawImage>().color == Color.red) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    noteTemp = GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.SampleSequencer>().GetNoteInRange(67-DecodeStringRow_Drum(), DecodeStringStep_Drum(), DecodeStringStep_Drum()+1);           
                    this.GetComponent<RawImage>().color = gridCellColor;
                    UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);      
                    PlayerPrefs.SetInt("DrumSeq_1_" + (67-DecodeStringRow_Drum()) +"_"+ DecodeStringStep_Drum() +"_"+ (DecodeStringStep_Drum()+1), 0); 
                    for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                        GameObject.Find("DrumRow_"+DecodeStringRow_Drum().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                        GameObject.Find("DrumRow_"+DecodeStringRow_Drum().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        PlayerPrefs.SetInt("DrumSeq_1_" + (67-DecodeStringRow_Drum()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_), 0);
                        noteStart_temp = (int)noteTemp.start_+k;
                        noteEnd_temp = (int)noteTemp.end_;
                    }               
                    GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.SampleSequencer>().RemoveNotesInRange(67-DecodeStringRow_Drum(), DecodeStringStep_Drum(), DecodeStringStep_Drum()+1);
                    PlayerPrefs.SetInt("DrumSeq_1_" + (67-DecodeStringRow_Drum()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp), 0);
                    Debug.Log("-----> DrumSeq_1_" + (67-DecodeStringRow_Drum()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp));
                    return;
                } 
                else if (this.GetComponent<RawImage>().color == gridCellColor) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    startStep = DecodeStringStep_Drum();          
                    this.GetComponent<RawImage>().color = Color.red;
                    GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.SampleSequencer>().AddNote(67-DecodeStringRow_Drum(), DecodeStringStep_Drum(), DecodeStringStep_Drum()+1);  
                    PlayerPrefs.SetInt("DrumSeq_1_" + (67-DecodeStringRow_Drum()) +"_"+ DecodeStringStep_Drum() +"_"+ (DecodeStringStep_Drum()+1), 1);
                    Debug.Log("FIRED"); 
                } 
            } 
            if (GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().currentPatternDrum == 2) {
                if (this.GetComponent<RawImage>().color == Color.red) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    noteTemp = GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.SampleSequencer>().GetNoteInRange(67-DecodeStringRow_Drum(), DecodeStringStep_Drum(), DecodeStringStep_Drum()+1);           
                    this.GetComponent<RawImage>().color = gridCellColor;
                    UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);      
                    PlayerPrefs.SetInt("DrumSeq_2_" + (67-DecodeStringRow_Drum()) +"_"+ DecodeStringStep_Drum() +"_"+ (DecodeStringStep_Drum()+1), 0); 
                    for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                        GameObject.Find("DrumRow_"+DecodeStringRow_Drum().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                        GameObject.Find("DrumRow_"+DecodeStringRow_Drum().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        PlayerPrefs.SetInt("DrumSeq_2_" + (67-DecodeStringRow_Drum()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_), 0);
                        Debug.Log("DrumSeq_2_" + (67-DecodeStringRow_Drum()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_));
                        noteStart_temp = (int)noteTemp.start_+k;
                        noteEnd_temp = (int)noteTemp.end_;
                    }               
                    GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.SampleSequencer>().RemoveNotesInRange(67-DecodeStringRow_Drum(), DecodeStringStep_Drum(), DecodeStringStep_Drum()+1);
                    PlayerPrefs.SetInt("DrumSeq_2_" + (67-DecodeStringRow_Drum()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp), 0);
                    Debug.Log("DrumSeq_2_" + (67-DecodeStringRow_Drum()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp));
                    return;
                } 
                else if (this.GetComponent<RawImage>().color == gridCellColor) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    startStep = DecodeStringStep_Drum();          
                    this.GetComponent<RawImage>().color = Color.red;
                    GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.SampleSequencer>().AddNote(67-DecodeStringRow_Drum(), DecodeStringStep_Drum(), DecodeStringStep_Drum()+1);  
                    PlayerPrefs.SetInt("DrumSeq_2_" + (67-DecodeStringRow_Drum()) +"_"+ DecodeStringStep_Drum() +"_"+ (DecodeStringStep_Drum()+1), 1); 
                } 
            } 
            if (GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().currentPatternDrum == 3) {
                if (this.GetComponent<RawImage>().color == Color.red) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    noteTemp = GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.SampleSequencer>().GetNoteInRange(67-DecodeStringRow_Drum(), DecodeStringStep_Drum(), DecodeStringStep_Drum()+1);           
                    this.GetComponent<RawImage>().color = gridCellColor;
                    UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);      
                    PlayerPrefs.SetInt("DrumSeq_3_" + (67-DecodeStringRow_Drum()) +"_"+ DecodeStringStep_Drum() +"_"+ (DecodeStringStep_Drum()+1), 0); 
                    for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                        GameObject.Find("DrumRow_"+DecodeStringRow_Drum().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                        GameObject.Find("DrumRow_"+DecodeStringRow_Drum().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        PlayerPrefs.SetInt("DrumSeq_3_" + (67-DecodeStringRow_Drum()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_), 0);
                        Debug.Log("DrumSeq_2_" + (67-DecodeStringRow_Drum()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_));
                        noteStart_temp = (int)noteTemp.start_+k;
                        noteEnd_temp = (int)noteTemp.end_;
                    }               
                    GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.SampleSequencer>().RemoveNotesInRange(67-DecodeStringRow_Drum(), DecodeStringStep_Drum(), DecodeStringStep_Drum()+1);
                    PlayerPrefs.SetInt("DrumSeq_3_" + (67-DecodeStringRow_Drum()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp), 0);
                    Debug.Log("DrumSeq_3_" + (67-DecodeStringRow_Drum()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp));
                    return;
                } 
                else if (this.GetComponent<RawImage>().color == gridCellColor) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    startStep = DecodeStringStep_Drum();          
                    this.GetComponent<RawImage>().color = Color.red;
                    GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.SampleSequencer>().AddNote(67-DecodeStringRow_Drum(), DecodeStringStep_Drum(), DecodeStringStep_Drum()+1);  
                    PlayerPrefs.SetInt("DrumSeq_3_" + (67-DecodeStringRow_Drum()) +"_"+ DecodeStringStep_Drum() +"_"+ (DecodeStringStep_Drum()+1), 1); 
                } 
            }   
            if (GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().currentPatternDrum == 4) {
                if (this.GetComponent<RawImage>().color == Color.red) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    noteTemp = GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.SampleSequencer>().GetNoteInRange(67-DecodeStringRow_Drum(), DecodeStringStep_Drum(), DecodeStringStep_Drum()+1);           
                    this.GetComponent<RawImage>().color = gridCellColor;
                    UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);      
                    PlayerPrefs.SetInt("DrumSeq_4_" + (67-DecodeStringRow_Drum()) +"_"+ DecodeStringStep_Drum() +"_"+ (DecodeStringStep_Drum()+1), 0); 
                    for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                        GameObject.Find("DrumRow_"+DecodeStringRow_Drum().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                        GameObject.Find("DrumRow_"+DecodeStringRow_Drum().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        PlayerPrefs.SetInt("DrumSeq_4_" + (67-DecodeStringRow_Drum()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_), 0);
                        Debug.Log("DrumSeq_4_" + (67-DecodeStringRow_Drum()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_));
                        noteStart_temp = (int)noteTemp.start_+k;
                        noteEnd_temp = (int)noteTemp.end_;
                    }               
                    GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.SampleSequencer>().RemoveNotesInRange(67-DecodeStringRow_Drum(), DecodeStringStep_Drum(), DecodeStringStep_Drum()+1);
                    PlayerPrefs.SetInt("DrumSeq_4_" + (67-DecodeStringRow_Drum()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp), 0);
                    Debug.Log("DrumSeq_4_" + (67-DecodeStringRow_Drum()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp));
                    return;
                } 
                else if (this.GetComponent<RawImage>().color == gridCellColor) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    startStep = DecodeStringStep_Drum();          
                    this.GetComponent<RawImage>().color = Color.red;
                    GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.SampleSequencer>().AddNote(67-DecodeStringRow_Drum(), DecodeStringStep_Drum(), DecodeStringStep_Drum()+1);  
                    PlayerPrefs.SetInt("DrumSeq_4_" + (67-DecodeStringRow_Drum()) +"_"+ DecodeStringStep_Drum() +"_"+ (DecodeStringStep_Drum()+1), 1); 
                } 
            }         
        }     

        ///////////////////

        if (GameObject.Find("SequencerButtonText").GetComponent<TextMeshProUGUI>().text == "SAMPLE") {       
            if (GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 1) {
                if (this.GetComponent<RawImage>().color == Color.red) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    noteTemp = GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().GetNoteInRange(75-DecodeStringRow_Sample(), DecodeStringStep_Sample(), DecodeStringStep_Sample()+1);           
                    this.GetComponent<RawImage>().color = gridCellColor;
                    UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);      
                    PlayerPrefs.SetInt("SampleSeq_1_" + (75-DecodeStringRow_Drum()) +"_"+ DecodeStringStep_Sample() +"_"+ (DecodeStringStep_Sample()+1), 0); 
                    for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                        GameObject.Find("SampleRow_"+DecodeStringRow_Drum().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                        GameObject.Find("SampleRow_"+DecodeStringRow_Drum().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        PlayerPrefs.SetInt("SampleSeq_1_" + (75-DecodeStringRow_Drum()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_), 0);
                        noteStart_temp = (int)noteTemp.start_+k;
                        noteEnd_temp = (int)noteTemp.end_;
                    }               
                    GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().RemoveNotesInRange(75-DecodeStringRow_Sample(), DecodeStringStep_Sample(), DecodeStringStep_Sample()+1);
                    PlayerPrefs.SetInt("SampleSeq_1_" + (75-DecodeStringRow_Drum()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp), 0);
                    Debug.Log("-----> SampleSeq_1_" + (75-DecodeStringRow_Drum()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp));
                    return;
                } 
                else if (this.GetComponent<RawImage>().color == gridCellColor) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    startStep = DecodeStringStep_Sample();          
                    this.GetComponent<RawImage>().color = Color.red;
                    GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().AddNote(75-DecodeStringRow_Sample(), DecodeStringStep_Sample(), DecodeStringStep_Sample()+1);  
                    PlayerPrefs.SetInt("SampleSeq_1_" + (75-DecodeStringRow_Sample()) +"_"+ DecodeStringStep_Sample() +"_"+ (DecodeStringStep_Sample()+1), 1); 
                } 
            }      
            if (GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 2) {
                if (this.GetComponent<RawImage>().color == Color.red) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    noteTemp = GameObject.Find("SampleSequencer_2").GetComponent<AudioHelm.SampleSequencer>().GetNoteInRange(75-DecodeStringRow_Sample(), DecodeStringStep_Sample(), DecodeStringStep_Sample()+1);           
                    this.GetComponent<RawImage>().color = gridCellColor;
                    UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);      
                    PlayerPrefs.SetInt("SampleSeq_2_" + (75-DecodeStringRow_Sample()) +"_"+ DecodeStringStep_Sample() +"_"+ (DecodeStringStep_Sample()+1), 0); 
                    for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                        GameObject.Find("SampleRow_"+DecodeStringRow_Drum().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                        GameObject.Find("SampleRow_"+DecodeStringRow_Drum().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        PlayerPrefs.SetInt("SampleSeq_2_" + (75-DecodeStringRow_Drum()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_), 0);
                        noteStart_temp = (int)noteTemp.start_+k;
                        noteEnd_temp = (int)noteTemp.end_;
                    }               
                    GameObject.Find("SampleSequencer_2").GetComponent<AudioHelm.SampleSequencer>().RemoveNotesInRange(75-DecodeStringRow_Sample(), DecodeStringStep_Sample(), DecodeStringStep_Sample()+1);
                    PlayerPrefs.SetInt("SampleSeq_2_" + (75-DecodeStringRow_Drum()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp), 0);
                    Debug.Log("-----> SampleSeq_2_" + (75-DecodeStringRow_Drum()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp));
                    return;
                } 
                else if (this.GetComponent<RawImage>().color == gridCellColor) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    startStep = DecodeStringStep_Sample();          
                    this.GetComponent<RawImage>().color = Color.red;
                    GameObject.Find("SampleSequencer_2").GetComponent<AudioHelm.SampleSequencer>().AddNote(75-DecodeStringRow_Sample(), DecodeStringStep_Sample(), DecodeStringStep_Sample()+1);  
                    PlayerPrefs.SetInt("SampleSeq_2_" + (75-DecodeStringRow_Sample()) +"_"+ DecodeStringStep_Sample() +"_"+ (DecodeStringStep_Sample()+1), 1); 
                } 
            } 
            if (GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 3) {
                if (this.GetComponent<RawImage>().color == Color.red) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    noteTemp = GameObject.Find("SampleSequencer_3").GetComponent<AudioHelm.SampleSequencer>().GetNoteInRange(75-DecodeStringRow_Sample(), DecodeStringStep_Sample(), DecodeStringStep_Sample()+1);           
                    this.GetComponent<RawImage>().color = gridCellColor;
                    UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);      
                    PlayerPrefs.SetInt("SampleSeq_3_" + (75-DecodeStringRow_Sample()) +"_"+ DecodeStringStep_Sample() +"_"+ (DecodeStringStep_Sample()+1), 0); 
                    for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                        GameObject.Find("SampleRow_"+DecodeStringRow_Sample().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                        GameObject.Find("SampleRow_"+DecodeStringRow_Sample().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        PlayerPrefs.SetInt("SampleSeq_3_" + (75-DecodeStringRow_Sample()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_), 0);
                        noteStart_temp = (int)noteTemp.start_+k;
                        noteEnd_temp = (int)noteTemp.end_;
                    }               
                    GameObject.Find("SampleSequencer_3").GetComponent<AudioHelm.SampleSequencer>().RemoveNotesInRange(75-DecodeStringRow_Sample(), DecodeStringStep_Sample(), DecodeStringStep_Sample()+1);
                    PlayerPrefs.SetInt("SampleSeq_3_" + (75-DecodeStringRow_Sample()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp), 0);
                    Debug.Log("-----> SampleSeq_3_" + (75-DecodeStringRow_Sample()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp));
                    return;
                } 
                else if (this.GetComponent<RawImage>().color == gridCellColor) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    startStep = DecodeStringStep_Sample();          
                    this.GetComponent<RawImage>().color = Color.red;
                    GameObject.Find("SampleSequencer_3").GetComponent<AudioHelm.SampleSequencer>().AddNote(75-DecodeStringRow_Sample(), DecodeStringStep_Sample(), DecodeStringStep_Sample()+1);  
                    PlayerPrefs.SetInt("SampleSeq_3_" + (75-DecodeStringRow_Sample()) +"_"+ DecodeStringStep_Sample() +"_"+ (DecodeStringStep_Sample()+1), 1); 
                } 
            }    
            if (GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 3) {
                if (this.GetComponent<RawImage>().color == Color.red) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    noteTemp = GameObject.Find("SampleSequencer_4").GetComponent<AudioHelm.SampleSequencer>().GetNoteInRange(75-DecodeStringRow_Sample(), DecodeStringStep_Sample(), DecodeStringStep_Sample()+1);           
                    this.GetComponent<RawImage>().color = gridCellColor;
                    UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);      
                    PlayerPrefs.SetInt("SampleSeq_4_" + (75-DecodeStringRow_Sample()) +"_"+ DecodeStringStep_Sample() +"_"+ (DecodeStringStep_Sample()+1), 0); 
                    for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                        GameObject.Find("SampleRow_"+DecodeStringRow_Sample().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                        GameObject.Find("SampleRow_"+DecodeStringRow_Sample().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
                        PlayerPrefs.SetInt("SampleSeq_4_" + (75-DecodeStringRow_Sample()) +"_"+ (noteTemp.start_+k) +"_"+ (noteTemp.end_), 0);
                        noteStart_temp = (int)noteTemp.start_+k;
                        noteEnd_temp = (int)noteTemp.end_;
                    }               
                    GameObject.Find("SampleSequencer_4").GetComponent<AudioHelm.SampleSequencer>().RemoveNotesInRange(75-DecodeStringRow_Sample(), DecodeStringStep_Sample(), DecodeStringStep_Sample()+1);
                    PlayerPrefs.SetInt("SampleSeq_4_" + (75-DecodeStringRow_Sample()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp), 0);
                    Debug.Log("-----> SampleSeq_4_" + (75-DecodeStringRow_Sample()) +"_"+ (noteStart_temp) +"_"+ (noteEnd_temp));
                    return;
                } 
                else if (this.GetComponent<RawImage>().color == gridCellColor) {
                    mousePos = ScreenPosToPointerData(Input.mousePosition);
                    startStep = DecodeStringStep_Sample();          
                    this.GetComponent<RawImage>().color = Color.red;
                    GameObject.Find("SampleSequencer_4").GetComponent<AudioHelm.SampleSequencer>().AddNote(75-DecodeStringRow_Sample(), DecodeStringStep_Sample(), DecodeStringStep_Sample()+1);  
                    PlayerPrefs.SetInt("SampleSeq_4_" + (75-DecodeStringRow_Sample()) +"_"+ DecodeStringStep_Sample() +"_"+ (DecodeStringStep_Sample()+1), 1); 
                } 
            }                                     
        }            
    }      

    public void ResetDragCount() {
        dragCellCount = 0;
    }    
    
    int DecodeStringRow(){
        string nameCell = UIRaycast(mousePos).name;
        string numbersOnly = Regex.Replace(nameCell, "[^0-9]", " ");        
        string[] stringArray = numbersOnly.Split(" "[0]);//Split myString wherever there's a " " and make a string array out of it.
        myNumbers = new int[stringArray.Length];
        for(int num = 0; num < stringArray.Length; num++) {
            if (int.TryParse(stringArray[num], out number)) {
                myNumbers[num] = int.Parse(stringArray[num]);
            }
        } 
        int row = myNumbers[4];
        return row;  
    } 

    int DecodeStringStep(){
        string nameCell = UIRaycast(mousePos).name;
        string numbersOnly = Regex.Replace(nameCell, "[^0-9]", " ");        
        string[] stringArray = numbersOnly.Split(" "[0]);//Split myString wherever there's a " " and make a string array out of it.
        myNumbers = new int[stringArray.Length];
        for(int num = 0; num < stringArray.Length; num++) {
            if (int.TryParse(stringArray[num], out number)) {
                myNumbers[num] = int.Parse(stringArray[num]);
            }
        }      
        int step = myNumbers[5];
        return step;  
    }   

    ///////////

    int DecodeStringRow_Drum(){
        string nameCell = UIRaycast(mousePos).name;
        string numbersOnly = Regex.Replace(nameCell, "[^0-9]", " ");        
        string[] stringArray = numbersOnly.Split(" "[0]);//Split myString wherever there's a " " and make a string array out of it.
        myNumbers = new int[stringArray.Length];
        for(int num = 0; num < stringArray.Length; num++) {
            if (int.TryParse(stringArray[num], out number)) {
                myNumbers[num] = int.Parse(stringArray[num]);
            }
        } 
        int row = myNumbers[8];
        return row;  
    } 

    int DecodeStringStep_Drum(){
        string nameCell = UIRaycast(mousePos).name;
        string numbersOnly = Regex.Replace(nameCell, "[^0-9]", " ");        
        string[] stringArray = numbersOnly.Split(" "[0]);//Split myString wherever there's a " " and make a string array out of it.
        myNumbers = new int[stringArray.Length];
        for(int num = 0; num < stringArray.Length; num++) {
            if (int.TryParse(stringArray[num], out number)) {
                myNumbers[num] = int.Parse(stringArray[num]);
            }
        } 
        int step = myNumbers[9];
        return step;  
    }     

    ///////////

    int DecodeStringRow_Sample(){
        string nameCell = UIRaycast(mousePos).name;
        string numbersOnly = Regex.Replace(nameCell, "[^0-9]", " ");        
        string[] stringArray = numbersOnly.Split(" "[0]);//Split myString wherever there's a " " and make a string array out of it.
        myNumbers = new int[stringArray.Length];
        for(int num = 0; num < stringArray.Length; num++) {
            if (int.TryParse(stringArray[num], out number)) {
                myNumbers[num] = int.Parse(stringArray[num]);
            }
        } 
        int row = myNumbers[11];
        return row;  
    } 

    int DecodeStringStep_Sample(){
        string nameCell = UIRaycast(mousePos).name;
        string numbersOnly = Regex.Replace(nameCell, "[^0-9]", " ");        
        string[] stringArray = numbersOnly.Split(" "[0]);//Split myString wherever there's a " " and make a string array out of it.
        myNumbers = new int[stringArray.Length];
        for(int num = 0; num < stringArray.Length; num++) {
            if (int.TryParse(stringArray[num], out number)) {
                myNumbers[num] = int.Parse(stringArray[num]);
            }
        } 
        int step = myNumbers[12];
        return step;  
    }     
}
