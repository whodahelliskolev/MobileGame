using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TipsDataBase : MonoBehaviour {

    public string[] tipsArray;
    private Text tipsTextReference;
    public  int arrayIndex;

	// Use this for initialization
	void Start () {

        arrayIndex = 0;//Reset the index.
        arrayIndex = Mathf.Clamp(arrayIndex, 0, tipsArray.Length);//Clamps the max Index to be equal to the array length.
        tipsTextReference = GameObject.Find("TipsPanel").GetComponentInChildren<Text>();//Get the TextReference.
        InitializeTips();
        tipsTextReference.text = tipsArray[0];//Set the first tip as default.
        
    }
	

    public void SwitchTips()//This function is called from SwitchTipsScript.
    {
        tipsTextReference.text = tipsArray[arrayIndex];
    }


    public void InitializeTips()// Fill the array with Tips.
    {
        tipsArray[0] = "TIP #1"                       + Environment.NewLine //Used to define a new paragraph.
                               + "PLACE THE CUBE "    + Environment.NewLine
                               + "ON THE PLATFORM BY" + Environment.NewLine
                               + "HOLDING THE PICKUP BUTTON";

        tipsArray[1] = "TIP #2"                    + Environment.NewLine 
                               + "DON'T FALL FROM" + Environment.NewLine
                               + "THE PLATFORM OR" + Environment.NewLine
                               + "THE LEVEL WILL FAIL";
        tipsArray [2] = "TIP #3"                     + Environment.NewLine 
                               + "THE WATCHERS "     + Environment.NewLine
                               + "CAN BUMP INTO YOU" + Environment.NewLine
                               + "AND STILL SENSE YOU";
        tipsArray [3] = "TIP #4"                      + Environment.NewLine 
                               + "MOVE WHILE ON THE " + Environment.NewLine
                               + "FLOATING PLATFORM"  + Environment.NewLine
                               + "TO PREVENT FALLING";
        tipsArray [4] = "TIP #5"                            + Environment.NewLine 
                               + "THE LEVEL WILL FAIL  " + Environment.NewLine
                               + "IF YOUR HEALTH RUNS OUT "    + Environment.NewLine
                               + " COMPLETELY ";
        tipsArray[5] = "TIP #6" + Environment.NewLine
                               + "THERE ARE MULTIPLE " + Environment.NewLine
                               + "WAYS TO RESTORE" + Environment.NewLine
                               + "YOUR HEALTH";
        tipsArray[6] = "TIP #7" + Environment.NewLine
                               + "LOOK OUT FOR " + Environment.NewLine
                               + "SECRETS THAT ARE" + Environment.NewLine
                               + "READY TO BE FOUND ";
        tipsArray[7] = "TIP #8" + Environment.NewLine
                               + "SOME WATCHERS ARE FASTER  " + Environment.NewLine
                               + "THAN OTHERS";
        tipsArray[8] = "TIP #9" + Environment.NewLine
                               + "THE TESSERACT WILL OPEN UP " + Environment.NewLine
                               + "TO INDICATE THAT YOU" + Environment.NewLine
                               + "CAN PICK IT UP ";
        tipsArray[9] = "TIP #10" + Environment.NewLine
                               + "THERE ARE OTHER DANGERS " + Environment.NewLine
                               + "BESIDES THE WATCHERS" + Environment.NewLine
                               + "BE CAREFUL! ";
       
    }




	
}
