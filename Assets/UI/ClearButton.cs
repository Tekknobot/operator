using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButton : MonoBehaviour
{
    public GameObject saveManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearOnClick() {
        StartCoroutine(saveManager.GetComponent<SaveManagerPro>().ClearSequencer());
    }
}
