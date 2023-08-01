using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;
using TMPro;


public class PopulatePianoRoll_Synth : MonoBehaviour
{
    public GameObject prefab;
    public int numberToCreate = 12;
    public int numberOfGroups = 10;

    public int key_Number = 24;
    public bool flag = false;

    public string noteName = "SynthNote ";
    public int totalNotes = -1;

    public GameObject synthNote_temp;

    TextMeshProUGUI textmeshPro;

    //Major
    public string Ab_Maj = "Ab Maj";
    public string A_Maj = "A Maj";
    public string Bb_Maj = "Bb Maj";
    public string B_Maj = "B Maj";
    public string C_Maj = "Ab Maj";
    public string Db_Maj = "Db Maj";
    public string D_Maj = "D Maj";
    public string Eb_Maj = "Eb Maj";
    public string E_Maj = "E Maj";
    public string F_Maj = "F Maj";
    public string Fsharp_Maj = "F# Maj";
    public string G_Maj = "G Maj";

    //Minor
    public string A_Min = "A Min";
    public string Bb_Min = "Bb Min";
    public string B_Min = "B Min";
    public string C_Min = "C Min";
    public string Csharp_Min = "C# Min";
    public string D_Min = "D Min";
    public string Dsharp_Min = "D# Min";
    public string E_Min = "E Min";
    public string F_Min = "F Min";
    public string Fsharp_Min = "F# Min";
    public string G_Min = "G Min";
    public string Gsharp_Min = "G# Min";   

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll(noteName);
        }
    }

    void Update() {

    }

    void PopulateRoll(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }  

    public void ChangeKey_Button_First(string noteName) {
        if (key_Number == 24) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "INDEX";     
            key_Number = 23;       
        }
    }

    public void ChangeKey_Button(string noteName) {
        if (key_Number == 23) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "Ab Maj";
            PopulateRoll_A_flat_maj(noteName);
            key_Number = 0;
        }
        else if (key_Number == 0) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "A Maj";
            PopulateRoll_A_maj(noteName);
            key_Number = 1;
        }     
        else if (key_Number == 1) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "Bb Maj";
            PopulateRoll_B_flat_maj(noteName);
            key_Number = 2;
        }    
        else if (key_Number == 2) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "B Maj";
            PopulateRoll_B_maj(noteName);
            key_Number = 3;
        }          
        else if (key_Number == 3) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "C Maj";
            PopulateRoll_C_maj(noteName);
            key_Number = 4;
        }       
        else if (key_Number == 4) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "Db Maj";
            PopulateRoll_D_flat_maj(noteName);
            key_Number = 5;
        }       
        else if (key_Number == 5) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "D Maj";
            PopulateRoll_D_maj(noteName);
            key_Number = 6;
        }   
        else if (key_Number == 6) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "Eb Maj";
            PopulateRoll_E_flat_maj(noteName);
            key_Number = 7;
        }      
        else if (key_Number == 7) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "E Maj";
            PopulateRoll_E_maj(noteName);
            key_Number = 8;
        } 
        else if (key_Number == 8) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "F Maj";
            PopulateRoll_F_maj(noteName);
            key_Number = 9;
        } 
        else if (key_Number == 9) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "F# Maj";
            PopulateRoll_F_sharp_maj(noteName);
            key_Number = 10;
        }          
        else if (key_Number == 10) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "G Maj";
            PopulateRoll_G_maj(noteName);
            key_Number = 11;
        }  
        /////
        else if (key_Number == 11) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "A Min";
            PopulateRoll_A_min(noteName);
            key_Number = 12;
        }
        else if (key_Number == 12) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "Bb Min";
            PopulateRoll_Bb_min(noteName);
            key_Number = 13;
        }     
        else if (key_Number == 13) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "B Min";
            PopulateRoll_B_min(noteName);
            key_Number = 14;
        }    
        else if (key_Number == 14) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "C Min";
            PopulateRoll_C_min(noteName);
            key_Number = 15;
        }          
        else if (key_Number == 15) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "C# Min";
            PopulateRoll_C_sharp_min(noteName);
            key_Number = 16;
        }       
        else if (key_Number == 16) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "D Min";
            PopulateRoll_D_min(noteName);
            key_Number = 17;
        }       
        else if (key_Number == 17) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "D# Min";
            PopulateRoll_D_sharp_min(noteName);
            key_Number = 18;
        }   
        else if (key_Number == 18) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "E Min";
            PopulateRoll_E_min(noteName);
            key_Number = 19;
        }      
        else if (key_Number == 19) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "F Min";
            PopulateRoll_F_min(noteName);
            key_Number = 20;
        } 
        else if (key_Number == 20) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "F# Min";
            PopulateRoll_F_sharp_min(noteName);
            key_Number = 21;
        } 
        else if (key_Number == 21) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "G Min";
            PopulateRoll_G_min(noteName);
            key_Number = 22;
        }      
        else if (key_Number == 22) {
            textmeshPro = GameObject.Find("KeyNoteText").GetComponent<TextMeshProUGUI>();
            textmeshPro.text = "G# Min";
            PopulateRoll_G_sharp_min(noteName);
            key_Number = 23;
        }                          
    }    

    public void PopulateRollAgain(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }        
        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Again(noteName);
        }
    }                       
    void PopulateRoll_Again(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }
        }
    }


    void PopulateRoll_A_flat_maj(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }        
        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Abmaj(noteName);
        }
    }                       
    void PopulateRoll_Abmaj(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }

    void PopulateRoll_A_maj(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Amaj(noteName);
        }
    }                       
    void PopulateRoll_Amaj(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }    

    void PopulateRoll_B_flat_maj(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Bbmaj(noteName);
        }
    }                       
    void PopulateRoll_Bbmaj(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.black; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }      

    void PopulateRoll_B_maj(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Bmaj(noteName);
        }
    }                       
    void PopulateRoll_Bmaj(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }       

    void PopulateRoll_C_maj(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Cmaj(noteName);
        }
    }                       
    void PopulateRoll_Cmaj(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.black; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }  

    void PopulateRoll_D_flat_maj(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Dbmaj(noteName);
        }
    }                       
    void PopulateRoll_Dbmaj(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }      

    void PopulateRoll_D_maj(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Dmaj(noteName);
        }
    }                       
    void PopulateRoll_Dmaj(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }     

    void PopulateRoll_E_flat_maj(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Ebmaj(noteName);
        }
    }                       
    void PopulateRoll_Ebmaj(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }   

    void PopulateRoll_E_maj(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Emaj(noteName);
        }
    }                       
    void PopulateRoll_Emaj(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }   

    void PopulateRoll_F_maj(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Fmaj(noteName);
        }
    }                       
    void PopulateRoll_Fmaj(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.black; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }  

    void PopulateRoll_F_sharp_maj(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Fsharpmaj(noteName);
        }
    }                       
    void PopulateRoll_Fsharpmaj(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }  

    void PopulateRoll_G_maj(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Gmaj(noteName);
        }
    }                       
    void PopulateRoll_Gmaj(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.black; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }   

    ////////

    void PopulateRoll_A_min(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Amin(noteName);
        }
    }                       
    void PopulateRoll_Amin(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.black; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }     

    void PopulateRoll_Bb_min(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Bbmin(noteName);
        }
    }                       
    void PopulateRoll_Bbmin(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }   

    void PopulateRoll_B_min(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Bmin(noteName);
        }
    }                       
    void PopulateRoll_Bmin(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }     

    void PopulateRoll_C_min(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Cmin(noteName);
        }
    }                       
    void PopulateRoll_Cmin(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.black; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }   

    void PopulateRoll_C_sharp_min(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Csharpmin(noteName);
        }
    }                       
    void PopulateRoll_Csharpmin(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }        

    void PopulateRoll_D_min(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Dmin(noteName);
        }
    }                       
    void PopulateRoll_Dmin(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.black; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }   

    void PopulateRoll_D_sharp_min(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Dsharpmin(noteName);
        }
    }                       
    void PopulateRoll_Dsharpmin(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }       

    void PopulateRoll_E_min(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Emin(noteName);
        }
    }                       
    void PopulateRoll_Emin(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.black; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }      

    void PopulateRoll_F_min(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Fmin(noteName);
        }
    }                       
    void PopulateRoll_Fmin(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }    

    void PopulateRoll_F_sharp_min(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Fsharpmin(noteName);
        }
    }                       
    void PopulateRoll_Fsharpmin(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }      

    void PopulateRoll_G_min(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Gmin(noteName);
        }
    }                       
    void PopulateRoll_Gmin(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.green;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.black; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.black;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.white;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.black; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }     

    void PopulateRoll_G_sharp_min(string noteName) {
        for (int i = 0; i < 84; i++) {
            synthNote_temp = GameObject.Find("SynthNote "+i);
            Destroy(synthNote_temp);
            totalNotes--;
        }

        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll_Gsharpmin(noteName);
        }
    }                       
    void PopulateRoll_Gsharpmin(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString(); 
            }  
            if (i == 1) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 2) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 3) {
                newObj.GetComponent<RawImage>().color = Color.white;  
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 4) {
                newObj.GetComponent<RawImage>().color = Color.green; 
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 5) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 6) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();   
            }    
            if (i == 7) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();   
            }  
            if (i == 8) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }     
            if (i == 9) {
                newObj.GetComponent<RawImage>().color = Color.green;
                newObj.name = noteName+ totalNotes.ToString();    
            }   
            if (i == 10) {
                newObj.GetComponent<RawImage>().color = Color.white; 
                newObj.name = noteName+ totalNotes.ToString();  
            }    
            if (i == 11) {
                newObj.GetComponent<RawImage>().color = Color.green; //C#
                newObj.name = noteName+ totalNotes.ToString();    
            }                                                                                                                                                                                                   
        }
    }                                       
}
