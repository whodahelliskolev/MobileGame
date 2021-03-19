using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CurrentLevelText : MonoBehaviour {
    private Text CurrentLevel;
    private int CurrentLevelIndex;
	// Use this for initialization
	void Start () {
        CurrentLevel = GameObject.Find("LevelIntText").GetComponent<Text>();
        CurrentLevelIndex =  SceneManager.GetActiveScene().buildIndex  -3 ;
        CurrentLevel.text = ("Level" + " " +  CurrentLevelIndex.ToString());

    }
	
	
}
