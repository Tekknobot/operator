using UnityEngine;
using AudioHelm;

public class HelmGameViewUI : MonoBehaviour
{
    public GameObject target;
    public const float keyboardWidth = 50.0f;
    public const float scrollWidth = 50.0f;

    public SequencerUI_Custom sequencer = new SequencerUI_Custom(keyboardWidth, scrollWidth + 1);
    public SequencerPositionUI_Custom sequencerPosition = new SequencerPositionUI_Custom(keyboardWidth, scrollWidth);

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

    public int xPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI() {
        Color prev_color = GUI.backgroundColor;
        GUILayout.Space(0f);
        HelmSequencer helmSequencer = target.GetComponent<HelmSequencer>();
        Rect sequencerPositionRect = new Rect(0, 0, Screen.width, positionHeight);
        Rect rect = new Rect(xPos, 0, Screen.width, Screen.height/2);

        float startWindow = sequencer.GetMinVisibleTime() / length;
        float endWindow = sequencer.GetMaxVisibleTime(rect.width) / length;
        sequencerPosition.DrawSequencerPosition(sequencerPositionRect, helmSequencer, startWindow, endWindow);

        //if (rect.height == sequencerHeight)
            sequencer.DrawSequencer(rect, helmSequencer, zoom, allNotes);

        if (sequencer.DoSequencerEvents(rect, helmSequencer, allNotes))
            //Repaint();

        GUILayout.Space(0f);
        GUI.backgroundColor = prev_color;

        GUI.skin.verticalScrollbar.fixedWidth = Screen.width * 0.1f;
        GUI.skin.verticalScrollbarThumb.fixedWidth = Screen.width * 0.1f;

        GUI.skin.horizontalScrollbar.fixedHeight = Screen.width * 0.1f;
        GUI.skin.horizontalScrollbarThumb.fixedHeight = Screen.width * 0.1f;   
    }    
}