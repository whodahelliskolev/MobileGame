using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideTips : MonoBehaviour {
   
    public GameObject CanvasRef;
    

    

    public void ShowHideTipsSystem()
    {

        CanvasRef.SetActive(!CanvasRef.activeSelf);
       

    }
	
	
}
