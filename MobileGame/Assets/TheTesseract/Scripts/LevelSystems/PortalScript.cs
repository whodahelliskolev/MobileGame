using System.Collections;
using UnityEngine;

public class PortalScript : MonoBehaviour {

    [Header("Set portal parameters")]
    public GameObject Enter;
    public GameObject Exit;
    [Space(10)]
    public GameObject EnterLocation;
    public GameObject ExitLocation;
    [Space(10)]
    public GameObject EnterlocationCube;
    public GameObject ExitlocationCube;
    
    
    private Collider colGameObj;
    private GameObject player_reference;

    [Header("Get the Player Reference")]

    public PlayerPortalScript PlayerPortalScript_Reference;

   
    private void Start()
    {
        player_reference = GameObject.FindGameObjectWithTag("Player");
        
    }




    private void OnTriggerEnter(Collider other)
    {
        colGameObj = other;
        if (other.CompareTag ("Player" ))
        {


            other.transform.position = ExitLocation.transform.position; // transforms the player to this point when the player collides with the portal.
            StartCoroutine(PortalEffects());
            PlayerPortalScript_Reference.PlayerPortalEffect();
            PlayerPortalScript_Reference.PortalSound();
        }
        if ( other.CompareTag ("PuzzlePiece"))
        {
            
           other.transform.position = ExitlocationCube.transform.position; // another point to transfer to because the cube needs to be infront of the player.
            PlayerPortalScript_Reference.PortalSound();
        }


     


    }

   
    private IEnumerator PortalEffects()
    {


        player_reference.GetComponent<CharacterMove>().enabled = false;
        player_reference.GetComponent<CharacterMove>().CharAnimator.SetFloat("Blend", 0);
        player_reference.transform.rotation = ExitLocation.transform.localRotation;
        yield return new WaitForSeconds(1);
        
        player_reference.GetComponent<CharacterMove>().enabled = true;
    }


}
