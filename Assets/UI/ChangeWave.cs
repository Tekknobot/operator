using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class ChangeWave : MonoBehaviour
{
    public AudioHelm.HelmController helmController;

    public float osc1;
	public float osc2;

    public float attack;
    public float decay;
    public float sustain;
    public float release;

    public float attackFilter;
    public float decayFilter;
    public float sustainFilter;
    public float releaseFilter;

    public float attackMod;
    public float decayMod;
    public float sustainMod;
    public float releaseMod;        

    public float sub;
    public float gain;

    public float delayOn;
    public float delayFreq;
    public float delayFb;
    public float delayDryWet;

    public float distortionOn;
    public float distortionDrive;
    public float distortionMix;
    public float distortionType;   

    public float legato; 
    public bool isLegatoOn;

    public float osc1Gain;
    public float osc2Gain;
    public float subGain;
    public float noiseGain;

    public float arpOn;
    public float arpFreq;
    public float arpGate;
    public float arpOctaves;
    public float arpPattern;

    public float filterOn;
    public float filterEnvDepth;
    public float filterBlend;
    public float filterDrive;  
    public float filterShelf; 
    public float filterStyle; 
    public float filterType;
    public float keyTrack;
    public float cutOff;    

    public float LFO1Amp;
    public float LFO1Freq;
    public float LFO1Retrig;
    public float LFO1Sync;
    public float LFO1Tempo;
    public float LFO1Wave;

    public float LFO2Amp;
    public float LFO2Freq;
    public float LFO2Retrig;
    public float LFO2Sync;
    public float LFO2Tempo;
    public float LFO2Wave;

    public float PolyLFOAmp;
    public float PolyLFOFreq;
    public float PolyLFOSync;
    public float PolyLFOTempo;
    public float PolyLFOWave;  

    public AudioMixer mixer;
    public float highCut;
    public float highRes;
    public float lowCut;
    public float lowRes;      

    public GameObject synth;
    public AudioSource helmSource;

    public bool syncing = false;

    TextMeshProUGUI textmeshPro_WFT1;
    TextMeshProUGUI textmeshPro_WFT2;

	Dictionary<int, string> waveForm = new Dictionary<int, string>() {
		{ 0, "sine" },
		{ 1, "triangle" },
		{ 2, "square" },
		{ 3, "saw up" },
		{ 4, "saw down" },
		{ 5, "3 step" },
		{ 6, "4 step" },
		{ 7, "8 step" },
        { 8, "3 pyramid"},
        { 9, "5 pyramid" },
        { 10, "9 pyramid" },
	};    

    // Start is called before the first frame update
    void Awake()
    {
        helmController = GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmController>(); 
    }

    void Start() {
        legato = helmController.GetParameterValue(AudioHelm.Param.kLegato);
        textmeshPro_WFT1 = GameObject.Find("WaveFormText_1").GetComponent<TextMeshProUGUI>();
        textmeshPro_WFT2 = GameObject.Find("WaveFormText_2").GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        textmeshPro_WFT1.text = waveForm[(int)osc1];
        textmeshPro_WFT2.text = waveForm[(int)osc2];

        if (helmController.GetParameterValue(AudioHelm.Param.kLegato) == 0) {
            isLegatoOn = false;
            legato = 0;
        } 
        else if (helmController.GetParameterValue(AudioHelm.Param.kLegato) == 1) {
            isLegatoOn = true;
            legato = 1;
        }      
    }

    public void Osc1() {
        osc1 = GameObject.Find ("WaveFormSlider 1").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kOsc1Waveform, osc1);
    }

    public void Osc2() {
        osc2 = GameObject.Find ("WaveFormSlider 2").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kOsc2Waveform, osc2);
    }    

    public void Attack() {
        attack = GameObject.Find ("AmpAttack").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kAmplitudeAttack, attack);
    }

    public void Decay() {
        decay = GameObject.Find ("AmpDecay").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kAmplitudeDecay, decay);
    }   

    public void Sustain() {
        sustain = GameObject.Find ("AmpSustain").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kAmplitudeSustain, sustain); 
    }      

    public void Release() {
        release = GameObject.Find ("AmpRelease").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kAmplitudeRelease, release);
    }     

    public void FilterAttack() {
        attackFilter = GameObject.Find ("FilterAttack").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kFilterAttack, attackFilter);
    }

    public void FilterDecay() {
        decayFilter = GameObject.Find ("FilterDecay").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kFilterDecay, decayFilter);
    }   

    public void FilterSustain() {
        sustainFilter = GameObject.Find ("FilterSustain").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kFilterSustain, sustainFilter);
    }      

    public void FilterRelease() {
        releaseFilter = GameObject.Find ("FilterRelease").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kFilterRelease, releaseFilter);
    }     

    public void ModAttack() {
        attackMod = GameObject.Find ("ModAttack").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kModAttack, attackMod);
    }

    public void ModDecay() {
        decayMod = GameObject.Find ("ModDecay").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kModDecay, decayMod);
    }   

    public void ModSustain() {
        sustainMod = GameObject.Find ("ModSustain").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kModSustain, sustainMod);
    }      

    public void ModRelease() {
        releaseMod = GameObject.Find ("ModRelease").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kModRelease, releaseMod);
    }    

    public void Gain() {
        gain = GameObject.Find ("Gain").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kVolume, gain);
    }      

    public void Sub() {
        sub = GameObject.Find ("Sub").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kSubVolume, sub);
    }         

    public void DelayOn() {
        delayOn = GameObject.Find ("DelayOn").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kDelayOn, delayOn);
    }    

    public void DelayFreq() {
        delayFreq = GameObject.Find("DelayFreq").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kDelayFrequency, delayFreq);
    }  

    public void DelayFb() {
        delayFb = GameObject.Find("DelayFb").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kDelayFeedback, delayFb);
    }     

    public void DelayDryWet() {
        delayDryWet = GameObject.Find("DelayDryWet").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kDelayDryWet, delayDryWet);
    }       

    public void DistortionOn() {
        distortionOn = GameObject.Find("DistortionOn").GetComponent<Slider>().value;
        helmController.SetParameterPercent(AudioHelm.Param.kDistortionOn, distortionOn);
    }    

    public void DistortionDrive() {
        distortionDrive = GameObject.Find("DistortionDrive").GetComponent<Slider>().value;
        helmController.SetParameterPercent(AudioHelm.Param.kDistortionDrive, distortionDrive);
    }    

    public void DistortionMix() {
        distortionMix = GameObject.Find("DistortionMix").GetComponent<Slider>().value;
        helmController.SetParameterPercent(AudioHelm.Param.kDistortionMix, distortionMix);
    }    

    public void DistortionType() {
        distortionType = GameObject.Find("DistortionType").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kDistortionType, distortionType);
    }  

    public void LegatoSwitch() {
        if (isLegatoOn == true) {
            helmController.SetParameterValue(AudioHelm.Param.kLegato, 0);
        }
        else if (isLegatoOn == false) {
            helmController.SetParameterValue(AudioHelm.Param.kLegato, 1);
        }    
    }   

    public void Osc1Gain() {
        osc1Gain = GameObject.Find("O1").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kOsc1Volume, osc1Gain);        
    } 

    public void Osc2Gain() {
        osc2Gain = GameObject.Find("O2").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kOsc2Volume, osc2Gain);        
    }       

    public void SubGain() {
        subGain = GameObject.Find("SubGain").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kSubVolume, subGain);        
    }    

    public void NoiseGain() {
        noiseGain = GameObject.Find("Noise").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kNoiseVolume, noiseGain);        
    }    

    public void ArpOn() {
        arpOn = GameObject.Find("ArpOn").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kArpOn, arpOn);        
    } 

    public void ArpFreq() {
        arpFreq = GameObject.Find("ArpQ").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kArpFrequency, arpFreq);        
    }       

    public void ArpGate() {
        arpGate = GameObject.Find("ArpGate").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kArpGate, arpGate);        
    }       

    public void ArpOctaves() {
        arpOctaves = GameObject.Find("ArpOctave").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kArpOctaves, arpOctaves);        
    }     

    public void ArpPattern() {
        arpPattern = GameObject.Find("ArpPattern").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kArpPattern, arpPattern);        
    }    

    public void FilterOn() {
        filterOn = GameObject.Find("FilterMainOn").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kFilterOn, filterOn);        
    }     

    public void FilterEnvDepth() {
        filterEnvDepth = GameObject.Find("FilterEnvDepth").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kFilterEnvelopeDepth, filterEnvDepth);        
    }  

    public void FilterBlend() {
        filterBlend = GameObject.Find("FilterBlend").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kFilterBlend, filterBlend);        
    }    

    public void FilterDrive() {
        filterDrive = GameObject.Find("FilterDrive").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kFilterDrive, filterDrive);        
    }   

    public void FilterShelf() {
        filterShelf = GameObject.Find("FilterShelf").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kFilterShelf, filterShelf);        
    }       

    public void FilterStyle() {
        filterStyle = GameObject.Find("FilterStyle").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kFilterStyle, filterStyle);        
    }     

    public void KeyTrack() {
        keyTrack = GameObject.Find("KeyTrack").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kKeytrack, keyTrack);        
    }       

    public void FilterCutOff() {
        cutOff = GameObject.Find("CutOff").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kFilterCutoff, cutOff);        
    }   

    public void LFO1AmpFunction() {
        LFO1Amp = GameObject.Find("LFO1Amp").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kMonoLfo1Amplitude, LFO1Amp);        
    }        

    public void LFO1FreqFunction() {
        LFO1Freq = GameObject.Find("LFO1Freq").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kMonoLfo1Frequency, LFO1Freq);        
    }   

    public void LFO1RetrigFunction() {
        LFO1Retrig = GameObject.Find("LFO1Retrig").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kMonoLfo1Frequency, LFO1Retrig);        
    }        

    public void LFO1SyncFunction() {
        LFO1Sync = GameObject.Find("LFO1Sync").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kMonoLfo1Frequency, LFO1Sync);        
    }  

    public void LFO1TempoFunction() {
        LFO1Tempo = GameObject.Find("LFO1Tempo").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kMonoLfo1Frequency, LFO1Tempo);        
    }   

    public void LFO1WaveFunction() {
        LFO1Wave = GameObject.Find("LFO1Tempo").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kMonoLfo1Waveform, LFO1Wave);        
    }     

    public void LFO2AmpFunction() {
        LFO2Amp = GameObject.Find("LFO2Amp").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kMonoLfo2Amplitude, LFO2Amp);        
    }        

    public void LFO2FreqFunction() {
        LFO2Freq = GameObject.Find("LFO2Freq").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kMonoLfo2Frequency, LFO2Freq);        
    }   

    public void LFO2RetrigFunction() {
        LFO2Retrig = GameObject.Find("LFO2Retrig").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kMonoLfo2Frequency, LFO2Retrig);        
    }        

    public void LFO2SyncFunction() {
        LFO2Sync = GameObject.Find("LFO2Sync").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kMonoLfo2Frequency, LFO2Sync);        
    }  

    public void LFO2TempoFunction() {
        LFO2Tempo = GameObject.Find("LFO2Tempo").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kMonoLfo2Frequency, LFO2Tempo);        
    }   

    public void LFO2WaveFunction() {
        LFO2Wave = GameObject.Find("LFO2Tempo").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kMonoLfo2Waveform, LFO2Wave);        
    }      

    public void PolyLFOAmpFunction() {
        PolyLFOAmp = GameObject.Find("PolyLFOAmp").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kPolyLfoAmplitude, PolyLFOAmp);        
    }        

    public void PolyLFOFreqFunction() {
        PolyLFOFreq = GameObject.Find("PolyLFOFreq").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kPolyLfoFrequency, PolyLFOFreq);        
    }         

    public void PolyLFOSyncFunction() {
        PolyLFOSync = GameObject.Find("PolyLFOSync").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kPolyLfoSync, PolyLFOSync);        
    }  

    public void PolyLFOTempoFunction() {
        PolyLFOTempo = GameObject.Find("PolyLFOTempo").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kPolyLfoTempo, PolyLFOTempo);        
    }   

    public void PolyLFOWaveFunction() {
        PolyLFOWave = GameObject.Find("PolyLFOTempo").GetComponent<Slider>().value;
        helmController.SetParameterValue(AudioHelm.Param.kPolyLfoWaveform, PolyLFOWave);        
    }       

    public void HighPassCut() {
        highCut = GameObject.Find("HP").GetComponent<Slider>().value;
		mixer.SetFloat("HighCut", highCut);       
    }        

    public void LowPassCut() {
        lowCut = GameObject.Find("LP").GetComponent<Slider>().value;    
        mixer.SetFloat("LowCut", lowCut);   
    }                                          

    public void SyncParameters() {
        GameObject.Find("WaveFormSlider 1").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kOsc1Waveform);
        GameObject.Find("WaveFormSlider 2").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kOsc2Waveform);

        GameObject.Find("AmpAttack").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kAmplitudeAttack);
		GameObject.Find("AmpDecay").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kAmplitudeDecay);
        GameObject.Find("AmpSustain").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kAmplitudeSustain);
		GameObject.Find("AmpRelease").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kAmplitudeRelease);

        GameObject.Find("FilterAttack").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kFilterAttack);
		GameObject.Find("FilterDecay").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kFilterDecay);
        GameObject.Find("FilterSustain").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kFilterSustain);
		GameObject.Find("FilterRelease").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kFilterRelease);    

        GameObject.Find("ModAttack").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kModAttack);
		GameObject.Find("ModDecay").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kModDecay);
        GameObject.Find("ModSustain").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kModSustain);
		GameObject.Find("ModRelease").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kModRelease);            

        GameObject.Find("Sub").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kSubVolume);   
        GameObject.Find("Gain").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kVolume);

        GameObject.Find("DelayOn").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kDelayOn); 
        GameObject.Find("DelayFreq").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kDelayFrequency);
        GameObject.Find("DelayFb").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kDelayFeedback);
        GameObject.Find("DelayDryWet").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kDelayDryWet);

        GameObject.Find("DistortionOn").GetComponent<Slider>().value = helmController.GetParameterPercent(AudioHelm.Param.kDistortionOn); 
        GameObject.Find("DistortionDrive").GetComponent<Slider>().value = helmController.GetParameterPercent(AudioHelm.Param.kDistortionDrive);
        GameObject.Find("DistortionMix").GetComponent<Slider>().value = helmController.GetParameterPercent(AudioHelm.Param.kDistortionMix);
        GameObject.Find("DistortionType").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kDistortionType); 

        GameObject.Find("O1").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kOsc1Volume); 
        GameObject.Find("O2").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kOsc2Volume);
        GameObject.Find("SubGain").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kSubVolume);
        GameObject.Find("Noise").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kNoiseVolume);   

        GameObject.Find("ArpOn").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kArpOn); 
        GameObject.Find("ArpQ").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kArpFrequency);
        GameObject.Find("ArpGate").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kArpGate);
        GameObject.Find("ArpOctave").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kArpOctaves);    
        GameObject.Find("ArpPattern").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kArpPattern);           

        GameObject.Find("FilterMainOn").GetComponent<Slider>().value = 1; 
        GameObject.Find("FilterEnvDepth").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kFilterEnvelopeDepth);
        GameObject.Find("FilterBlend").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kFilterBlend);
        GameObject.Find("FilterDrive").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kFilterDrive);    
        GameObject.Find("FilterShelf").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kFilterShelf);
        GameObject.Find("FilterStyle").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kFilterStyle);    
        GameObject.Find("KeyTrack").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kKeytrack);
        
        GameObject.Find("CutOff").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kFilterCutoff);
        
        // GameObject.Find ("LFO1Amp").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kMonoLfo1Amplitude);
        // GameObject.Find ("LFO1Freq").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kMonoLfo1Frequency);
        // GameObject.Find ("LFO1Retrig").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kMonoLfo1Retrigger);
        // GameObject.Find ("LFO1Sync").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kMonoLfo1Sync);
        // GameObject.Find ("LFO1Tempo").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kMonoLfo1Tempo);
        // GameObject.Find ("LFO1Wave").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kMonoLfo1Waveform);

        // GameObject.Find ("LFO2Amp").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kMonoLfo2Amplitude);
        // GameObject.Find ("LFO2Freq").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kMonoLfo2Frequency);
        // GameObject.Find ("LFO2Retrig").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kMonoLfo2Retrigger);
        // GameObject.Find ("LFO2Sync").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kMonoLfo2Sync);
        // GameObject.Find ("LFO2Tempo").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kMonoLfo2Tempo);
        // GameObject.Find ("LFO2Wave").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kMonoLfo2Waveform);

        // GameObject.Find ("PolyLFOAmp").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kPolyLfoAmplitude);
        // GameObject.Find ("PolyLFOFreq").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kPolyLfoFrequency);
        // GameObject.Find ("PolyLFOSync").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kPolyLfoSync);
        // GameObject.Find ("PolyLFOTempo").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kPolyLfoTempo);
        // GameObject.Find ("PolyLFOWave").GetComponent<Slider>().value = helmController.GetParameterValue(AudioHelm.Param.kPolyLfoWaveform);

        //helmController.SetParameterValue(AudioHelm.Param.kLegato, legato);     
    }
}
