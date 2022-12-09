using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndexObjectPro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<RawImage>().color == Color.yellow) {
            StartCoroutine(ResetColor());
        }
    }

    IEnumerator ResetColor() {
        yield return new WaitForSeconds(0.1f);
        GetComponent<RawImage>().color = new Color(0.3f, 0.3f, 0.3f);        
    }
}
