
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CnControls;

public class CharacterMove : MonoBehaviour {


    [HideInInspector]
    public float MovementSpeed = 4 ;
    
    private float InvisibleTime;
    private float SpeedTime;
    private float InvisibleTimeLimit = 5;
    private float SpeedTimeLimit = 3;
    Vector3 forward, right;
    private float CurrentLerpTime = 0;
    private float LerpTime = 1;
    private float velocityBlend;
    private bool horizontalPressed = false, verticalPressed = false;
    private bool PlayerSpeed;
    [HideInInspector]
    public  Animator CharAnimator;
    [HideInInspector]
    public Slider Player_health;
    private RestartLevelIfSomethingFalls RestartLevelScript_Reference;
    
    private PlatformPuzzleTypeOne EndingPuzzle_Reference;
    private GameObject platform_puzzle_gameobject;

    [HideInInspector]
    public GameObject BlobShadowProjector;

    [HideInInspector]
    public static  bool isPlayerDead;

    [HideInInspector]
    public Material[] Player_Materials;

    [HideInInspector]
    public Material BlackUnlitPlayer_Mat;

    [HideInInspector]
    public GameObject charmesh;

    [HideInInspector]
    public Renderer Player_Renderer;
    private ParticleSystem health_pickup_particle;
    private ParticleSystem other_powerup_particle;

    [HideInInspector]
    public AudioSource pickupHealthSound;
    private bool PlayerInvisible;
    [HideInInspector]
    public float hp_value = 2;

    [HideInInspector]
    public  LerpHealthColor LerpHealth_Reference;
    
    [HideInInspector]
    public bool isPlayer_StandingStill;

    [HideInInspector]
    public Material BluePlayerMat;
    private PickupScript PickupScript_Reference;
    public CubePickupNewMechanic Cubepickup_reference_mechanic;

    void Start()
    {
        
        InitiatePlayerProperties();
        Player_Materials = Player_Renderer.materials;  
        HiddenMatScheme();
        
    }


    

    public void InitiatePlayerProperties()
    {
        platform_puzzle_gameobject = GameObject.FindGameObjectWithTag("PuzzleMachine");
        EndingPuzzle_Reference = platform_puzzle_gameobject.GetComponent<PlatformPuzzleTypeOne>();


        RestartLevelScript_Reference = new RestartLevelIfSomethingFalls();
        Player_health = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Slider>();
        CharAnimator = GetComponent<Animator>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        InvokeRepeating("CheckIfPlayerIsDead", .25f,.25f);
        isPlayerDead = false;
        isPlayer_StandingStill = true;
    }//Load components and other things neccessery at the start of the level.

    public void HiddenMatScheme()
    {
        Player_Materials[0] = BlackUnlitPlayer_Mat;
        Player_Materials[1] = BlackUnlitPlayer_Mat;
        Player_Materials[2] = BlackUnlitPlayer_Mat;
        Player_Materials[3] = BlackUnlitPlayer_Mat;
        Player_Renderer.materials = Player_Materials;
    }//Material properties of the Hidden State.

    public void SeenMatScheme()
    {
        Player_Materials[0] = BlackUnlitPlayer_Mat;
        Player_Materials[1] = BlackUnlitPlayer_Mat;
        Player_Materials[2] = BluePlayerMat;
        Player_Materials[3] = BluePlayerMat;

        Player_Renderer.materials = Player_Materials;
    }//material properties of the Seen State.

    public void HitBarColor()
    {
        LerpHealth_Reference.RedBarColor = new Color(255, 0, 0, 1);

    }//Change the hitbar color accordingly.

    public void RegainHealthColor()
    {
        LerpHealth_Reference.RedBarColor = new Color(0, 255, 0, 1);
    }//Change the hitbar color accordingly.

    public void CheckIfPlayerIsDead()
    {
        if(Player_health.value == 0)
        {
            hp_value = 0;
            
            StartCoroutine(RagdollPlayer());
            DropCubeOnDeath();
            
        }
    }//Method that detects if the Player is dead.Invoked.

    private void DropCubeOnDeath()
    {

        Cubepickup_reference_mechanic.DropCube();

        Cubepickup_reference_mechanic.enabled = false;
    }

    public void OnCollisionEnter(Collision otherObject)
    {
        if (otherObject.gameObject.tag == "Health_Pickup" && Player_health.value > 0)
        {
            RegainHealthColor();
            Player_health.value = Player_health.value + .50f;
            pickupHealthSound.Play();
            otherObject.gameObject.GetComponent<ParticleSystem>().Emit(1);

            MeshRenderer[] rs = otherObject.gameObject.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer r in rs)
                r.enabled = false;
            otherObject.gameObject.GetComponent<Collider>().enabled = false;
            otherObject.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }

         if (otherObject.gameObject.tag == "Power_Up" && Player_health.value > 0)
        {
            if (otherObject.gameObject.GetComponent<PickupScript>().PickupTypeInt == 0)
            {
                Debug.Log("Invisible");
                PlayerInvisible = true;
                HiddenMatScheme();
                InvisibleTime = 0;
                MeshRenderer[] rs = otherObject.gameObject.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer r in rs)
                    r.enabled = false;
                otherObject.gameObject.GetComponent<Collider>().enabled = false;
                otherObject.gameObject.GetComponent<Rigidbody>().useGravity = false;
                pickupHealthSound.Play();
                otherObject.gameObject.GetComponent<ParticleSystem>().Emit(1);
                LerpHealth_Reference.InvisibleBarValue.fillAmount = 1;



            }

            else if (otherObject.gameObject.GetComponent<PickupScript>().PickupTypeInt == 1)
            {
                
                MovementSpeed = 7;
                SpeedTime = 0;
                MeshRenderer[] rs = otherObject.gameObject.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer r in rs)
                    r.enabled = false;
                otherObject.gameObject.GetComponent<Collider>().enabled = false;
                otherObject.gameObject.GetComponent<Rigidbody>().useGravity = false;
                pickupHealthSound.Play();
                otherObject.gameObject.GetComponent<ParticleSystem>().Emit(1);
                PlayerSpeed = true;
                LerpHealth_Reference.SpeedBarValue.fillAmount = 1;
                
            }


        }

        

       
    }//Detect if the object the Player collided with is a HP pickup.


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TurnOffPlayerZone")
        {
            TurnOffPlayer();
            DropCubeOnDeath();
        }
    }

    private void TurnOffPlayer()
    {
        gameObject.GetComponentInChildren<Rigidbody>().constraints = RigidbodyConstraints.None;

        MovementSpeed = 0;

        HiddenMatScheme();

        CharAnimator.SetBool("ContractLegs", true);

        BlobShadowProjector.GetComponent<Projector>().enabled = false;

        hp_value = 0;

    }

    private IEnumerator RagdollPlayer()
    {

        gameObject.GetComponentInChildren<Rigidbody>().constraints = RigidbodyConstraints.None;

        MovementSpeed = 0;

        HiddenMatScheme();

        CharAnimator.SetBool("ContractLegs", true);

        BlobShadowProjector.GetComponent<Projector>().enabled = false;

        isPlayerDead = true;


        yield return new WaitForSeconds(3);

        if (EndingPuzzle_Reference.CubeStatic == true)
        {
           //do Nothing cuz the level is restarted
        }
        else if (EndingPuzzle_Reference.CubeStatic == false)
        {
            RestartLevelScript_Reference.RestartLevel(); // restart the level because the level isnt finished and the player died.
        }
        


       
    }//Ragdoll the player on death method.

    private void CalculateMovementPlayer()
    {
        Vector3 rightMovement = right * MovementSpeed * Time.deltaTime * CnInputManager.GetAxis("HorizontalKey"); //Calculates Horizontal Axis.
        velocityBlend = (Mathf.Abs(CnInputManager.GetAxis("HorizontalKey")) + Mathf.Abs(CnInputManager.GetAxis("VerticalKey"))) / 2;
        if (rightMovement != new Vector3(0, 0, 0))
        {
            Move();
            bool isRunning = (Input.anyKey);
            
            if (PlayerInvisible == true)
            {
                if (isPlayerDead == false)
                {
                    isPlayer_StandingStill = true;
                }
                


                
            }
            if (PlayerInvisible == false)
            {

                isPlayer_StandingStill = false;

                if (isPlayerDead == false)
                {
                    SeenMatScheme();
                }
            }
          
        }
        
        

        else if (SimpleJoystick.isPointerUp == true)
        {


            HiddenMatScheme();
            CurrentLerpTime = 0f;
            velocityBlend = 0f;
            CharAnimator.SetFloat("Blend", velocityBlend);
            isPlayer_StandingStill = true;
         
            
        }
    }//Important stuff for player blend float and moving method.
    
    void Update() {


        if (isPlayerDead == false)
        {


            DecrementInvisibleBar();

            CalculateMovementPlayer();

            DecrementSpeedBar();

        }
    }// Update is called once per frame

    void DecrementSpeedBar()
    {
        if (PlayerSpeed == true)
        {

            SpeedTime += Time.deltaTime;
            LerpHealth_Reference.SpeedBarValue.fillAmount -= Time.deltaTime / 3;

        }

        if (SpeedTime >= SpeedTimeLimit )
        {
            PlayerSpeed = false;
            if (isPlayerDead == false)
            {
                MovementSpeed = 4;
            }
            
            SpeedTime = 0;
        }
    }//Deplete the InvisibleBar

    void DecrementInvisibleBar()
    {
        if (PlayerInvisible == true )
        {
            
                InvisibleTime += Time.deltaTime;
                LerpHealth_Reference.InvisibleBarValue.fillAmount -= Time.deltaTime / 5 ;
    
        }

        if(InvisibleTime >= InvisibleTimeLimit)
        {
            PlayerInvisible = false;
            InvisibleTime = 0;
        }
    }//Deplete the InvisibleBar

    void Move() // Function that moves the Player.
    {
        float Perc = CurrentLerpTime / LerpTime;
        CurrentLerpTime += Time.deltaTime;

        Vector3 rightMovement = right * MovementSpeed * Time.deltaTime * CnInputManager.GetAxis("HorizontalKey"); //Calculates Horizontal Axis.
        Vector3 upMovement = forward * MovementSpeed * Time.deltaTime * CnInputManager.GetAxis("VerticalKey");   //Calculates Vertical Axis.
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        CharAnimator.SetFloat("Blend", velocityBlend);

        bool angleRotation = false;

        if (Vector3.Angle(transform.forward, heading) > 120)
        {
            transform.forward = Vector3.Lerp(transform.forward, heading, Perc * 5);

            angleRotation = true;
           
        }



            transform.position += rightMovement;
            transform.position += upMovement;

        if (Input.GetAxis("HorizontalKey") != 0)
            horizontalPressed = true;
        if (Input.GetAxis("VerticalKey") != 0)
            verticalPressed = true;

        if(verticalPressed && horizontalPressed)
        {
            
            if (CurrentLerpTime > 1)
                CurrentLerpTime = 0;

        }
            if (transform.forward != heading && !angleRotation)
        {
            
            transform.forward = Vector3.Lerp(transform.forward,heading, Perc);
        }
    }


   
}


