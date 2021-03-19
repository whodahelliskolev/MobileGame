using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePickupNewMechanic : MonoBehaviour {

   
   

    private GameObject cube;
   
    [HideInInspector]
    public bool canPickupCube;// Variable from button to check if Player Can pickup cube
    [HideInInspector]
    public bool CanUsePickup;

    private GameObject PickupCubeButton;

    [HideInInspector]
    public GameObject PickupTransform; //location to Lerp the cube to.
    
    
    private float Distance;

    private float LerpTime = 0.5f;
    private float CurrentLerpTime = 0; // Set back to 0 after lerp so lerping occurs smooth again.
    private ParticleSystem cubeParticleRef;
    [HideInInspector]
    public bool MakeCubeStatic;
    [HideInInspector]
    
    public AudioSource pickupCubeSound;
    private bool playSound;
    private Rigidbody cube_rigidbody_reference;
    private Collider cube_collider_reference;
    private bool MakeCubeStatic_Getter;
    private GameObject Platform_reference;
    private Projector projector_reference;
    private PlatformPuzzleTypeOne platform_script_reference;


    // Use this for initialization
    void Start ()
    {
        

        PickupCubeButton = GameObject.FindGameObjectWithTag("PickupButtonTag");
        cube = GameObject.FindGameObjectWithTag("PuzzlePiece"); // find the puzzlepiece and set it to Cube so I can reference it later.
        projector_reference = cube.GetComponentInChildren<Projector>();
        cubeParticleRef = cube.GetComponentInChildren<ParticleSystem>(); // find the particle system component of the cube so I can store reference.
        playSound = true;
        cube_rigidbody_reference = cube.GetComponent<Rigidbody>();
        cube_collider_reference = cube.GetComponent<Collider>();
        Platform_reference = GameObject.FindGameObjectWithTag("PuzzleMachine");
        projector_reference.orthographicSize = 0;
        platform_script_reference = Platform_reference.GetComponent<PlatformPuzzleTypeOne>();
    }

    private void Update()
    {
        DistanceCalculations();
        CheckIfCubeIsStatic();
    }

    private void FixedUpdate()
    {

        CubeAnimationAndParticle();
        CubeButtonFunctionality();

    }

    private void CubeButtonFunctionality()
    {

        if (PickupCubeButton.GetComponent<HoldButtonScript>().isButtonPressed == true && Distance < 3 && platform_script_reference.CubeStatic == false)
        {

            Physics.IgnoreCollision(cube.GetComponent<Collider>(), GetComponent<Collider>(), true);
            
            float Perc = CurrentLerpTime / LerpTime;
            CurrentLerpTime += Time.deltaTime;
            cube.transform.position = Vector3.Lerp(cube.transform.position, PickupTransform.transform.position, Perc);
            projector_reference.orthographicSize = 0.75f;

            PickupTransform.GetComponent<Collider>().enabled = true;
            cube_rigidbody_reference.isKinematic = true;
            cube_collider_reference.enabled = false;
            if (playSound == true)
            {
                pickupCubeSound.Play();
                playSound = false;
            }
            
        }
       
       

        if (PickupCubeButton.GetComponent<HoldButtonScript>().isButtonPressed == false )
        {
            
            CurrentLerpTime = 0;
            
            PickupTransform.GetComponent<Collider>().enabled = false;
            Physics.IgnoreCollision(cube.GetComponent<Collider>(), GetComponent<Collider>(), false);
            playSound = true;
            cube_rigidbody_reference.isKinematic = false;
            cube_collider_reference.enabled = true;
            projector_reference.orthographicSize = 0;
        }
    }

    public void DropCube()
    {
        CurrentLerpTime = 0;

        PickupTransform.GetComponent<Collider>().enabled = false;
        Physics.IgnoreCollision(cube.GetComponent<Collider>(), GetComponent<Collider>(), false);
        playSound = true;
        cube_rigidbody_reference.isKinematic = false;
        cube_collider_reference.enabled = true;
        projector_reference.farClipPlane = 0;
    }

    private void CubeAnimationAndParticle()
    {
        if (Distance < 3 && platform_script_reference.CubeStatic == false)
        {
            cubeParticleRef.Emit(1); // emits the particles if the player is close enough.
            cube.GetComponent<Animator>().SetBool("OpenCube", true);
        }

       
        else if (Distance > 3 )
        {
            cube.GetComponent<Animator>().SetBool("OpenCube", false);
        }

        else if (Distance < 3 && platform_script_reference.CubeStatic == true)
        {
            cube.GetComponent<Animator>().SetBool("OpenCube", false);
        }
    }
     
    private void  DistanceCalculations()
    {

        Distance = Vector3.Distance(cube.transform.position, transform.position);

    }

    private void CheckIfCubeIsStatic()
    {

        if (cube != null)
        {
            MakeCubeStatic = MakeCubeStatic_Getter;
        }
    }

}




