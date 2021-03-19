using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOne : MonoBehaviour {

    public int SwitchOneState;
    public bool ChangeMaterial;
    public Renderer rend;
    public Material MaterialOn;
    public Material MaterialOff;
    public AudioSource soundclipbutton;




	// Use this for initialization
	void Start () {
        SwitchOneState = 3;
        ChangeMaterial = false;
        rend = GetComponent<Renderer>();
        
	}
	
	



    private void OnTriggerEnter(Collider other)


    {
        if (other.CompareTag("Player" ))
            
        {
            soundclipbutton.Play();

            if (ChangeMaterial == false)
            {


                SwitchOneState = 1;
                ChangeMaterial = true;
                rend.sharedMaterial = MaterialOn;



            }
            else if (ChangeMaterial == true)

            {

                SwitchOneState = 0;
                ChangeMaterial = false;
                rend.sharedMaterial = MaterialOff;
            }
        }
    }

}


