using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlatformPlayer_script : MonoBehaviour {
    private GameObject Player_reference;
   
    private void Start()
    {
        Player_reference = GameObject.FindGameObjectWithTag("Player");
         
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            if (Player_reference.GetComponent<CharacterMove>().hp_value == 0)
            {
                other.transform.parent = null;
                other.transform.localScale = new Vector3(1.5f, 1.6f, 1.5f);
                
            }
            else
            {
                other.transform.parent = transform.parent;
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            
            if (Player_reference.GetComponent<CharacterMove>().hp_value == 0)
            {
                other.transform.parent = null;
                other.transform.localScale = new Vector3(1.5f, 1.6f, 1.5f);

            }
            else
            {
                other.transform.parent = transform.parent;
            }

        }

        if (other.gameObject.CompareTag("PuzzlePiece"))
        {
            other.transform.parent = transform.parent;

        }

        if (other.gameObject.CompareTag("Health_Pickup"))
        {
            other.transform.parent = transform.parent;

        }

        if (other.gameObject.CompareTag("Power_Up"))
        {
            other.transform.parent = transform.parent;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
            other.transform.localScale = new Vector3(1.5f, 1.6f, 1.5f);
        }

        if (other.gameObject.CompareTag("PuzzlePiece"))
        {
            other.transform.parent = null;
            other.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            
        }

        if (other.gameObject.CompareTag("Health_Pickup"))
        {
            other.transform.parent = null;
            other.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        if (other.gameObject.CompareTag("Power_Up"))
        {
            other.transform.parent = null;
            other.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
    }

}

