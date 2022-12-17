using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthPanelButton : MonoBehaviour
{
    public int panel = 1;
    public GameObject mainPanel;
    public GameObject synthPanel;

    public void SynthPanelButtonFunction() {
        mainPanel.transform.SetSiblingIndex(1);
    }    

    public void MainPanelBackFunction() {
        mainPanel.transform.SetSiblingIndex(2);
    }
}
