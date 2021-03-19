using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoldButtonScript : MonoBehaviour
{

    public bool isButtonPressed= false;
    

   

    
    public void onPointerDownRaceButton()
    {

        
        isButtonPressed = true;
    }
    public void onPointerUpRaceButton()
    {
        isButtonPressed = false;
    }
}
