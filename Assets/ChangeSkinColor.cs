using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class ChangeSkinColor : MonoBehaviour
{
    public Image imageLinker;
    public PostProcessVolume PPVolume;

    void Start() {
        imageLinker = gameObject.GetComponent<Image> ();          
    }

    void Update() {
    }

    public void RandomSkin() {
        imageLinker.color = Random.ColorHSV(0f, 1f, 0.5f, 0.5f, 1f, 1f);
        Bloom bloom = PPVolume.profile.GetSetting<UnityEngine.Rendering.PostProcessing.Bloom>();
        var colorParameter = new UnityEngine.Rendering.PostProcessing.ColorParameter();
        float factor = Mathf.Pow(1.65f,1f);
        colorParameter.value = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
        colorParameter.value.r *= factor; 
        colorParameter.value.g *= factor; 
        colorParameter.value.b *= factor; 
        bloom.color.Override(colorParameter);   
    }
}
