using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using TMPro;

public class Patches : MonoBehaviour
{
    public GameObject synthSequencer;
    public AudioHelm.HelmPatch[] patches;
    public int patchNumber = 0;
    TextMeshProUGUI textmeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GameObject.Find("PatchName").GetComponent<TextMeshProUGUI>();
        synthSequencer.GetComponent<HelmController>().LoadPatch(patches[patchNumber]);
        if (PlayerPrefs.HasKey("Patch")) {
            StartCoroutine(LoadPatch());
        }
        else {
            textmeshPro.text = patches[patchNumber].name;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextPatchData () {     
        patchNumber++;     
        if (patchNumber >= 162) {
            patchNumber = 162;
        }            
        PlayerPrefs.SetFloat("Patch", patchNumber);
        textmeshPro.text = patches[(int)PlayerPrefs.GetFloat("Patch")].name;
        synthSequencer.GetComponent<HelmController>().LoadPatch(patches[patchNumber]);	          
    }

    public void LoadPreviousPatchData () {	
        patchNumber--;        
        if (patchNumber <= 0) {
            patchNumber = 0;
        }   
        PlayerPrefs.SetFloat("Patch", patchNumber);      
        textmeshPro.text = patches[(int)PlayerPrefs.GetFloat("Patch")].name;
        synthSequencer.GetComponent<HelmController>().LoadPatch(patches[patchNumber]);       
    }    

    IEnumerator LoadPatch() {
        yield return new WaitForSeconds(0.1f);
        textmeshPro.text = patches[(int)PlayerPrefs.GetFloat("Patch")].name;
        patchNumber = (int)PlayerPrefs.GetFloat("Patch");
        synthSequencer.GetComponent<HelmController>().LoadPatch(patches[patchNumber]);        
    }
}
