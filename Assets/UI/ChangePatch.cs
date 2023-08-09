using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangePatch : MonoBehaviour
{   
    public AudioHelm.HelmController helmController;

    public float patch;
    public float temp;

    public AudioHelm.HelmPatch[] patches;

    public GameObject synth;
    public AudioSource helmSource;

    public TextMeshProUGUI textmeshPro_patchLabel;

    // Start is called before the first frame update
    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        helmController = synth.GetComponent<AudioHelm.HelmController>();
        textmeshPro_patchLabel = GameObject.Find("PatchName").GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.HasKey("PatchIndex")) {
            StartCoroutine(DefaultPatch());
        }               
    }

    public void SyncPatch() {
		patch = GameObject.Find("PatchSlider").GetComponent<Slider>().value;
        if (GameObject.Find("SynthSequencer_1")) {        
            GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]);
        }
        if (GameObject.Find("SynthSequencer_2")) {     
            GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]);
        }
        if (GameObject.Find("SynthSequencer_3")) {        
            GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]);
        }
        if (GameObject.Find("SynthSequencer_4")) {        
            GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]); 
        }                                             
        textmeshPro_patchLabel.text = patches[(int)patch].name;
        temp = (int)patch;  
        PlayerPrefs.SetFloat("Patch", patch);
        PlayerPrefs.SetFloat("PatchIndex", temp);
        GetComponent<ChangeWave>().SyncParameters();  
    } 

    public void NextPatchFunction() {
        temp++;
        if (temp >= 162) {
            temp = 162;
        }        
        GameObject.Find("PatchSlider").GetComponent<Slider>().value = temp;
        if (GameObject.Find("SynthSequencer_1")) {        
            GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]);
        }
        if (GameObject.Find("SynthSequencer_2")) {     
            GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]);
        }
        if (GameObject.Find("SynthSequencer_3")) {        
            GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]);
        }
        if (GameObject.Find("SynthSequencer_4")) {        
            GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]); 
        }   
        textmeshPro_patchLabel.text = patches[(int)temp].name;
        PlayerPrefs.SetFloat("PatchIndex", temp);
        GetComponent<ChangeWave>().SyncParameters(); 
    }   

    public void PreviousPatchFunction() {
        temp--;
        if (temp <= -1) {
            temp = 0;
        }        
        GameObject.Find("PatchSlider").GetComponent<Slider>().value = temp;
        if (GameObject.Find("SynthSequencer_1")) {        
            GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]);
        }
        if (GameObject.Find("SynthSequencer_2")) {     
            GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]);
        }
        if (GameObject.Find("SynthSequencer_3")) {        
            GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]);
        }
        if (GameObject.Find("SynthSequencer_4")) {        
            GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]); 
        }   
        textmeshPro_patchLabel.text = patches[(int)temp].name;
        PlayerPrefs.SetFloat("PatchIndex", temp);
        GetComponent<ChangeWave>().SyncParameters(); 
    }

    IEnumerator DefaultPatch() {
        yield return new WaitForSeconds(0.1f);
        if (GameObject.Find("SynthSequencer_1")) {        
            GameObject.Find("SynthSequencer_1").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]);
        }
        if (GameObject.Find("SynthSequencer_2")) {     
            GameObject.Find("SynthSequencer_2").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]);
        }
        if (GameObject.Find("SynthSequencer_3")) {        
            GameObject.Find("SynthSequencer_3").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]);
        }
        if (GameObject.Find("SynthSequencer_4")) {        
            GameObject.Find("SynthSequencer_4").GetComponent<AudioHelm.HelmController>().LoadPatch(patches[(int)patch]); 
        }    
        GameObject.Find("PatchSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("PatchIndex");    
        textmeshPro_patchLabel.text = patches[(int)PlayerPrefs.GetFloat("Patch")].name;
        temp = PlayerPrefs.GetFloat("PatchIndex"); 
        helmSource.mute = false;
        GetComponent<ChangeWave>().SyncParameters(); 
    }
}
