using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTwo : MonoBehaviour
{

    public int SwitchTwoState;
    public bool ChangeMaterial;
    public Renderer rend;
    public Material MaterialOn;
    public Material MaterialOff;
    public AudioSource soundclipbutton;
    


    // Use this for initialization
    void Start()
    {
        SwitchTwoState = 3;
        ChangeMaterial = false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

 



    private void OnTriggerEnter(Collider other)


    {
        if (other.tag == "Player")

        {

            soundclipbutton.Play();
            if (ChangeMaterial == false)
            {


                SwitchTwoState = 1;
                ChangeMaterial = true;
                rend.sharedMaterial = MaterialOn;


            }
            else if (ChangeMaterial == true)

            {

                SwitchTwoState = 0;
                ChangeMaterial = false;
                rend.sharedMaterial = MaterialOff;
            }
        }
    }

}
