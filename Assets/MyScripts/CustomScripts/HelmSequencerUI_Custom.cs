using UnityEngine;
using System.IO;

namespace AudioHelm
{
    //[CustomEditor(typeof(HelmSequencer))]
    public class HelmSequencerUI_Custom
    {
        HelmSequencer target;

        public const float keyboardWidth = 100.0f;
        public const float scrollWidth = 50.0f;

        public SequencerUI_Custom sequencer = new SequencerUI_Custom(keyboardWidth, scrollWidth + 1);
        public SequencerPositionUI_Custom sequencerPosition = new SequencerPositionUI_Custom(keyboardWidth, scrollWidth);
        public int channel = 1;
        public int length = 12;
        public bool loop = true;
        public float zoom;
        //public SerializedProperty division;
        public bool autoScroll = true;
        public int allNotes;
        //public SerializedProperty noteOnEvent;
        //public SerializedProperty noteOffEvent;
        //public SerializedProperty beatEvent;

        public float positionHeight = 50.0f;
        public float sequencerHeight = 440.0f;
        public float minWidth = Screen.width;

        //public GameObject helmViewUI;

        void Start()
        {
            // channel = 1;
            // length = 16;
            // loop = true;
            // //division = serializedObject.FindProperty("division");
            // autoScroll = true;
            // allNotes = 128;
            // //zoom = 0.3f;
            // //noteOnEvent = serializedObject.FindProperty("noteOnEvent");
            // //noteOffEvent = serializedObject.FindProperty("noteOffEvent");
            // //beatEvent = serializedObject.FindProperty("beatEvent");

            //helmViewUI = GameObject.Find("HelmSequencer");
            // GameViewUI.GetComponent<HelmGameViewUI>().channel = channel;
            // GameViewUI.GetComponent<HelmGameViewUI>().length = length;
            // GameViewUI.GetComponent<HelmGameViewUI>().loop = loop;
            // //GameViewUI.GetComponent<HelmGameViewUI>().division = division;
            // GameViewUI.GetComponent<HelmGameViewUI>().autoScroll = autoScroll;
            // GameViewUI.GetComponent<HelmGameViewUI>().allNotes = allNotes;
            //GameViewUI.GetComponent<HelmGameViewUI>().zoom = zoom;
        }

        // public void OnGUI()
        // {
        //     //serializedObject.Update();

        //     Color prev_color = GUI.backgroundColor;
        //     GUILayout.Space(5f);
        //     HelmSequencer helmSequencer = target as HelmSequencer;
        //     Rect sequencerPositionRect = GUILayoutUtility.GetRect(minWidth, positionHeight, GUILayout.ExpandWidth(true));
        //     Rect rect = GUILayoutUtility.GetRect(minWidth, sequencerHeight, GUILayout.ExpandWidth(true));

        //     float startWindow = sequencer.GetMinVisibleTime() / length;
        //     float endWindow = sequencer.GetMaxVisibleTime(rect.width) / length;
        //     sequencerPosition.DrawSequencerPosition(sequencerPositionRect, helmSequencer, startWindow, endWindow);

        //     if (rect.height == sequencerHeight)
        //         sequencer.DrawSequencer(rect, helmSequencer, zoom, allNotes);

        //     if (sequencer.DoSequencerEvents(rect, helmSequencer, allNotes))
        //         //Repaint();

        //     GUILayout.Space(5f);
        //     GUI.backgroundColor = prev_color;

        //     // if (GUILayout.Button(new GUIContent("Clear Sequencer", "Remove all notes from the sequencer.")))
        //     // {
        //     //     Undo.RecordObject(helmSequencer, "Clear Sequencer");
        //     //     helmSequencer.Clear();
        //     // }

        //     // if (GUILayout.Button(new GUIContent("Load MIDI File", "Load a MIDI sequence into this sequencer.")))
        //     // {
        //     //     string path = EditorUtility.OpenFilePanel("Load MIDI Sequence", "", "mid");
        //     //     if (path.Length != 0)
        //     //     {
        //     //         Undo.RecordObject(helmSequencer, "Load MIDI File");
        //     //         helmSequencer.ReadMidiFile(new FileStream(path, FileMode.Open, FileAccess.Read));
        //     //     }
        //     // }

        //     // EditorGUILayout.IntSlider(channel, 0, Utils.kMaxChannels - 1);
        //     // EditorGUILayout.PropertyField(length);
        //     // EditorGUILayout.PropertyField(loop);
        //     // helmSequencer.length = Mathf.Max(helmSequencer.length, 1);

        //     // GUILayout.Space(5f);
        //     // EditorGUILayout.LabelField("View Options", EditorStyles.boldLabel);
        //     // EditorGUILayout.PropertyField(division);
        //     // EditorGUILayout.Slider(zoom, 0.0f, 1.0f);
        //     // EditorGUILayout.PropertyField(autoScroll);


        //     // GUILayout.Space(5f);
        //     // EditorGUILayout.LabelField("Events", EditorStyles.boldLabel);
        //     // EditorGUILayout.PropertyField(noteOnEvent);
        //     // EditorGUILayout.PropertyField(noteOffEvent);
        //     // EditorGUILayout.PropertyField(beatEvent);

        //     // serializedObject.ApplyModifiedProperties();
        // }
    }
}
//#endif