using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformPuzzleTypeOne : MonoBehaviour {

    [HideInInspector]
    public GameObject LevelCompleteText;   //Show Menu + Level CompleteText (Must Attach Canvas).


    [HideInInspector]
    public ParticleSystem PuzzleEndEffect; //Plays the ParticleEffect.

    private Vector3 PlatformLocation;      //Location of the platform(useful for snapping the cube in the center of it).     

    [HideInInspector]
    public GameObject CubeToAttach;        //The Cube needed to attatch to the Platform.
    private Rigidbody rigidbodyToFreeze;   //Freeze the cube's Rigidbody so it doesnt move around when pushed.
    private Vector3 Offset;
    private int lReach;                    //Level reached.
    private bool canLerpCube;
    [HideInInspector]
    public bool StopEnemies = false;

    [HideInInspector]
    public bool CubeStatic;
    Animator PuzzleAnimator;
    
   




    void Start ()
         {
        

        PuzzleAnimator = GetComponent<Animator>();
        lReach = PlayerPrefs.GetInt("levelReached"); // 

        PlatformLocation = gameObject.transform.position;  // Sets the PlatformLocation variable.
        Offset = new Vector3(0, 0.5f, 0);  // Sets the Offset Variable used to push the cube up when snapped.
        
        if (PlayerPrefs.GetString(SceneManager.GetActiveScene().name) == "yes")
        {

            //Debug.Log("LevelCompletedAlready");
        } // Check if the level is completed.
           }//Initiate All The Components.

    public  void Increment()
    {
        lReach++;
         PlayerPrefs.SetInt("levelReached", lReach++);
    }//Increment LevelLoop

    private void OnTriggerEnter (Collider other) //Function that checks if there is a collision between the PuzzleCube and the Platform.
    {
                if (other.tag == "PuzzlePiece") //Checks if collision object is the has the tag PuzzlePiece.

                 {
                 StopEnemies = true; //Turn Off Enemies;
                 StartCoroutine(CubeParticlePlayThenStop()); // Plays the Particle.
                 gameObject.GetComponentInParent<AudioSource>().enabled = true;
                 CubeStatic = true;
                 
                 CubeToAttach.GetComponent<Rigidbody>().mass = 99999;
                 canLerpCube = true;
                

            if  (PlayerPrefs.GetString(SceneManager.GetActiveScene().name) != "yes") // Check if the Level is Completed.

                  {

             
                Increment();


                
                PlayerPrefs.SetString(SceneManager.GetActiveScene().name, "yes");
                Debug.Log("LevelCompleted" + PlayerPrefs.GetInt("levelReached"));
                }
          
                    
                     //CubeToAttach.transform.position = PlatformLocation + Offset ; // Attaches the cube to the center of the platform.
                     rigidbodyToFreeze = CubeToAttach.GetComponent<Rigidbody>(); // Gets the cube's rigidbody.

                     rigidbodyToFreeze.isKinematic = true; // Freezes the cube's rigidbody.

                 }




     }

    private void Update()
    {
        if (canLerpCube)
        {

            CubeToAttach.transform.position = Vector3.Lerp(CubeToAttach.transform.position, PlatformLocation + Offset, Time.deltaTime * 2);
           
        }

    }

    IEnumerator CubeParticlePlayThenStop()
    {
        

        PuzzleEndEffect.GetComponent<ParticleSystem>();// Gets the Particle Emitter.
        PuzzleEndEffect.Play();
        yield return new WaitForSeconds(2);
        PuzzleAnimator.SetBool("LevelEnded", true);
        PuzzleEndEffect.Stop();
        yield return new WaitForSeconds(1);
        LevelCompleteText.SetActive(true);


    }//EndLevel Effect

  
}
