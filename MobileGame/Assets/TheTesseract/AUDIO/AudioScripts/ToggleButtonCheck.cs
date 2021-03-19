using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonCheck : MonoBehaviour {


   

    
    


    public void Start()
    {

        
        if (PlayerPrefs.GetInt("SoundState") == 1)
        {
            gameObject.GetComponent<Toggle>().isOn = true;
           
        }

        else if (PlayerPrefs.GetInt("SoundState") == 0)
        {
            gameObject.GetComponent<Toggle>().isOn = false;
        }
    }
}
