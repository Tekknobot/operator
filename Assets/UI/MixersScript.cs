using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MixersScript : MonoBehaviour
{
    public float kickVolume = 0f;
	public float snareVolume = 0f;
	public float cHatVolume = 0f;
	public float oHatVolume = 0f;
	public float clapVolume = 0f;
	public float crashVolume = 0f;
	public float rideVolume = 0f;
	public float rimVolume = 0f;

	public float synthMixerVol1 = 0f;
	public float sampleMixerVol = 0f;
	public float synthMixerVol2 = 0f;

	public int patch;

    public AudioMixer mixer;

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

    // Start is called before the first frame update
    void Awake()
    {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
		GameObject.Find ("Mixer 1").GetComponent<Slider>().value = PlayerPrefs.GetFloat("kickVolume");
		GameObject.Find ("Mixer 2").GetComponent<Slider>().value = PlayerPrefs.GetFloat("snareVolume");
		GameObject.Find ("Mixer 3").GetComponent<Slider>().value = PlayerPrefs.GetFloat("cHatVolume");
		GameObject.Find ("Mixer 4").GetComponent<Slider>().value = PlayerPrefs.GetFloat("oHatVolume");
		GameObject.Find ("Mixer 5").GetComponent<Slider>().value = PlayerPrefs.GetFloat("clapVolume");
		GameObject.Find ("Mixer 6").GetComponent<Slider>().value = PlayerPrefs.GetFloat("crashVolume");
		GameObject.Find ("Mixer 7").GetComponent<Slider>().value = PlayerPrefs.GetFloat("rideVolume");
		GameObject.Find ("Mixer 8").GetComponent<Slider>().value = PlayerPrefs.GetFloat("rimVolume");
		GameObject.Find ("Mixer 9").GetComponent<Slider>().value = PlayerPrefs.GetFloat("synthMixerVol1");
		GameObject.Find ("Mixer 10").GetComponent<Slider>().value = PlayerPrefs.GetFloat("sampleMixerVol");
		GameObject.Find ("Mixer 11").GetComponent<Slider>().value = PlayerPrefs.GetFloat("synthMixerVol2");

		kickVolume = GameObject.Find ("Mixer 1").GetComponent<Slider>().value;
		snareVolume = GameObject.Find ("Mixer 2").GetComponent<Slider>().value;
		cHatVolume = GameObject.Find ("Mixer 3").GetComponent<Slider>().value;
		oHatVolume = GameObject.Find ("Mixer 4").GetComponent<Slider>().value;
		clapVolume = GameObject.Find ("Mixer 5").GetComponent<Slider>().value;
		crashVolume = GameObject.Find ("Mixer 6").GetComponent<Slider>().value;
		rideVolume = GameObject.Find ("Mixer 7").GetComponent<Slider>().value;
		rimVolume = GameObject.Find ("Mixer 8").GetComponent<Slider>().value;    

		synthMixerVol1 = GameObject.Find ("Mixer 9").GetComponent<Slider>().value;
		sampleMixerVol = GameObject.Find ("Mixer 10").GetComponent<Slider>().value;
		synthMixerVol2 = GameObject.Find ("Mixer 11").GetComponent<Slider>().value;		    
    }

	public void SetKick() { 	
		if (GameObject.Find ("Mixer 1")) {		
			kickVolume = GameObject.Find ("Mixer 1").GetComponent<Slider>().value;
			PlayerPrefs.SetFloat("kickVolume", kickVolume);
			mixer.SetFloat("Kick", kickVolume);
			kickMute.isOn = false;
		}	
	}

	public void SetSnare() { 
		if (GameObject.Find ("Mixer 2")) {	
			snareVolume = GameObject.Find ("Mixer 2").GetComponent<Slider>().value;
			PlayerPrefs.SetFloat("snareVolume", snareVolume);
			mixer.SetFloat("Snare", snareVolume);
			snareMute.isOn = false;	
		}	
	}

	public void SetCHat() { 
		if (GameObject.Find ("Mixer 3")) {	
			cHatVolume = GameObject.Find ("Mixer 3").GetComponent<Slider>().value;
			PlayerPrefs.SetFloat("cHatVolume", cHatVolume);
			mixer.SetFloat("CHAT", cHatVolume);
			closedHatMute.isOn = false;
		}
	}

	public void SetOHat() { 
		if (GameObject.Find ("Mixer 4")) {
			oHatVolume = GameObject.Find ("Mixer 4").GetComponent<Slider>().value;
			PlayerPrefs.SetFloat("oHatVolume", oHatVolume);
			mixer.SetFloat("OHAT", oHatVolume);
			openHatMute.isOn = false;
		}
	}

	public void SetClap() { 
		if (GameObject.Find ("Mixer 5")) {
			clapVolume = GameObject.Find ("Mixer 5").GetComponent<Slider>().value;
			PlayerPrefs.SetFloat("clapVolume", clapVolume);
			mixer.SetFloat("Clap", clapVolume);
			clapMute.isOn = false;		}
	}	

	public void SetCrash() { 
		if (GameObject.Find ("Mixer 6")) {
			crashVolume = GameObject.Find ("Mixer 6").GetComponent<Slider>().value;
			PlayerPrefs.SetFloat("crashVolume", crashVolume);
			mixer.SetFloat("Crash", crashVolume);
			crashMute.isOn = false;
		}
	}

	public void SetRide() { 
		if (GameObject.Find ("Mixer 7")) {
			rideVolume = GameObject.Find ("Mixer 7").GetComponent<Slider>().value;
			PlayerPrefs.SetFloat("rideVolume", rideVolume);
			mixer.SetFloat("Ride", rideVolume);
			rideMute.isOn = false;
		}	
	}

	public void SetRim() { 
		if (GameObject.Find ("Mixer 8")) {
			rimVolume = GameObject.Find ("Mixer 8").GetComponent<Slider>().value;
			PlayerPrefs.SetFloat("rimVolume", rimVolume);
			mixer.SetFloat("Rim", rimVolume);
			rimMute.isOn = false;
		}
	}    

	public void SetSynthMixer1() { 
		if (GameObject.Find ("Mixer 9")) {
			synthMixerVol1 = GameObject.Find ("Mixer 9").GetComponent<Slider>().value;
			PlayerPrefs.SetFloat("synthMixerVol1", synthMixerVol1);
			mixer.SetFloat("Synth1", synthMixerVol1);
		}
	}	

	public void SetSamplerSlider() { 
		if (GameObject.Find ("Mixer 10")) {
			sampleMixerVol = GameObject.Find ("Mixer 10").GetComponent<Slider>().value;
			PlayerPrefs.SetFloat("sampleMixerVol", sampleMixerVol);
			mixer.SetFloat("Sample", sampleMixerVol);
		}				
    }

	public void SetSynthMixer2() { 
		if (GameObject.Find ("Mixer 11")) {
			synthMixerVol2 = GameObject.Find ("Mixer 11").GetComponent<Slider>().value;
			PlayerPrefs.SetFloat("synthMixerVol2", synthMixerVol2);
			mixer.SetFloat("Synth2", synthMixerVol2);
		}
	}		
}
