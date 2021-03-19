using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGravityOnObject : MonoBehaviour
{


    public GameObject Cube; // Releases the cube from the sky.
    public AudioSource soundClip;
    private bool lockButton;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && lockButton == false)

        {


            lockButton = true;
            soundClip.Play();

            Cube.GetComponent<Rigidbody>().useGravity = true;
            



        }



    }


}