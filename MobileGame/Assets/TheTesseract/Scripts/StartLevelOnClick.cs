using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class StartLevelOnClick : MonoBehaviour {

    private GameObject PuzzlePiece;
    private GameObject StartText;


	public void StartLevel()
    {

        PuzzlePiece = GameObject.FindGameObjectWithTag("PuzzlePiece");
        StartText = GameObject.FindGameObjectWithTag("StartText");

        PuzzlePiece.GetComponent<Rigidbody>().useGravity = true;
        StartText.GetComponent<Text>().enabled = false;
        
    }

  
}
