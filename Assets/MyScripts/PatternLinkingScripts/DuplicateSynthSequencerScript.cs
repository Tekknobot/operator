using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using UnityEngine.UI;
using TMPro;

public class DuplicateSynthSequencerScript : MonoBehaviour
{
    public int x = 0;
    public int y = 0;
    public GameObject temp;
    public TextMeshProUGUI textmeshPro;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DuplicateSynthSequencer() {  
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;     
        if (x >= 4) {
            return;
        }        
        GameObject SynthSequencer = GameObject.Instantiate(GameObject.Find("SynthSequencer"), new Vector3(1000, 0, 0), Quaternion.identity);
        SynthSequencer.name = "SynthSequencer_"+ (x+1);
        textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = (x+1).ToString();       
        x++;
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1; 
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();         
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
        SynthSequencer.GetComponent<AudioHelm.HelmSequencer>().enabled = true;
        SynthSequencer.GetComponent<AudioHelm.HelmSequencer>().loop = true;
        StartCoroutine(GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().CopyNotesIntoSeq());
        StartCoroutine(GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().LoadNotesIntoGrid());
        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();
        GameObject.Find("Play").GetComponent<Toggle>().enabled = true;
        PlayerPrefs.SetInt("SequencerCount", x);  
    }

    public void DeleteSynthSequencer() {        
        if (x <= 1) {  
            GameObject.Find("SynthSequencer_"+ x).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            x = 1;            
            return; 
        }
        else {           
            temp = GameObject.Find("SynthSequencer_"+ x);
            Destroy(temp);        
            textmeshPro = GameObject.Find("CurrentPatternText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = (x-1).ToString();
            x--; 
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1; 
            GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
            GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();         
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
            GameObject.Find("CurrentPattern").GetComponent<ShowCurrentPatternScript>().ShowCurrentPattern();
            GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();
            GameObject.Find("Play").GetComponent<Toggle>().enabled = true;            
            PlayerPrefs.SetInt("SequencerCount", x);
        }                          
    }  

    /////////////

    public void DuplicateDrumSequencer() {  
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;     
        if (y >= 4) {
            return;
        }        
        GameObject DrumSequencer = GameObject.Instantiate(GameObject.Find("DrumSampler"), new Vector3(1000, 0, 0), Quaternion.identity);
        DrumSequencer.name = "DrumSampler_"+ (y+1);
        textmeshPro = GameObject.Find("CurrentPatternText_Drum").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = (y+1).ToString();       
        y++;
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
        GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1; 
        GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();         
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
        DrumSequencer.GetComponent<AudioHelm.SampleSequencer>().enabled = true;
        DrumSequencer.GetComponent<AudioHelm.SampleSequencer>().loop = true;
        StartCoroutine(GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().CopyNotesIntoSeq_Drum());
        StartCoroutine(GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().LoadNotesIntoGrid_Drum());
        GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();
        GameObject.Find("Play").GetComponent<Toggle>().enabled = true;
        PlayerPrefs.SetInt("SequencerCount_Drum", y);  
    }

    public void DeleteDrumSequencer() {        
        if (y <= 1) {  
            GameObject.Find("DrumSampler_"+ y).GetComponent<AudioHelm.HelmSequencer>().enabled = true;
            y = 1;            
            return; 
        }
        else {           
            temp = GameObject.Find("DrumSampler_"+ y);
            Destroy(temp);        
            textmeshPro = GameObject.Find("CurrentPatternText_Drum").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = (y-1).ToString();
            y--; 
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().currentIndex = -1; 
            GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;
            GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;     
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();         
            GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
            GameObject.Find("CurrentPattern_Drum").GetComponent<ShowCurrentPatternScript>().ShowCurrentPattern_Drum();
            GameObject.Find("Play").GetComponent<PlayButtonPro>().StopPattern();
            GameObject.Find("Play").GetComponent<Toggle>().enabled = true;            
            PlayerPrefs.SetInt("SequencerCount_Drum", y);
        }                          
    }  
}