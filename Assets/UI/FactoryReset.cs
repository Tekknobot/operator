using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
