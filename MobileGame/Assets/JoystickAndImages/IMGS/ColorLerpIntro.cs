
using UnityEngine;
using UnityEngine.UI;

public class ColorLerpIntro : MonoBehaviour {


    private Color lerpedColor;
    private void Start()
    {
        lerpedColor = GetComponent<Image>().color;
    }

    void Update()
    {
        lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 2));
        GetComponent<Image>().color = lerpedColor;
    }
}
