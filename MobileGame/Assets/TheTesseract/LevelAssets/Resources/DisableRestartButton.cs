using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableRestartButton : MonoBehaviour
{


    void Start()
    {
        if (SceneManager.GetActiveScene().name == ("OrbScene"))
        {
            gameObject.SetActive(false) ;
        }

    }
}
	
