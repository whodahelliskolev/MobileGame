using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartCurrentLevelButton : MonoBehaviour {

	public void restartCurrentLevel()
    {
        Time.timeScale = 1f;
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
}
