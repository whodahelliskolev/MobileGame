using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformScript : MonoBehaviour {

    [Range(0.1f,2f)]
    public float fallDelay;

    private Rigidbody self;

    private void Start()
    {
        self = gameObject.GetComponent<Rigidbody>();
    }

    public IEnumerator WaitBeforePlatformFall()
    {
        yield return new WaitForSeconds(fallDelay);
        self.useGravity = true;
        self.isKinematic = false;
        yield break;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            StartCoroutine(WaitBeforePlatformFall());
        }
    }
}
