using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideCell : MonoBehaviour
{    
    public bool isFullyVisible;

    // Start is called before the first frame update
    void Start()
    {
        isFullyVisible = this.GetComponent<RectTransform>().IsFullyVisibleFrom(Camera.main);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<RectTransform>().IsFullyVisibleFrom(Camera.main)) {
            isFullyVisible = true;
        }
        else {
            isFullyVisible = false;
        }
    }
}
