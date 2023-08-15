using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;
using TMPro;
using AudioHelm;

public class MusicPlayerPro : MonoBehaviour
{
    public static MusicPlayer instance;

    public enum SeekDirection { Forward, Backward }
    
    public AudioSource source;
    public List<AudioClip> clips = new List<AudioClip>();
    public List<float> chopTime = new List<float>();
    public List<AudioClip> song = new List<AudioClip>();
    
    [SerializeField] [HideInInspector] public int currentIndex = 0;
    
    public FileInfo[] soundFiles;
    private List<string> validExtensions = new List<string> { ".ogg", ".wav" }; // Don't forget the "." i.e. "ogg" won't work - cause Path.GetExtension(filePath) will return .ext, not just ext.
    private string absolutePath = "./"; // relative path to where the app is running - change this to "./music" in your case

    public Button previous;
    public Toggle play;
    public Button next;
    public Button chop;

    public AudioSource audioSource;
    public Slider slider;

    public int songCount = 0;
    public int chopTimeIndex = 0;

    TextMeshProUGUI textmeshPro; 
    public GameObject sampleSequencer;
    Note index; 

	Dictionary<string, int> soundClip = new Dictionary<string, int>() {
		{ "SampleRow_0", 0 },
		{ "SampleRow_1", 1 },
		{ "SampleRow_2", 2 },
		{ "SampleRow_3", 3 },
		{ "SampleRow_4", 4 },
		{ "SampleRow_5", 5 },
		{ "SampleRow_6", 6 },
		{ "SampleRow_7", 7 },
		{ "SampleRow_8", 8 },
		{ "SampleRow_9", 9 },
		{ "SampleRow_10", 10 },
		{ "SampleRow_11", 11 },
		{ "SampleRow_12", 12 },
		{ "SampleRow_13", 13 },
		{ "SampleRow_14", 14 },
		{ "SampleRow_15", 15 },		
	};    

    public int noteTemp;

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

    void Start()
    {
        //being able to test in unity
        if (Application.isEditor) absolutePath = "C:/Unity Projects/KontrolSongs";
    
        if (source == null) source = gameObject.AddComponent<AudioSource>();

        Application.lowMemory += OnLowMemory;

        GetFileInfo();
        songCount = PlayerPrefs.GetInt("SongIndex");
        if (PlayerPrefs.GetFloat("ChopCount") >= 18) {
            StartCoroutine(LoadSaveFile(soundFiles[PlayerPrefs.GetInt("SongIndex")].FullName));
            StartCoroutine(AddSong());
            textmeshPro = GameObject.Find("ChopCount").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = PlayerPrefs.GetFloat("ChopCount").ToString();
            textmeshPro.color = Color.red;               
            for (int i = 0; i < PlayerPrefs.GetFloat("ChopCount"); i++) {          
                chopTime.Add(PlayerPrefs.GetFloat("ChopTime "+ i.ToString()));
            }
            StopCurrent();
        } 
        if (chopTime.Count == 0) {
            StartCoroutine(LoadFile(soundFiles[songCount].FullName)); 
            StopCurrent();
        }

        StopCurrent();
    }
 
    public void ChangeAudioTime()
    {
        audioSource.time = audioSource.clip.length * slider.value;
    }
 
    public void Update()
    {
        if (soundFiles.Length == 0) {
            return;
        } 
        else if (soundFiles.Length > 0) {
            slider.value = audioSource.time / audioSource.clip.length;  
        }
    }    
    
    public void PreviousOnClick() {
        if (soundFiles.Length == 0) {return;}
        Seek(SeekDirection.Backward);
        play.isOn = false;
        if (songCount <= 0) {return;}
        songCount--;
        StartCoroutine(LoadFile(soundFiles[songCount].FullName));
    }

    public void PlayOnClick() {
        if (soundFiles.Length == 0) {return;}

        if (play.isOn) {
            PlayCurrent();
        }
        else {
            StopCurrent();
        }  
    }  

    public void NextOnClick() {
        if (soundFiles.Length == 0) {return;}
        Seek(SeekDirection.Forward);
        play.isOn = false;
        if (songCount == soundFiles.Length - 1) {return;}
        songCount++;
        StartCoroutine(LoadFile(soundFiles[songCount].FullName));
    }    

    void StopTaskOnClick() {
        StopCurrent();
    }     

    public void OnChopDown() {
        if (soundFiles.Length == 0) {return;}
        chopTime.Add(audioSource.time);
        song.Add(clips[currentIndex]);
        PlayerPrefs.SetFloat("ChopTime "+ chopTimeIndex.ToString(), (audioSource.time));
        PlayerPrefs.SetFloat("ChopCount", chopTime.Count);
        PlayerPrefs.SetInt("SongIndex", songCount);
        PlayerPrefs.SetInt("ChopTimeIndex "+ chopTimeIndex.ToString(), chopTimeIndex+1);
        if (chopTimeIndex >= 0) {
            chopTimeIndex = chopTimeIndex+1;
        }
        textmeshPro = GameObject.Find("ChopCount").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = chopTime.Count.ToString();         
        if (chopTime.Count > 17) {
            textmeshPro = GameObject.Find("ChopCount").GetComponent<TextMeshProUGUI>();
            textmeshPro.color = Color.red;              
        }
    }    

    public void ClearChops() {
        chopTime.Clear();
        song.Clear();
        chopTimeIndex = 0;
        GameObject.Find("SampleSequencer").GetComponent<AudioHelm.SampleSequencer>().Clear();
        textmeshPro = GameObject.Find("ChopCount").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = "0";
        textmeshPro.color = Color.white; 
        PlayerPrefs.SetFloat("ChopCount", 0);        
    }
    
    void Seek(SeekDirection d)
    {
        if (d == SeekDirection.Forward)
            currentIndex = (currentIndex + 1) % clips.Count;
        else {
            currentIndex--;
            if (currentIndex < 0) currentIndex = clips.Count - 1;
        }
    }
    
    void PlayCurrent()
    {
        audioSource.time = 0;
        source.clip = clips[currentIndex];
        source.Play();
    }

    void StopCurrent()
    {
        source.clip = clips[currentIndex];
        source.Stop();
    }   
    
    bool IsValidFileType(string fileName)
    {
        return validExtensions.Contains(Path.GetExtension(fileName));
        // Alternatively, you could go fileName.SubString(fileName.LastIndexOf('.') + 1); that way you don't need the '.' when you add your extensions
    }

    void GetFileInfo() {
        // get all valid files        
        if (Application.platform == RuntimePlatform.Android)
        {
            var info = new DirectoryInfo(GetAndroidExternalFilesDir());
            soundFiles = info.GetFiles()
                .Where(f => IsValidFileType(f.Name))
                .ToArray();            
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            var info = new DirectoryInfo("/var/mobile/Containers/Data/Application/<guid>/Documents");
            soundFiles = info.GetFiles()
                .Where(f => IsValidFileType(f.Name))
                .ToArray();            
        }        
        else {
            var info = new DirectoryInfo(absolutePath);
            soundFiles = info.GetFiles()
                .Where(f => IsValidFileType(f.Name))
                .ToArray();            
        }        
    }

    private void OnLowMemory()
    {
        StartCoroutine(LowMemory());
        Resources.UnloadUnusedAssets();
    }


    public void ChopOn() {
        bool flag = false;
        for(int i = 0; i < 16; i++) {
            for(int j = 0; j < 16; j++) {
                if (GameObject.Find("AddPattern_Sample").GetComponent<DuplicateSynthSequencerScript>().z == 1) {                
                    if (GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(75-i, j, j+1) && GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex == j && GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 1) {
                        GetComponent<AudioSource>().time = GetComponent<MusicPlayerPro>().chopTime[(75-i)-59];  
                        GetComponent<AudioSource>().Play();
                        GetComponent<AudioSource>().SetScheduledEndTime(AudioSettings.dspTime + (GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)+1]-(GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)])));                                                                        
                    }      
                }                   
                if (GameObject.Find("AddPattern_Sample").GetComponent<DuplicateSynthSequencerScript>().z == 2) {                
                    if (GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(75-i, j, j+1) && GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex == j && GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 1) {
                        GetComponent<AudioSource>().time = GetComponent<MusicPlayerPro>().chopTime[(75-i)-59];  
                        GetComponent<AudioSource>().Play();
                        GetComponent<AudioSource>().SetScheduledEndTime(AudioSettings.dspTime + (GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)+1]-(GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)])));                                                                        
                    }   
                    if (GameObject.Find("SampleSequencer_2").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(75-i, j, j+1) && GameObject.Find("SampleSequencer_2").GetComponent<AudioHelm.SampleSequencer>().currentIndex == j && GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 2) {
                        GetComponent<AudioSource>().time = GetComponent<MusicPlayerPro>().chopTime[(75-i)-59];  
                        GetComponent<AudioSource>().Play();
                        GetComponent<AudioSource>().SetScheduledEndTime(AudioSettings.dspTime + (GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)+1]-(GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)])));                                                                        
                    }     
                }                
                if (GameObject.Find("AddPattern_Sample").GetComponent<DuplicateSynthSequencerScript>().z == 3) {                
                    if (GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(75-i, j, j+1) && GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex == j && GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 1) {
                        GetComponent<AudioSource>().time = GetComponent<MusicPlayerPro>().chopTime[(75-i)-59];  
                        GetComponent<AudioSource>().Play();
                        GetComponent<AudioSource>().SetScheduledEndTime(AudioSettings.dspTime + (GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)+1]-(GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)])));                                                                        
                    }   
                    if (GameObject.Find("SampleSequencer_2").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(75-i, j, j+1) && GameObject.Find("SampleSequencer_2").GetComponent<AudioHelm.SampleSequencer>().currentIndex == j && GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 2) {
                        GetComponent<AudioSource>().time = GetComponent<MusicPlayerPro>().chopTime[(75-i)-59];  
                        GetComponent<AudioSource>().Play();
                        GetComponent<AudioSource>().SetScheduledEndTime(AudioSettings.dspTime + (GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)+1]-(GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)])));                                                                        
                    }     
                    if (GameObject.Find("SampleSequencer_3").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(75-i, j, j+1) && GameObject.Find("SampleSequencer_3").GetComponent<AudioHelm.SampleSequencer>().currentIndex == j && GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 3) {
                        GetComponent<AudioSource>().time = GetComponent<MusicPlayerPro>().chopTime[(75-i)-59];  
                        GetComponent<AudioSource>().Play();
                        GetComponent<AudioSource>().SetScheduledEndTime(AudioSettings.dspTime + (GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)+1]-(GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)])));                                                                        
                    }  
                }                   
                if (GameObject.Find("AddPattern_Sample").GetComponent<DuplicateSynthSequencerScript>().z == 4) {                
                    if (GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(75-i, j, j+1) && GameObject.Find("SampleSequencer_1").GetComponent<AudioHelm.SampleSequencer>().currentIndex == j && GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 1) {
                        GetComponent<AudioSource>().time = GetComponent<MusicPlayerPro>().chopTime[(75-i)-59];  
                        GetComponent<AudioSource>().Play();
                        GetComponent<AudioSource>().SetScheduledEndTime(AudioSettings.dspTime + (GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)+1]-(GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)])));                                                                        
                    }   
                    if (GameObject.Find("SampleSequencer_2").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(75-i, j, j+1) && GameObject.Find("SampleSequencer_2").GetComponent<AudioHelm.SampleSequencer>().currentIndex == j && GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 2) {
                        GetComponent<AudioSource>().time = GetComponent<MusicPlayerPro>().chopTime[(75-i)-59];  
                        GetComponent<AudioSource>().Play();
                        GetComponent<AudioSource>().SetScheduledEndTime(AudioSettings.dspTime + (GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)+1]-(GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)])));                                                                        
                    }     
                    if (GameObject.Find("SampleSequencer_3").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(75-i, j, j+1) && GameObject.Find("SampleSequencer_3").GetComponent<AudioHelm.SampleSequencer>().currentIndex == j && GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 3) {
                        GetComponent<AudioSource>().time = GetComponent<MusicPlayerPro>().chopTime[(75-i)-59];  
                        GetComponent<AudioSource>().Play();
                        GetComponent<AudioSource>().SetScheduledEndTime(AudioSettings.dspTime + (GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)+1]-(GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)])));                                                                        
                    }  
                    if (GameObject.Find("SampleSequencer_4").GetComponent<AudioHelm.SampleSequencer>().NoteExistsInRange(75-i, j, j+1) && GameObject.Find("SampleSequencer_4").GetComponent<AudioHelm.SampleSequencer>().currentIndex == j && GameObject.Find("CurrentPattern_Sample").GetComponent<ShowCurrentPatternScript>().currentPatternSample == 4) {
                        GetComponent<AudioSource>().time = GetComponent<MusicPlayerPro>().chopTime[(75-i)-59];  
                        GetComponent<AudioSource>().Play();
                        GetComponent<AudioSource>().SetScheduledEndTime(AudioSettings.dspTime + (GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)+1]-(GetComponent<MusicPlayerPro>().chopTime[((75-i)-59)])));                                                                        
                    }
                }                                                                                         
            }
        }           
    }

    
    IEnumerator LoadFile(string path)
    {
        clips.Clear();
        Array.Clear(soundFiles, 0, soundFiles.Length);
        Resources.UnloadUnusedAssets();
        GetFileInfo();

        WWW www = new WWW("file://" + path);
        print("loading " + path);
    
        AudioClip clip = www.GetAudioClip(false);
        while(!clip.isReadyToPlay)
            yield return www;
    
        print("done loading");
        clip.name = Path.GetFileName(path);
        clips.Add(clip);
        source.clip = clips[currentIndex];
        textmeshPro = GameObject.Find("SongTitleText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = source.clip.name.ToString();        
    }  

    IEnumerator LoadSaveFile(string path)
    {
        WWW www = new WWW("file://" + path);
        print("loading " + path);
    
        AudioClip clip = www.GetAudioClip(false);
        while(!clip.isReadyToPlay)
            yield return www;
    
        print("done loading");
        clip.name = Path.GetFileName(path);
        clips.Add(clip);
        source.clip = clips[currentIndex];
        textmeshPro = GameObject.Find("SongTitleText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = source.clip.name.ToString(); 
    }    

    IEnumerator LowMemory() {
        yield return new WaitForSeconds(1);
    }    

    IEnumerator AddSong() {
        yield return new WaitForSeconds(0.1f);
            song.Add(clips[0]);          
    }  
}