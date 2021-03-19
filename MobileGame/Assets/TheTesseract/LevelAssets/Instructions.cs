using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Instructions : MonoBehaviour {

    public Text text;
    public Image image;



    private void Start()
    {
        StartCoroutine("InstructionsFade");
    }

    IEnumerator InstructionsFade()
    {

        yield return new WaitForSeconds(3);

        text.CrossFadeAlpha(0.0f, 0.5f, false);
        image.CrossFadeAlpha(0.0f, 0.5f, false);

        yield return new WaitForSeconds(2);

        gameObject.SetActive(false);
        


        
    }
    
    


}

