using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BloomCheckToggle : MonoBehaviour
{

    
    






   



    public void ToggleBloom(bool newValue)
    {
        
        if (newValue == true)
        {


            
            PlayerPrefs.SetInt("Bloom", 1);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BloomPro>().enabled = true;

        }


        else if  (newValue == false)
        {



            
            PlayerPrefs.SetInt("Bloom", 0);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BloomPro>().enabled = false;
        }
    }



}
