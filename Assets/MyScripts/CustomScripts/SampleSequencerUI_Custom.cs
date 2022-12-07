using UnityEngine;
using System.IO;

namespace AudioHelm
{
    //[CustomEditor(typeof(SampleSequencer))]
    class SampleSequencerUI
    {
        SampleSequencer target;
        const float keyboardWidth = 100.0f;
        const float scrollWidth = 50.0f;

        int length = 16;
        bool loop = true;
        //SerializedProperty division;
        int allNotes;
        float zoom;
        bool autoScroll = true;
        //SerializedProperty noteOnEvent;
        // noteOffEvent;
        //SerializedProperty beatEvent;

        SequencerUI_Custom sequencer = new SequencerUI_Custom(keyboardWidth, scrollWidth + 1);
        SequencerPositionUI_Custom sequencerPosition = new SequencerPositionUI_Custom(keyboardWidth, scrollWidth);

        float positionHeight = 50.0f;
        float sequencerHeight = 440.0f;
        float minWidth = Screen.width;

        public GameObject DrumViewUI;

        void Start()
        {
            // length = 16;
            // loop = true;
            // //division = serializedObject.FindProperty("division");
            // allNotes = 8;
            // //zoom = 0.3f;
            // autoScroll = true;
            // //noteOnEvent = serializedObject.FindProperty("noteOnEvent");
            // //noteOffEvent = serializedObject.FindProperty("noteOffEvent");
            // //beatEvent = serializedObject.FindProperty("beatEvent");    

            // DrumViewUI = GameObject.Find("HelmSequencer");
            
            // DrumViewUI.GetComponent<DrumGameViewUI>().length = length;
            // DrumViewUI.GetComponent<DrumGameViewUI>().loop = loop;
            // //DrumViewUI.GetComponent<DrumGameViewUI>().division = division;
            // DrumViewUI.GetComponent<DrumGameViewUI>().autoScroll = autoScroll;
            // DrumViewUI.GetComponent<DrumGameViewUI>().allNotes = allNotes;
            //DrumViewUI.GetComponent<DrumGameViewUI>().zoom = zoom;                   
        }

        // public void OnGUI()
        // {
        //     //serializedObject.Update();

        //     Color prev_color = GUI.backgroundColor;
        //     GUILayout.Space(5f);
        //     SampleSequencer sampleSequencer = target as SampleSequencer;
        //     Sampler sampler = sampleSequencer.GetComponent<Sampler>();
        //     if (sampler)
        //     {
        //         sequencer.minKey = sampler.GetMinKey();
        //         sequencer.maxKey = sampler.GetMaxKey();
        //     }
        //     else
        //     {
        //         sequencer.minKey = 0;
        //         sequencer.maxKey = Utils.kMidiSize - 1;
        //     }

        //     Rect sequencerPositionRect = GUILayoutUtility.GetRect(minWidth, positionHeight, GUILayout.ExpandWidth(true));
        //     float seqHeight = Mathf.Min(sequencerHeight, sequencer.GetMaxHeight());
        //     Rect rect = GUILayoutUtility.GetRect(minWidth, seqHeight, GUILayout.ExpandWidth(true));

        //     if (sequencer.DoSequencerEvents(rect, sampleSequencer, allNotes)) {
        //         //Repaint();
        //     }

        //     float startWindow = sequencer.GetMinVisibleTime() / length;
        //     float endWindow = sequencer.GetMaxVisibleTime(rect.width) / length;
        //     sequencerPosition.DrawSequencerPosition(sequencerPositionRect, sampleSequencer, startWindow, endWindow);

        //     if (rect.height == seqHeight)
        //         sequencer.DrawSequencer(rect, sampleSequencer, zoom, allNotes);
        //     GUILayout.Space(5f);
        //     GUI.backgroundColor = prev_color;

        //     // if (GUILayout.Button(new GUIContent("Clear Sequencer", "Remove all notes from the sequencer.")))
        //     // {
        //     //     Undo.RecordObject(sampleSequencer, "Clear Sequencer");

        //     //     for (int i = 0; i < allNotes.arraySize; ++i)
        //     //     {
        //     //         SerializedProperty noteRow = allNotes.GetArrayElementAtIndex(i);
        //     //         SerializedProperty notes = noteRow.FindPropertyRelative("notes");
        //     //         notes.ClearArray();
        //     //     }
        //     //     sampleSequencer.Clear();
        //     // }

        //     // if (GUILayout.Button(new GUIContent("Load MIDI File", "Load a MIDI sequence into this sequencer.")))
        //     // {
        //     //     string path = EditorUtility.OpenFilePanel("Load MIDI Sequence", "", "mid");
        //     //     if (path.Length != 0)
        //     //     {
        //     //         Undo.RecordObject(sampleSequencer, "Load MIDI File");
        //     //         sampleSequencer.ReadMidiFile(new FileStream(path, FileMode.Open, FileAccess.Read));
        //     //     }
        //     // }

        //     // EditorGUILayout.PropertyField(length);
        //     // EditorGUILayout.PropertyField(loop);
        //     // sampleSequencer.length = Mathf.Max(sampleSequencer.length, 1);

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