using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplerButton : MonoBehaviour
{
    public int panel = 0;

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
        mainPanel.transform.SetSiblingIndex(0);
    }    

    public void MainPanelBack() {
        mainPanel.transform.SetSiblingIndex(1);
    }
}
