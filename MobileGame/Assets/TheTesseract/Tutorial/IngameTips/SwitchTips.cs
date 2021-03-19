using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchTips : MonoBehaviour {
    public TipsDataBase TipsDataBaseReference;//Get a reference of that class.
    public int tipsAmount;
	
	public void RightButton()
    {
        
        

        if (TipsDataBaseReference.arrayIndex   >= TipsDataBaseReference.tipsArray.Length)
        {
            //Do nothing because its the end of the Array.
        }

        else if (TipsDataBaseReference.arrayIndex < tipsAmount )// Increment the Index then call the update function.
        {
            TipsDataBaseReference.arrayIndex++;
            TipsDataBaseReference.SwitchTips();
        }
    }

    public void LeftButton()
    {
        
        if (TipsDataBaseReference.arrayIndex < -1)
        {
            //Do nothing because its the end of the Array.
        }
        else if (TipsDataBaseReference.arrayIndex >=1)// Decrement the Index then call the update function.
        {
            TipsDataBaseReference.arrayIndex--;
            TipsDataBaseReference.SwitchTips();
        }

    }
}
