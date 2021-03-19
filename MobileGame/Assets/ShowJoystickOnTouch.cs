using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class ShowJoystickOnTouch : MonoBehaviour {

    public GameObject MobileJoystick;
    public GameObject JoystickImage;

    private Image MobileJoystickImage;
    private Image JoystickImageImage;

    private Vector3 joystickPosition;
    private bool isHolding;


    private Transform joystick; //The prefab of the GUITexture
    private Vector3 newPos;//Position to be set at runtime
    private Transform joyGenerated;// The joystick which is going to be generated at runtime

    public 

    // Use this for initialization
    void Start () {

        MobileJoystickImage = MobileJoystick.GetComponent<Image>();
        JoystickImageImage = JoystickImage.GetComponent<Image>();

        MobileJoystickImage.enabled = false;
        JoystickImageImage.enabled = false;

    }
/*
    private void Update()
    {
        
        if (Input.touchCount==1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase==TouchPhase.Began)
                {
                   //We want to create only one instance of the Joystick so generate it only if it is not available in the scene
                    if(joyGenerated==null)
                    {
                       //Position to locate the GUITexture based on Touch Position
                        newPos=Camera.main.ScreenToViewportPoint(touch.position);
 
                       //This code checks that the Joystick would not get generated at the top position where buttons are available.
                       if(newPos.y>0.8)
                            return;
                        joyGenerated= Instantiate(joystick, newPos, Quaternion.identity)as Transform;
 
                        //The following code does exactly what Joystick script does at Start(), the only difference is that we do all the calculations first before adding the script so that the script won't change the positions by itself.
 
                        Rect defaultRect = joyGenerated.GetComponent<GUITexture>().pixelInset;
                        defaultRect.x += joyGenerated.position.x* Screen.width;// + gui.pixelInset.x; // -  Screen.width * 0.5;
                        defaultRect.y += joyGenerated.position.y* Screen.height;// - Screen.height * 0.5;
                        joyGenerated.position=Vector3.zero;
                        joyGenerated.GetComponent<GUITexture>().pixelInset=defaultRect;
                        joyGenerated.gameObject.AddComponent<Joystick>();//Adding the Joystick script at runtime
 
                    }//end of joyGenerated
                }//end of Began
        }//end of touchCount
    }

    /*
    private void Update()
    {

        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            MobileJoystickImage.enabled = true;
            JoystickImageImage.enabled = true;

            

            

            if (Input.touchCount > 0)
            {

                if (joystickPosition == Vector3.zero)
                {
                    var screenPos = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
                    MobileJoystick.GetComponent<Joystick>().UpdatePosition();
                    joystickPosition = new Vector3((screenPos.x * Screen.width), (screenPos.y * Screen.height), 0);
                }
                

            }
            else
            {
                if (joystickPosition == Vector3.zero)
                {
                    var screenPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                    MobileJoystick.GetComponent<Joystick>().UpdatePosition();
                    joystickPosition = new Vector3((screenPos.x * Screen.width), (screenPos.y * Screen.height), 0);
                }
                    
            }

            Debug.Log(joystickPosition);

            MobileJoystick.transform.position = joystickPosition;
            JoystickImage.transform.position = joystickPosition;

        }

        else
        {

            MobileJoystickImage.enabled = false;
            JoystickImageImage.enabled = false;
            joystickPosition = Vector3.zero;

        }

    }
    

    // Update is called once per frame
    void LateUpdate() {

        if (Input.touchCount > 0 || Input.GetMouseButton(0) )
        {

            //MobileJoystick.transform.position = joystickPosition;
            //JoystickImage.transform.position = joystickPosition;

        }
		
	}

    */
}
