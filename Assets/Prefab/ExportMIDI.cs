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
    public AudioHelm.HelmSequencer synthHelm;
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
        if (Application.isEditor) absolutePath = "C:/Unity Projects/PocketPunkMIDI";
        if (Application.platform == RuntimePlatform.Android) absolutePath = GetAndroidExternalFilesDir();
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


        midiNotes = synthHelm.GetAllNotes();
        offNotes = synthHelm.GetAllNoteOffsInRange(0, 64);

        for (int seqIndex = 0; seqIndex < synthHelm.length; seqIndex++) {
            for (int noteNumber = 0; noteNumber < 127; noteNumber++) {
                tempNote = synthHelm.GetNoteInRange(noteNumber, seqIndex, seqIndex+1);
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

        var midiFile = patternBuilder.Build().ToFile(TempoMap.Default);
        Debug.Log("Test MIDI file created.");

        return midiFile;
    }      
}
