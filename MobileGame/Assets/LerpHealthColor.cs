using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class LerpHealthColor : MonoBehaviour {
    public Image HealthBar_reference;
    public Color RedBarColor;
    public Color BlueBarColor;
    public Slider HealthbarValue;
    public Image SpeedBarValue;
    public Image InvisibleBarValue;
    public float RegainHealthBarColorTime = .11f;



    public void LerpHealthBarColor()

    {
        StartCoroutine(ColorLerp());
    }

     private IEnumerator ColorLerp()
    {
        HealthBar_reference.color = RedBarColor;
        yield return new WaitForSeconds(RegainHealthBarColorTime);
        HealthBar_reference.color = BlueBarColor;
    }


}


