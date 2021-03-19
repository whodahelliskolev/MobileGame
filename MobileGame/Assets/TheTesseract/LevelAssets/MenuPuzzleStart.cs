using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPuzzleStart : MonoBehaviour
{

    public SceneFader sceneFaderRef;



    public ParticleSystem PuzzleEndEffectt; //Plays the ParticleEffect.
    private Vector3 PlatformLocationn;      //Location of the platform(useful for snapping the cube in the center of it).     
    public GameObject CubeToAttachh;        //The Cube needed to attatch to the Platform.
    private Rigidbody rigidbodyToFreezee;   //Freeze the cube's Rigidbody so it doesnt move around when pushed.
    private Vector3 Offsett;
    public bool CubeStatic;
    Animator PuzzleAnimatorr;
    


    void Start()
    {
        PuzzleAnimatorr = GetComponent<Animator>();
        PlatformLocationn = gameObject.transform.position;  // Sets the PlatformLocation variable.
        Offsett = new Vector3(0, 0.5f, 0);  // Sets the Offset Variable used to push the cube up when snapped.
        Time.timeScale = 1f;
    }

  

    
        
   

  






    private void OnTriggerEnter(Collider other) //Function that checks if there is a collision between the PuzzleCube and the Platform.
    {
        if (other.tag == "PuzzlePiece") //Checks if collision object is the has the tag PuzzlePiece.

        {
            
            StartCoroutine(CubeParticlePlayThenStopp()); // Plays the Particle.
            gameObject.GetComponentInParent<AudioSource>().enabled = true;
            PuzzleAnimatorr.SetBool("LevelEnded", true);
            CubeToAttachh.transform.position = PlatformLocationn + Offsett; // Attaches the cube to the center of the platform.
            rigidbodyToFreezee = CubeToAttachh.GetComponent<Rigidbody>(); // Gets the cube's rigidbody.
            rigidbodyToFreezee.isKinematic = true; // Freezes the cube's rigidbody.
            
        }




    }

    IEnumerator CubeParticlePlayThenStopp()
    {
        PuzzleEndEffectt.GetComponent<ParticleSystem>();// Gets the Particle Emitter.
        PuzzleEndEffectt.Play();
        yield return new WaitForSeconds(1f);
        PuzzleEndEffectt.Stop();
        yield return new WaitForSeconds(1);

        if (GetComponent<PlayerDataProgress>().LastLevelReachedPrefs < 4)
        {
            sceneFaderRef.StartFadeIn();
            
            SceneManager.LoadScene(4);
            
            
        }
        else
        {
            sceneFaderRef.StartFadeIn();
            

            SceneManager.LoadScene(GetComponent<PlayerDataProgress>().LastLevelReachedPrefs);
        }
    }



}
