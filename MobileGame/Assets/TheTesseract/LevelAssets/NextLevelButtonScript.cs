using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NextLevelButtonScript : MonoBehaviour {
    private int SceneIndex;
	public void GoToNextLevel()
    {
     SceneIndex =   SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneIndex + 1);

    }
	
	
}
