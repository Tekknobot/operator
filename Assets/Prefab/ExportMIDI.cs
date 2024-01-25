using System.Collections;
using System.Collections.Generic;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Composing;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Standards;
using Melanchall.DryWetMidi.Tools;
using Melanchall.DryWetMidi.MusicTheory;
using System.IO;
using UnityEngine;

public class ExportMIDI : MonoBehaviour
{
    public AudioHelm.HelmSequencer synthHelm_1;
    public AudioHelm.HelmSequencer synthHelm_2;
    public AudioHelm.HelmSequencer synthHelm_3;
    public AudioHelm.HelmSequencer synthHelm_4;
    public List<AudioHelm.Note> midiNotes;
    public List<AudioHelm.Note> offNotes;    
    public AudioHelm.Note tempNote;

    public double noteLength = 1;

    private string absolutePath = "./";

    private static string GetAndroidExternalFilesDir()
    {
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (AndroidJavaObject context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                // Get all available external file directories (emulated and sdCards)
                AndroidJavaObject[] externalFilesDirectories = context.Call<AndroidJavaObject[]>("getExternalFilesDirs", (object[])null);
                AndroidJavaObject emulated = null;
                AndroidJavaObject sdCard = null;

                for (int i = 0; i < externalFilesDirectories.Length; i++)
                {
                        AndroidJavaObject directory = externalFilesDirectories[i];
                        using (AndroidJavaClass environment = new AndroidJavaClass("android.os.Environment"))
                        {
                            // Check which one is the emulated and which the sdCard.
                            bool isRemovable = environment.CallStatic<bool> ("isExternalStorageRemovable", directory);
                            bool isEmulated = environment.CallStatic<bool> ("isExternalStorageEmulated", directory);
                            if (isEmulated)
                                emulated = directory;
                            else if (isRemovable && isEmulated == false)
                                sdCard = directory;
                        }
                }
                // Return the sdCard if available
                if (sdCard != null)
                        return sdCard.Call<string>("getAbsolutePath");
                else
                        return emulated.Call<string>("getAbsolutePath");
                }
        }
    } 

    // Start is called before the first frame update
    void Start()
    {
        if (Application.isEditor) absolutePath = "/Users/machome/Unity Projects/samples";
        if (Application.platform == RuntimePlatform.Android) absolutePath = GetAndroidExternalFilesDir();
        if (Application.platform == RuntimePlatform.IPhonePlayer) absolutePath = Application.persistentDataPath;

        if (GameObject.Find("SynthSequencer_1")) {
            synthHelm_1 = GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmSequencer>();
        }
        if(GameObject.Find("SynthSequencer_2")) {
            synthHelm_2 = GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmSequencer>();;
        }
        if(GameObject.Find("SynthSequencer_3")) {
            synthHelm_3 = GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmSequencer>();;
        }
        if(GameObject.Find("SynthSequencer_4")) {
            synthHelm_4 = GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmSequencer>();;
        }                        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExportToMIDI() {
        FileCheck();    
    }

    public void FileCheck()
    {
        string filePath = absolutePath+"/PocketPunk.mid";

        if (System.IO.File.Exists(filePath))
        {
            // The file exists -> run event
            File.Delete(absolutePath+"/PocketPunk.mid");
            //UnityEditor.AssetDatabase.Refresh();
            var midiFile = CreateTestFile();
            midiFile.Write(absolutePath+"/PocketPunk.mid");            
        }
        else
        {
            // The file does not exist -> run event
            var midiFile = CreateTestFile();
            midiFile.Write(absolutePath+"/PocketPunk.mid");
        }
    }    

    private MidiFile CreateTestFile()
    {
        Debug.Log("Creating test MIDI file...");

        var patternBuilder = new PatternBuilder()
            .SetStep(MusicalTimeSpan.Sixteenth)
            .SetNoteLength(MusicalTimeSpan.Sixteenth)
            .SetVelocity(SevenBitNumber.MaxValue)
            .ProgramChange(GeneralMidiProgram.SynthBass1);


        if(GameObject.Find("SynthSequencer_1")) {
            midiNotes = synthHelm_1.GetAllNotes();
            offNotes = synthHelm_1.GetAllNoteOffsInRange(0, 16);
        }
        if(GameObject.Find("SynthSequencer_2")) {
            midiNotes = synthHelm_2.GetAllNotes();
            offNotes = synthHelm_2.GetAllNoteOffsInRange(0, 16);
        }

        if(GameObject.Find("SynthSequencer_3")) {
            midiNotes = synthHelm_3.GetAllNotes();
            offNotes = synthHelm_3.GetAllNoteOffsInRange(0, 16);
        }

        if(GameObject.Find("SynthSequencer_4")) {
            midiNotes = synthHelm_4.GetAllNotes();
            offNotes = synthHelm_4.GetAllNoteOffsInRange(0, 16);
        }

        if(GameObject.Find("SynthSequencer_1")) {
            for (int seqIndex = 0; seqIndex < synthHelm_1.length; seqIndex++) {
                for (int noteNumber = 0; noteNumber < 127; noteNumber++) {
                    tempNote = synthHelm_1.GetNoteInRange(noteNumber, seqIndex, seqIndex+1);
                    if (tempNote != null) {
                        for (int h = 0; h < (tempNote.end_ - tempNote.start_); h++) {
                            patternBuilder.Note(Melanchall.DryWetMidi.MusicTheory.Note.Get((SevenBitNumber)tempNote.note_));
                            patternBuilder.StepBack();
                        }
                    }                                            
                    else if (tempNote == null) {
                                                                                                                                        
                    }
                }
                if (tempNote != null) {

                }
                else {
                    patternBuilder.StepForward();
                }
            }
        }                   

        if(GameObject.Find("SynthSequencer_2")) {
            for (int seqIndex = 0; seqIndex < synthHelm_2.length; seqIndex++) {
                for (int noteNumber = 0; noteNumber < 127; noteNumber++) {
                    tempNote = synthHelm_2.GetNoteInRange(noteNumber, seqIndex, seqIndex+1);
                    if (tempNote != null) {
                        for (int h = 0; h < (tempNote.end_ - tempNote.start_); h++) {
                            patternBuilder.Note(Melanchall.DryWetMidi.MusicTheory.Note.Get((SevenBitNumber)tempNote.note_));
                            patternBuilder.StepBack();
                        }
                    }                                            
                    else if (tempNote == null) {
                                                                                                                                        
                    }
                }
                if (tempNote != null) {

                }
                else {
                    patternBuilder.StepForward();
                }
            }
        }  

        if(GameObject.Find("SynthSequencer_3")) {
            for (int seqIndex = 0; seqIndex < synthHelm_3.length; seqIndex++) {
                for (int noteNumber = 0; noteNumber < 127; noteNumber++) {
                    tempNote = synthHelm_3.GetNoteInRange(noteNumber, seqIndex, seqIndex+1);
                    if (tempNote != null) {
                        for (int h = 0; h < (tempNote.end_ - tempNote.start_); h++) {
                            patternBuilder.Note(Melanchall.DryWetMidi.MusicTheory.Note.Get((SevenBitNumber)tempNote.note_));
                            patternBuilder.StepBack();
                        }
                    }                                            
                    else if (tempNote == null) {
                                                                                                                                        
                    }
                }
                if (tempNote != null) {

                }
                else {
                    patternBuilder.StepForward();
                }
            }
        }  

        if(GameObject.Find("SynthSequencer_4")) {
            for (int seqIndex = 0; seqIndex < synthHelm_4.length; seqIndex++) {
                for (int noteNumber = 0; noteNumber < 127; noteNumber++) {
                    tempNote = synthHelm_4.GetNoteInRange(noteNumber, seqIndex, seqIndex+1);
                    if (tempNote != null) {
                        for (int h = 0; h < (tempNote.end_ - tempNote.start_); h++) {
                            patternBuilder.Note(Melanchall.DryWetMidi.MusicTheory.Note.Get((SevenBitNumber)tempNote.note_));
                            patternBuilder.StepBack();
                        }
                    }                                            
                    else if (tempNote == null) {
                                                                                                                                        
                    }
                }
                if (tempNote != null) {

                }
                else {
                    patternBuilder.StepForward();
                }
            }
        }                  

        var midiFile = patternBuilder.Build().ToFile(TempoMap.Default);
        Debug.Log("Test MIDI file created.");

        return midiFile;
    }      
}
