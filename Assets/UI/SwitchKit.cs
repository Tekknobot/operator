using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class SwitchKit : MonoBehaviour
{
    public AudioHelm.Keyzone Kick909;
    public AudioHelm.Keyzone Snare909;
    public AudioHelm.Keyzone CHat909;
    public AudioHelm.Keyzone OHat909;
    public AudioHelm.Keyzone Clap909;
    public AudioHelm.Keyzone Crash909;
    public AudioHelm.Keyzone Ride909;
    public AudioHelm.Keyzone Rim909;

    public AudioHelm.Keyzone Kick808;
    public AudioHelm.Keyzone Snare808;
    public AudioHelm.Keyzone CHat808;
    public AudioHelm.Keyzone OHat808;
    public AudioHelm.Keyzone Clap808;
    public AudioHelm.Keyzone Crash808;
    public AudioHelm.Keyzone Ride808;
    public AudioHelm.Keyzone Rim808;    

    public AudioHelm.Keyzone Kick707;
    public AudioHelm.Keyzone Snare707;
    public AudioHelm.Keyzone CHat707;
    public AudioHelm.Keyzone OHat707;
    public AudioHelm.Keyzone Clap707;
    public AudioHelm.Keyzone Crash707;
    public AudioHelm.Keyzone Ride707;
    public AudioHelm.Keyzone Rim707;  

    public AudioHelm.Keyzone KickDMX;
    public AudioHelm.Keyzone SnareDMX;
    public AudioHelm.Keyzone CHatDMX;
    public AudioHelm.Keyzone OHatDMX;
    public AudioHelm.Keyzone ClapDMX;
    public AudioHelm.Keyzone CrashDMX;
    public AudioHelm.Keyzone RideDMX;
    public AudioHelm.Keyzone RimDMX;   

    public AudioHelm.Keyzone KickMS20;
    public AudioHelm.Keyzone SnareMS20;
    public AudioHelm.Keyzone CHatMS20;
    public AudioHelm.Keyzone OHatMS20;
    public AudioHelm.Keyzone ClapMS20;
    public AudioHelm.Keyzone CrashMS20;
    public AudioHelm.Keyzone RideMS20;
    public AudioHelm.Keyzone RimMS20;        

    public AudioHelm.Keyzone KickRX11;
    public AudioHelm.Keyzone SnareRX11;
    public AudioHelm.Keyzone CHatRX11;
    public AudioHelm.Keyzone OHatRX11;
    public AudioHelm.Keyzone ClapRX11;
    public AudioHelm.Keyzone CrashRX11;
    public AudioHelm.Keyzone RideRX11;
    public AudioHelm.Keyzone RimRX11;   

    public AudioHelm.Keyzone KickR110;
    public AudioHelm.Keyzone SnareR110;
    public AudioHelm.Keyzone CHatR110;
    public AudioHelm.Keyzone OHatR110;
    public AudioHelm.Keyzone ClapR110;
    public AudioHelm.Keyzone CrashR110;
    public AudioHelm.Keyzone RideR110;
    public AudioHelm.Keyzone RimR110;            

    public AudioHelm.Sampler sampler;

    public int kitNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
		if (PlayerPrefs.GetFloat("KitIndex") == 0) { SwitchTo909(); }
		if (PlayerPrefs.GetFloat("KitIndex") == 1) { SwitchTo808(); }   
		if (PlayerPrefs.GetFloat("KitIndex") == 2) { SwitchTo707(); }  
		if (PlayerPrefs.GetFloat("KitIndex") == 3) { SwitchToDMX(); }  
		if (PlayerPrefs.GetFloat("KitIndex") == 4) { SwitchToMS20(); }  
		if (PlayerPrefs.GetFloat("KitIndex") == 5) { SwitchToRX11(); }  
		if (PlayerPrefs.GetFloat("KitIndex") == 6) { SwitchToR110(); }    		
    }

    // Update is called once per frame
    public void SwitchTo909()
    {
        sampler.keyzones[0] = Kick909;   
        sampler.keyzones[1] = Snare909;   
        sampler.keyzones[2] = CHat909;   
        sampler.keyzones[3] = OHat909;   
        sampler.keyzones[4] = Clap909;   
        sampler.keyzones[5] = Crash909;   
        sampler.keyzones[6] = Ride909;   
        sampler.keyzones[7] = Rim909;    
        kitNumber = 0;
        PlayerPrefs.SetFloat("KitIndex", kitNumber);

        if(GameObject.Find("DrumSampler_1")) {
            sampler = GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = Kick909;   
            sampler.keyzones[1] = Snare909;   
            sampler.keyzones[2] = CHat909;   
            sampler.keyzones[3] = OHat909;   
            sampler.keyzones[4] = Clap909;   
            sampler.keyzones[5] = Crash909;   
            sampler.keyzones[6] = Ride909;   
            sampler.keyzones[7] = Rim909;    
            kitNumber = 0;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        }          

        if(GameObject.Find("DrumSampler_2")) {
            sampler = GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = Kick909;   
            sampler.keyzones[1] = Snare909;   
            sampler.keyzones[2] = CHat909;   
            sampler.keyzones[3] = OHat909;   
            sampler.keyzones[4] = Clap909;   
            sampler.keyzones[5] = Crash909;   
            sampler.keyzones[6] = Ride909;   
            sampler.keyzones[7] = Rim909;    
            kitNumber = 0;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_3")) {
            sampler = GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = Kick909;   
            sampler.keyzones[1] = Snare909;   
            sampler.keyzones[2] = CHat909;   
            sampler.keyzones[3] = OHat909;   
            sampler.keyzones[4] = Clap909;   
            sampler.keyzones[5] = Crash909;   
            sampler.keyzones[6] = Ride909;   
            sampler.keyzones[7] = Rim909;    
            kitNumber = 0;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_4")) {
            sampler = GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = Kick909;   
            sampler.keyzones[1] = Snare909;   
            sampler.keyzones[2] = CHat909;   
            sampler.keyzones[3] = OHat909;   
            sampler.keyzones[4] = Clap909;   
            sampler.keyzones[5] = Crash909;   
            sampler.keyzones[6] = Ride909;   
            sampler.keyzones[7] = Rim909;    
            kitNumber = 0;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        }         
    }  

    public void SwitchTo808() 
    {
        sampler.keyzones[0] = Kick808;   
        sampler.keyzones[1] = Snare808;   
        sampler.keyzones[2] = CHat808;   
        sampler.keyzones[3] = OHat808;   
        sampler.keyzones[4] = Clap808;   
        sampler.keyzones[5] = Crash808;   
        sampler.keyzones[6] = Ride808;   
        sampler.keyzones[7] = Rim808;   
        kitNumber = 1; 
        PlayerPrefs.SetFloat("KitIndex", kitNumber); 

        if(GameObject.Find("DrumSampler_1")) {
            sampler = GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = Kick808;   
            sampler.keyzones[1] = Snare808;   
            sampler.keyzones[2] = CHat808;   
            sampler.keyzones[3] = OHat808;   
            sampler.keyzones[4] = Clap808;   
            sampler.keyzones[5] = Crash808;   
            sampler.keyzones[6] = Ride808;   
            sampler.keyzones[7] = Rim808;      
            kitNumber = 1;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        }          

        if(GameObject.Find("DrumSampler_2")) {
            sampler = GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = Kick808;   
            sampler.keyzones[1] = Snare808;   
            sampler.keyzones[2] = CHat808;   
            sampler.keyzones[3] = OHat808;   
            sampler.keyzones[4] = Clap808;   
            sampler.keyzones[5] = Crash808;   
            sampler.keyzones[6] = Ride808;   
            sampler.keyzones[7] = Rim808;     
            kitNumber = 1;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_3")) {
            sampler = GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = Kick808;   
            sampler.keyzones[1] = Snare808;   
            sampler.keyzones[2] = CHat808;   
            sampler.keyzones[3] = OHat808;   
            sampler.keyzones[4] = Clap808;   
            sampler.keyzones[5] = Crash808;   
            sampler.keyzones[6] = Ride808;   
            sampler.keyzones[7] = Rim808;    
            kitNumber = 1;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_4")) {
            sampler = GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = Kick808;   
            sampler.keyzones[1] = Snare808;   
            sampler.keyzones[2] = CHat808;   
            sampler.keyzones[3] = OHat808;   
            sampler.keyzones[4] = Clap808;   
            sampler.keyzones[5] = Crash808;   
            sampler.keyzones[6] = Ride808;   
            sampler.keyzones[7] = Rim808;     
            kitNumber = 1;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);   
        }     
    }      

    public void SwitchTo707()
    {
        sampler.keyzones[0] = Kick707;   
        sampler.keyzones[1] = Snare707;   
        sampler.keyzones[2] = CHat707;   
        sampler.keyzones[3] = OHat707;   
        sampler.keyzones[4] = Clap707;   
        sampler.keyzones[5] = Crash707;   
        sampler.keyzones[6] = Ride707;   
        sampler.keyzones[7] = Rim707;     
        kitNumber = 2; 
        PlayerPrefs.SetFloat("KitIndex", kitNumber);

        if(GameObject.Find("DrumSampler_1")) {
            sampler = GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = Kick707;   
            sampler.keyzones[1] = Snare707;   
            sampler.keyzones[2] = CHat707;   
            sampler.keyzones[3] = OHat707;   
            sampler.keyzones[4] = Clap707;   
            sampler.keyzones[5] = Crash707;   
            sampler.keyzones[6] = Ride707;   
            sampler.keyzones[7] = Rim707;       
            kitNumber = 2;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        }          

        if(GameObject.Find("DrumSampler_2")) {
            sampler = GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = Kick707;   
            sampler.keyzones[1] = Snare707;   
            sampler.keyzones[2] = CHat707;   
            sampler.keyzones[3] = OHat707;   
            sampler.keyzones[4] = Clap707;   
            sampler.keyzones[5] = Crash707;   
            sampler.keyzones[6] = Ride707;   
            sampler.keyzones[7] = Rim707;    
            kitNumber = 2;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_3")) {
            sampler = GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = Kick707;   
            sampler.keyzones[1] = Snare707;   
            sampler.keyzones[2] = CHat707;   
            sampler.keyzones[3] = OHat707;   
            sampler.keyzones[4] = Clap707;   
            sampler.keyzones[5] = Crash707;   
            sampler.keyzones[6] = Ride707;   
            sampler.keyzones[7] = Rim707;     
            kitNumber = 2;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_4")) {
            sampler = GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = Kick707;   
            sampler.keyzones[1] = Snare707;   
            sampler.keyzones[2] = CHat707;   
            sampler.keyzones[3] = OHat707;   
            sampler.keyzones[4] = Clap707;   
            sampler.keyzones[5] = Crash707;   
            sampler.keyzones[6] = Ride707;   
            sampler.keyzones[7] = Rim707;      
            kitNumber = 2;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        }        
    } 

    public void SwitchToDMX()
    {
        sampler.keyzones[0] = KickDMX;   
        sampler.keyzones[1] = SnareDMX;   
        sampler.keyzones[2] = CHatDMX;   
        sampler.keyzones[3] = OHatDMX;   
        sampler.keyzones[4] = ClapDMX;   
        sampler.keyzones[5] = CrashDMX;   
        sampler.keyzones[6] = RideDMX;   
        sampler.keyzones[7] = RimDMX;    
        kitNumber = 3;    
        PlayerPrefs.SetFloat("KitIndex", kitNumber);

        if(GameObject.Find("DrumSampler_1")) {
            sampler = GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickDMX;   
            sampler.keyzones[1] = SnareDMX;   
            sampler.keyzones[2] = CHatDMX;   
            sampler.keyzones[3] = OHatDMX;   
            sampler.keyzones[4] = ClapDMX;   
            sampler.keyzones[5] = CrashDMX;   
            sampler.keyzones[6] = RideDMX;   
            sampler.keyzones[7] = RimDMX;        
            kitNumber = 3;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        }          

        if(GameObject.Find("DrumSampler_2")) {
            sampler = GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickDMX;   
            sampler.keyzones[1] = SnareDMX;   
            sampler.keyzones[2] = CHatDMX;   
            sampler.keyzones[3] = OHatDMX;   
            sampler.keyzones[4] = ClapDMX;   
            sampler.keyzones[5] = CrashDMX;   
            sampler.keyzones[6] = RideDMX;   
            sampler.keyzones[7] = RimDMX;  
            kitNumber = 3;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_3")) {
            sampler = GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickDMX;   
            sampler.keyzones[1] = SnareDMX;   
            sampler.keyzones[2] = CHatDMX;   
            sampler.keyzones[3] = OHatDMX;   
            sampler.keyzones[4] = ClapDMX;   
            sampler.keyzones[5] = CrashDMX;   
            sampler.keyzones[6] = RideDMX;   
            sampler.keyzones[7] = RimDMX;    
            kitNumber = 3;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_4")) {
            sampler = GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickDMX;   
            sampler.keyzones[1] = SnareDMX;   
            sampler.keyzones[2] = CHatDMX;   
            sampler.keyzones[3] = OHatDMX;   
            sampler.keyzones[4] = ClapDMX;   
            sampler.keyzones[5] = CrashDMX;   
            sampler.keyzones[6] = RideDMX;   
            sampler.keyzones[7] = RimDMX;     
            kitNumber = 3;
            PlayerPrefs.SetFloat("KitIndex", kitNumber); 
        }        
    }  

    public void SwitchToMS20()
    {
        sampler.keyzones[0] = KickMS20;   
        sampler.keyzones[1] = SnareMS20;   
        sampler.keyzones[2] = CHatMS20;   
        sampler.keyzones[3] = OHatMS20;   
        sampler.keyzones[4] = ClapMS20;   
        sampler.keyzones[5] = CrashMS20;   
        sampler.keyzones[6] = RideMS20;   
        sampler.keyzones[7] = RimMS20;     
        kitNumber = 4;  
        PlayerPrefs.SetFloat("KitIndex", kitNumber);  

        if(GameObject.Find("DrumSampler_1")) {
            sampler = GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickMS20;   
            sampler.keyzones[1] = SnareMS20;   
            sampler.keyzones[2] = CHatMS20;   
            sampler.keyzones[3] = OHatMS20;   
            sampler.keyzones[4] = ClapMS20;   
            sampler.keyzones[5] = CrashMS20;   
            sampler.keyzones[6] = RideMS20;   
            sampler.keyzones[7] = RimMS20;        
            kitNumber = 4;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        }          

        if(GameObject.Find("DrumSampler_2")) {
            sampler = GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickMS20;   
            sampler.keyzones[1] = SnareMS20;   
            sampler.keyzones[2] = CHatMS20;   
            sampler.keyzones[3] = OHatMS20;   
            sampler.keyzones[4] = ClapMS20;   
            sampler.keyzones[5] = CrashMS20;   
            sampler.keyzones[6] = RideMS20;   
            sampler.keyzones[7] = RimMS20;   
            kitNumber = 4;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_3")) {
            sampler = GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickMS20;   
            sampler.keyzones[1] = SnareMS20;   
            sampler.keyzones[2] = CHatMS20;   
            sampler.keyzones[3] = OHatMS20;   
            sampler.keyzones[4] = ClapMS20;   
            sampler.keyzones[5] = CrashMS20;   
            sampler.keyzones[6] = RideMS20;   
            sampler.keyzones[7] = RimMS20;    
            kitNumber = 4;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_4")) {
            sampler = GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickMS20;   
            sampler.keyzones[1] = SnareMS20;   
            sampler.keyzones[2] = CHatMS20;   
            sampler.keyzones[3] = OHatMS20;   
            sampler.keyzones[4] = ClapMS20;   
            sampler.keyzones[5] = CrashMS20;   
            sampler.keyzones[6] = RideMS20;   
            sampler.keyzones[7] = RimMS20;     
            kitNumber = 4;
            PlayerPrefs.SetFloat("KitIndex", kitNumber); 
        }             
    }  

    public void SwitchToRX11()
    {
        sampler.keyzones[0] = KickRX11;   
        sampler.keyzones[1] = SnareRX11;   
        sampler.keyzones[2] = CHatRX11;   
        sampler.keyzones[3] = OHatRX11;   
        sampler.keyzones[4] = ClapRX11;   
        sampler.keyzones[5] = CrashRX11;   
        sampler.keyzones[6] = RideRX11;   
        sampler.keyzones[7] = RimRX11;  
        kitNumber = 5;   
        PlayerPrefs.SetFloat("KitIndex", kitNumber);

        if(GameObject.Find("DrumSampler_1")) {
            sampler = GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickRX11;   
            sampler.keyzones[1] = SnareRX11;   
            sampler.keyzones[2] = CHatRX11;   
            sampler.keyzones[3] = OHatRX11;   
            sampler.keyzones[4] = ClapRX11;   
            sampler.keyzones[5] = CrashRX11;   
            sampler.keyzones[6] = RideRX11;   
            sampler.keyzones[7] = RimRX11;        
            kitNumber = 5;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        }          

        if(GameObject.Find("DrumSampler_2")) {
            sampler = GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickRX11;   
            sampler.keyzones[1] = SnareRX11;   
            sampler.keyzones[2] = CHatRX11;   
            sampler.keyzones[3] = OHatRX11;   
            sampler.keyzones[4] = ClapRX11;   
            sampler.keyzones[5] = CrashRX11;   
            sampler.keyzones[6] = RideRX11;   
            sampler.keyzones[7] = RimRX11;   
            kitNumber = 5;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_3")) {
            sampler = GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickRX11;   
            sampler.keyzones[1] = SnareRX11;   
            sampler.keyzones[2] = CHatRX11;   
            sampler.keyzones[3] = OHatRX11;   
            sampler.keyzones[4] = ClapRX11;   
            sampler.keyzones[5] = CrashRX11;   
            sampler.keyzones[6] = RideRX11;   
            sampler.keyzones[7] = RimRX11;    
            kitNumber = 5;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_4")) {
            sampler = GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickRX11;   
            sampler.keyzones[1] = SnareRX11;   
            sampler.keyzones[2] = CHatRX11;   
            sampler.keyzones[3] = OHatRX11;   
            sampler.keyzones[4] = ClapRX11;   
            sampler.keyzones[5] = CrashRX11;   
            sampler.keyzones[6] = RideRX11;   
            sampler.keyzones[7] = RimRX11;   
            kitNumber = 5;
            PlayerPrefs.SetFloat("KitIndex", kitNumber); 
        }        
    }   

    public void SwitchToR110()
    {
        sampler.keyzones[0] = KickR110;   
        sampler.keyzones[1] = SnareR110;   
        sampler.keyzones[2] = CHatR110;   
        sampler.keyzones[3] = OHatR110;   
        sampler.keyzones[4] = ClapR110;   
        sampler.keyzones[5] = CrashR110;   
        sampler.keyzones[6] = RideR110;   
        sampler.keyzones[7] = RimR110;   
        kitNumber = 6;       
        PlayerPrefs.SetFloat("KitIndex", kitNumber);

        if(GameObject.Find("DrumSampler_1")) {
            sampler = GameObject.Find("DrumSampler_1").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickR110;   
            sampler.keyzones[1] = SnareR110;   
            sampler.keyzones[2] = CHatR110;   
            sampler.keyzones[3] = OHatR110;   
            sampler.keyzones[4] = ClapR110;   
            sampler.keyzones[5] = CrashR110;   
            sampler.keyzones[6] = RideR110;   
            sampler.keyzones[7] = RimR110;        
            kitNumber = 6;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        }          

        if(GameObject.Find("DrumSampler_2")) {
            sampler = GameObject.Find("DrumSampler_2").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickR110;   
            sampler.keyzones[1] = SnareR110;   
            sampler.keyzones[2] = CHatR110;   
            sampler.keyzones[3] = OHatR110;   
            sampler.keyzones[4] = ClapR110;   
            sampler.keyzones[5] = CrashR110;   
            sampler.keyzones[6] = RideR110;   
            sampler.keyzones[7] = RimR110;   
            kitNumber = 6;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_3")) {
            sampler = GameObject.Find("DrumSampler_3").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickR110;   
            sampler.keyzones[1] = SnareR110;   
            sampler.keyzones[2] = CHatR110;   
            sampler.keyzones[3] = OHatR110;   
            sampler.keyzones[4] = ClapR110;   
            sampler.keyzones[5] = CrashR110;   
            sampler.keyzones[6] = RideR110;   
            sampler.keyzones[7] = RimR110;     
            kitNumber = 6;
            PlayerPrefs.SetFloat("KitIndex", kitNumber);
        } 

        if(GameObject.Find("DrumSampler_4")) {
            sampler = GameObject.Find("DrumSampler_4").GetComponent<AudioHelm.Sampler>();
            sampler.keyzones[0] = KickR110;   
            sampler.keyzones[1] = SnareR110;   
            sampler.keyzones[2] = CHatR110;   
            sampler.keyzones[3] = OHatR110;   
            sampler.keyzones[4] = ClapR110;   
            sampler.keyzones[5] = CrashR110;   
            sampler.keyzones[6] = RideR110;   
            sampler.keyzones[7] = RimR110;    
            kitNumber = 6;
            PlayerPrefs.SetFloat("KitIndex", kitNumber); 
        }         
    }                   
}
