using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchThree : MonoBehaviour
{

    public int SwitchThreeState;
    public bool ChangeMaterial;
    public Renderer rend;
    public Material MaterialOn;
    public Material MaterialOff;
    public AudioSource soundclipbutton;
   



    // Use this for initialization
    void Start()
    {
        SwitchThreeState = 3;
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


                SwitchThreeState = 1;
                ChangeMaterial = true;
                rend.sharedMaterial = MaterialOn;


            }
            else if (ChangeMaterial == true)

            {

                SwitchThreeState = 0;
                ChangeMaterial = false;
                rend.sharedMaterial = MaterialOff;
            }
        }
    }

}