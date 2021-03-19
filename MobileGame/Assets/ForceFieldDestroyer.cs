using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldDestroyer : MonoBehaviour {
    public GameObject ForceFieldDeactivator;
    public GameObject ForceGate;
    public GameObject ForceGateParticle;
    
    public void OnTriggerExit(Collider other_object)
    {
        {
            if (other_object.gameObject == ForceFieldDeactivator)
            {
               
                ForceGate.GetComponent<Renderer>().enabled = false;
                ForceGate.GetComponent<Collider>().enabled = false;
                if(ForceGateParticle != null)
                {
                    DestroyObject(ForceGateParticle);
                }
               

            }
        }
    }
   
}
