using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSwitches : MonoBehaviour {

    public int FirstState;
    public int SecondState;
    public int ThirdState;
    public int FourthState;
    private Vector3 StartingLocation;
    public Vector3 EndingLocation;
    private float LerpTime = 3;
    private float CurrentLerpTime = 0;
    public AudioSource platformlowersound;
    private bool sound_triggered;

    public GameObject Switches;

    private int firststate_ref;
    private int secondstate_ref;
    private int thirdstate_ref;
    private int fourthstate_ref;

	// Use this for initialization
	void Start () {
        StartingLocation = gameObject.transform.position; //Get the object's starting location.
        sound_triggered = false;
        GetSwitches_States();
    }
	

    public void GetSwitches_States()
    {
        FirstState = Switches.GetComponentInChildren<SwitchOne>().SwitchOneState;
        SecondState = Switches.GetComponentInChildren<SwitchTwo>().SwitchTwoState;
        ThirdState = Switches.GetComponentInChildren<SwitchThree>().SwitchThreeState;
        FourthState = Switches.GetComponentInChildren<SwitchFour>().SwitchFourState;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        GetSwitches_States();
    }

    void Update () {

        if (FirstState == 0 && SecondState == 1 && ThirdState == 0 && FourthState == 0) 
        {
            if (sound_triggered == true)
            {

            }
            if (sound_triggered == false)
            {
                sound_triggered = true;
                platformlowersound.Play();
            }
            
            float Perc = CurrentLerpTime / LerpTime;
            CurrentLerpTime += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(StartingLocation, EndingLocation, Perc);
        }

    }
}
