using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;

public class GUI_Manager : MonoBehaviour
{
    public GameObject target;
    public GameObject target2;
    public const float keyboardWidth = 50.0f;
    public const float scrollWidth = 50.0f;

    public SequencerUI_Custom sequencer = new SequencerUI_Custom(keyboardWidth, scrollWidth + 1);
    public SequencerPositionUI_Custom sequencerPosition = new SequencerPositionUI_Custom(keyboardWidth, scrollWidth);

    public SequencerUI_Custom sequencer2 = new SequencerUI_Custom(keyboardWidth, scrollWidth + 1);
    public SequencerPositionUI_Custom sequencerPosition2 = new SequencerPositionUI_Custom(keyboardWidth, scrollWidth);

    public int channel = 1;
    public int length = 16;
    public bool loop = true;
    public float zoom;
    //public SerializedProperty division;
    public bool autoScroll = false;
    public int allNotes;  

    public float positionHeight = 50.0f;
    public float sequencerHeight = 400.0f;
    public float minWidth = Screen.width;

    public int xPos1 = 0;
    public int xPos2 = 1500;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void doGUI_Drums()
    {
        Color prev_color = GUI.backgroundColor;
        GUILayout.Space(0f);
        SampleSequencer sampleSequencer = target.GetComponent<SampleSequencer>();
        Sampler sampler = GameObject.Find("DrumSequencer").GetComponent<Sampler>();
        if (sampler)
        {
            sequencer.minKey = sampler.GetMinKey();
            sequencer.maxKey = sampler.GetMaxKey();
        }
        else
        {
            sequencer.minKey = 0;
            sequencer.maxKey = Utils.kMidiSize - 1;
        }
        Rect sequencerPositionRect = new Rect(0, 0, Screen.width, positionHeight);
        Rect rect = new Rect(xPos1, 0, Screen.width, Screen.height/2);

        float startWindow = sequencer.GetMinVisibleTime() / length;
        float endWindow = sequencer.GetMaxVisibleTime(rect.width) / length;
        sequencerPosition.DrawSequencerPosition(sequencerPositionRect, sampleSequencer, startWindow, endWindow);

        //if (rect.height == sequencerHeight)
            sequencer.DrawSequencer(rect, sampleSequencer, zoom, allNotes);

        if (sequencer.DoSequencerEvents(rect, sampleSequencer, allNotes))
            //Repaint();

        GUILayout.Space(0f);
        GUI.backgroundColor = prev_color;

        GUI.skin.verticalScrollbar.fixedWidth = Screen.width * 0.1f;
        GUI.skin.verticalScrollbarThumb.fixedWidth = Screen.width * 0.1f;

        GUI.skin.horizontalScrollbar.fixedHeight = Screen.width * 0.1f;
        GUI.skin.horizontalScrollbarThumb.fixedHeight = Screen.width * 0.1f;        
    }


    public void doGUI_Helm()
    {
        Color prev_color = GUI.backgroundColor;
        GUILayout.Space(0f);
        HelmSequencer helmSequencer = target2.GetComponent<HelmSequencer>();
        Rect sequencerPositionRect = new Rect(0, 0, Screen.width, positionHeight);
        Rect rect = new Rect(xPos2, 0, Screen.width, Screen.height/2);

        float startWindow = sequencer2.GetMinVisibleTime() / length;
        float endWindow = sequencer2.GetMaxVisibleTime(rect.width) / length;
        sequencerPosition.DrawSequencerPosition(sequencerPositionRect, helmSequencer, startWindow, endWindow);

        //if (rect.height == sequencerHeight)
            sequencer2.DrawSequencer(rect, helmSequencer, zoom, allNotes);

        if (sequencer2.DoSequencerEvents(rect, helmSequencer, allNotes))
            //Repaint();

        GUILayout.Space(0f);
        GUI.backgroundColor = prev_color;

        GUI.skin.verticalScrollbar.fixedWidth = Screen.width * 0.1f;
        GUI.skin.verticalScrollbarThumb.fixedWidth = Screen.width * 0.1f;

        GUI.skin.horizontalScrollbar.fixedHeight = Screen.width * 0.1f;
        GUI.skin.horizontalScrollbarThumb.fixedHeight = Screen.width * 0.1f;     
    }    
}
