using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MuteMixerScript : MonoBehaviour
{
    public Toggle kickMute;
    public Toggle snareMute;
    public Toggle closedHatMute;
    public Toggle openHatMute;
    public Toggle clapMute;
    public Toggle crashMute;
    public Toggle rideMute;
    public Toggle rimMute;

    public Toggle synth1Mute;
    public Toggle sampleMute;
    public Toggle synth2Mute;

    public AudioMixer kickMixer;
    public AudioMixer snareMixer;
    public AudioMixer closedHatMixer;
    public AudioMixer openHatMixer;
    public AudioMixer clapMixer;
    public AudioMixer crashMixer;
    public AudioMixer rideMixer;
    public AudioMixer rimMixer;

    public AudioMixer synth1Mixer;
    public AudioMixer sampleMixer;
    public AudioMixer synth2Mixer;    

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void MuteMixer() {
        if (kickMute.isOn == true) {
            kickMixer.SetFloat("Kick", -80f);
        } 
        else if (kickMute.isOn == false) { 
            kickMixer.SetFloat("Kick", PlayerPrefs.GetFloat("kickVolume"));
        }  

        if (snareMute.isOn == true) {
            snareMixer.SetFloat("Snare", -80f);
        } 
        else if (snareMute.isOn == false) { 
            snareMixer.SetFloat("Snare", PlayerPrefs.GetFloat("snareVolume"));
        }    

        if (closedHatMute.isOn == true) {
            closedHatMixer.SetFloat("CHAT", -80f);
        } 
        else if (closedHatMute.isOn == false) { 
            closedHatMixer.SetFloat("CHAT", PlayerPrefs.GetFloat("cHatVolume"));
        }   

        if (openHatMute.isOn == true) {
            openHatMixer.SetFloat("OHAT", -80f);
        } 
        else if (openHatMute.isOn == false) { 
            openHatMixer.SetFloat("OHAT", PlayerPrefs.GetFloat("oHatVolume"));
        }        

        if (clapMute.isOn == true) {
            clapMixer.SetFloat("Clap", -80f);
        } 
        else if (clapMute.isOn == false) { 
            clapMixer.SetFloat("Clap", PlayerPrefs.GetFloat("clapVolume"));
        }        

        if (crashMute.isOn == true) {
            crashMixer.SetFloat("Crash", -80f);
        } 
        else if (crashMute.isOn == false) { 
            crashMixer.SetFloat("Crash", PlayerPrefs.GetFloat("crashVolume"));
        }     

        if (rideMute.isOn == true) {
            rideMixer.SetFloat("Ride", -80f);
        } 
        else if (rideMute.isOn == false) { 
            rideMixer.SetFloat("Ride", PlayerPrefs.GetFloat("rideVolume"));
        }     

        if (rimMute.isOn == true) {
            rimMixer.SetFloat("Rim", -80f);
        } 
        else if (rimMute.isOn == false) { 
            rimMixer.SetFloat("Rim", PlayerPrefs.GetFloat("rimVolume"));
        }         

        if (synth1Mute.isOn == true) {
            synth1Mixer.SetFloat("Synth1", -80f);
        } 
        else if (synth1Mute.isOn == false) { 
            synth1Mixer.SetFloat("Synth1", PlayerPrefs.GetFloat("synthMixerVol1"));
        }    

        if (sampleMute.isOn == true) {
            sampleMixer.SetFloat("Sample", -80f);
        } 
        else if (sampleMute.isOn == false) { 
            sampleMixer.SetFloat("Sample", PlayerPrefs.GetFloat("sampleMixerVol"));
        }     

        if (synth2Mute.isOn == true) {
            synth2Mixer.SetFloat("Synth2", -80f);
        } 
        else if (synth2Mute.isOn == false) { 
            synth2Mixer.SetFloat("Synth2", PlayerPrefs.GetFloat("synthMixerVol2"));
        }                                                                    
    }    
}
