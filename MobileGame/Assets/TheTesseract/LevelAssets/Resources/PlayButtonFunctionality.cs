using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayButtonFunctionality : MonoBehaviour {
    public GameObject PuzzleUI;
    public GameObject MainMenuUI;

	
    public void SwitchToPuzzleUI()
    {

        PuzzleUI.SetActive(!PuzzleUI.activeSelf && MainMenuUI.activeSelf);
        MainMenuUI.SetActive(!MainMenuUI.activeSelf);
    }


}
