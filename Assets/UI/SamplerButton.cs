using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplerButton : MonoBehaviour
{
    public int panel = 1;

    public GameObject mainPanel;
    public GameObject samplerPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SamplerPanelButton() {
        samplerPanel.transform.SetSiblingIndex(2);
    }    

    public void MainPanelBack() {
        samplerPanel.transform.SetSiblingIndex(0);
    }
}
