using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableButtonDelayStart : MonoBehaviour {

    public Button Button_reference;
    private int pederasi;
	// Use this for initialization
	void Start () {
        Button_reference.interactable = false;
        StartCoroutine(DelayStart());
       
    }
	
	private IEnumerator DelayStart()
    {
        
        yield return new WaitForSeconds(1.5f);
        Button_reference.interactable =  true;
    }
}
