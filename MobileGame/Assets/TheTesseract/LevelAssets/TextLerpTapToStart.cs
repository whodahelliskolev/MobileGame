using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextLerpTapToStart : MonoBehaviour {



    //public Text text;


    public Color alphacolor;// = //new Color(0, 0, 0, 1);
    public Color normalcolor; //=// new Color(0, 0, 0, 0);
    private Color lerpedColor;


    private void Start()
    {
        lerpedColor= GameObject.FindGameObjectWithTag("StartText").GetComponent<Text>().color;
    }

    void Update()
    {
        lerpedColor = Color.Lerp(normalcolor, alphacolor, Mathf.PingPong(Time.time, 2));
        GameObject.FindGameObjectWithTag("StartText").GetComponent<Text>().color = lerpedColor;
    }

   
}
