using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloomButtonCheck : MonoBehaviour {

    public void Start()
    {


        if (PlayerPrefs.GetInt("Bloom") == 1)
        {
            gameObject.GetComponent<Toggle>().isOn = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BloomPro>().enabled = true;

        }

        else if (PlayerPrefs.GetInt("Bloom") == 0)
        {
            gameObject.GetComponent<Toggle>().isOn = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BloomPro>().enabled = false;
        }
    }
}
