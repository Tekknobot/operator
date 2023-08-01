using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    public int BG_num = 0;

    public void ChangeBG_num() {
        BG_num++;
        if (BG_num > 7) {
            BG_num = 0;
        }                                                  
    }
}
