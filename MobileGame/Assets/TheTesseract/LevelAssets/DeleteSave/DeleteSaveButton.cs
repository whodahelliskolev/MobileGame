using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DeleteSaveButton : MonoBehaviour {

	public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("PuzzleScene");
    }
}
