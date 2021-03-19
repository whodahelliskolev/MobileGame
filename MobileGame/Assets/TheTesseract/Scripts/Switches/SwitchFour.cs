using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFour : MonoBehaviour
{

    public int SwitchFourState;
    public bool ChangeMaterial;
    public Renderer rend;
    public Material MaterialOn;
    public Material MaterialOff;


    public AudioSource soundclipbutton;


    // Use this for initialization
    void Start()
    {
        SwitchFourState = 3;
        ChangeMaterial = false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

   



    private void OnTriggerEnter(Collider other)


    {
        if (other.CompareTag ("Player"))

        {
            soundclipbutton.Play();
            if (ChangeMaterial == false)
            {


                SwitchFourState = 1;
                ChangeMaterial = true;
                rend.sharedMaterial = MaterialOn;


            }
            else if (ChangeMaterial == true)

            {

                SwitchFourState = 0;
                ChangeMaterial = false;
                rend.sharedMaterial = MaterialOff;
            }
        }
    }

}
