using UnityEngine;
using TMPro;

public class SequencerButton : MonoBehaviour
{
    public int sequencer = 0;
    public GameObject drum;
    public GameObject synth;
    public GameObject sample;
    public GameObject saveManager;
    TextMeshProUGUI textmeshPro;

    public GameObject drumPatternButtons;
    public GameObject synthPatternButtons;
    public GameObject samplePatternButtons;

    // Start is called before the first frame update
    void Start()
    {   
        drum.SetActive(true);
        synth.SetActive(true);
        sample.SetActive(true);
        StartCoroutine(saveManager.GetComponent<SaveManagerPro>().LoadDrumNotesIntoSeq());  
        //StartCoroutine(saveManager.GetComponent<SaveManager>().LoadNotesIntoSeq());
        textmeshPro = GameObject.Find("SequencerButtonText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = "DRUM";
        RectTransform synthRectTransform = synth.GetComponent<RectTransform>();
        synthRectTransform.localPosition = new Vector3(0, 800, 0);     
        RectTransform sampleRectTransform = sample.GetComponent<RectTransform>();
        sampleRectTransform.localPosition = new Vector3(0, 800, 0); 

        RectTransform drumPatternRectTransform = drumPatternButtons.GetComponent<RectTransform>();
        drumPatternRectTransform.localPosition = new Vector3(71, -411.6f, 0);     
        RectTransform synthPatternRectTransform = synthPatternButtons.GetComponent<RectTransform>();
        synthPatternRectTransform.localPosition = new Vector3(71, -700, 0);   
        RectTransform samplePatternRectTransform = samplePatternButtons.GetComponent<RectTransform>();
        samplePatternRectTransform.localPosition = new Vector3(71, -700, 0);              
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SequencerButtonElement() {
        if (sequencer == 2) {
            drum.transform.SetSiblingIndex(-1);
            textmeshPro.text = "DRUM";
            RectTransform synthRectTransform = synth.GetComponent<RectTransform>();
            synthRectTransform.localPosition = new Vector3(0, 800, 0);    
            RectTransform drumRectTransform = drum.GetComponent<RectTransform>();
            drumRectTransform.localPosition = new Vector3(0, 0, 0);
            RectTransform sampleRectTransform = sample.GetComponent<RectTransform>();
            sampleRectTransform.localPosition = new Vector3(0, 800, 0);                                      
            sequencer = 0;

            RectTransform drumPatternRectTransform = drumPatternButtons.GetComponent<RectTransform>();
            drumPatternRectTransform.localPosition = new Vector3(71, -411.6f, 0);     
            RectTransform synthPatternRectTransform = synthPatternButtons.GetComponent<RectTransform>();
            synthPatternRectTransform.localPosition = new Vector3(71, -700, 0);
            RectTransform samplePatternRectTransform = samplePatternButtons.GetComponent<RectTransform>();
            samplePatternRectTransform.localPosition = new Vector3(71, -700, 0);             
        }  
        else if (sequencer == 0) {
            drum.transform.SetSiblingIndex(1);
            textmeshPro.text = "SYNTH";
            RectTransform synthRectTransform = synth.GetComponent<RectTransform>();
            synthRectTransform.localPosition = new Vector3(0, 0, 0);
            RectTransform drumRectTransform = drum.GetComponent<RectTransform>();
            drumRectTransform.localPosition = new Vector3(0, 800, 0); 
            RectTransform sampleRectTransform = sample.GetComponent<RectTransform>();
            sampleRectTransform.localPosition = new Vector3(0, 800, 0);                                     
            sequencer = 1;

            RectTransform drumPatternRectTransform = drumPatternButtons.GetComponent<RectTransform>();
            drumPatternRectTransform.localPosition = new Vector3(71, -700, 0);     
            RectTransform synthPatternRectTransform = synthPatternButtons.GetComponent<RectTransform>();
            synthPatternRectTransform.localPosition = new Vector3(71, -411.6f, 0);            
            RectTransform samplePatternRectTransform = samplePatternButtons.GetComponent<RectTransform>();
            samplePatternRectTransform.localPosition = new Vector3(71, -700, 0);             
        }          
        else if (sequencer == 1) {
            drum.transform.SetSiblingIndex(-1);
            textmeshPro.text = "SAMPLE";
            RectTransform synthRectTransform = synth.GetComponent<RectTransform>();
            synthRectTransform.localPosition = new Vector3(0, 800, 0);    
            RectTransform drumRectTransform = drum.GetComponent<RectTransform>();
            drumRectTransform.localPosition = new Vector3(0, 800, 0);  
            RectTransform sampleRectTransform = sample.GetComponent<RectTransform>();
            sampleRectTransform.localPosition = new Vector3(0, 0, 0);                                    
            sequencer = 2;

            RectTransform drumPatternRectTransform = drumPatternButtons.GetComponent<RectTransform>();
            drumPatternRectTransform.localPosition = new Vector3(71, -700, 0);     
            RectTransform synthPatternRectTransform = synthPatternButtons.GetComponent<RectTransform>();
            synthPatternRectTransform.localPosition = new Vector3(71, -700, 0);  
            RectTransform samplePatternRectTransform = samplePatternButtons.GetComponent<RectTransform>();
            samplePatternRectTransform.localPosition = new Vector3(71, -411.6f, 0);                      
        }              
    }
}