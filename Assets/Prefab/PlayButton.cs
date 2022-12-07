using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset();
        GameObject.Find("DrumSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPause() {
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().Reset(); 
        GameObject.Find("DrumSequencer").GetComponent<AudioHelm.SampleSequencer>().currentIndex = -1;         
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = !GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause; 
        //GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();  
    }
}
