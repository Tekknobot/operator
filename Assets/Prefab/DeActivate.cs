using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActivate : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(DeActivateObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeActivateObject() {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}
