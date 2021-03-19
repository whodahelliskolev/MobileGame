
using UnityEngine;

public class BloomToggle : MonoBehaviour {
    public static bool BloomOnOff;


    public void Start()
    {
        if (PlayerPrefs.GetInt("Bloom")== 0)
        {
            GetComponent<BloomPro>().enabled = false;
        }

        if (PlayerPrefs.GetInt("Bloom") == 1)
        {
            GetComponent<BloomPro>().enabled = true; 
        }
    }

}
