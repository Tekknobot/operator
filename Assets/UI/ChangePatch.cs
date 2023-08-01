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
        helmController.LoadPatch(patches[(int)patch]);     
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
        helmController.LoadPatch(patches[(int)temp]);
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
        helmController.LoadPatch(patches[(int)temp]);
        textmeshPro_patchLabel.text = patches[(int)temp].name;
        PlayerPrefs.SetFloat("PatchIndex", temp);
        GetComponent<ChangeWave>().SyncParameters(); 
    }

    IEnumerator DefaultPatch() {
        yield return new WaitForSeconds(0.1f);
        helmController.LoadPatch(patches[(int)PlayerPrefs.GetFloat("Patch")]); 
        GameObject.Find("PatchSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("PatchIndex");    
        textmeshPro_patchLabel.text = patches[(int)PlayerPrefs.GetFloat("Patch")].name;
        temp = PlayerPrefs.GetFloat("PatchIndex"); 
        helmSource.mute = false;
        GetComponent<ChangeWave>().SyncParameters(); 
    }
}
