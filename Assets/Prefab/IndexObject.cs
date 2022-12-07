using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndexObject : MonoBehaviour
{
    public int step;
    public bool samplePad;
    public int midiNote;
    public int samplePadNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Button>().colors.normalColor == Color.grey) {
            StartCoroutine(ResetColor());
        }
    }

    IEnumerator ResetColor() {
        yield return new WaitForSeconds(0.1f);
        var colors = GetComponent<Button>().colors;
        colors.normalColor = Color.white;   
        GetComponent<Button>().colors = colors;     
    }
}
