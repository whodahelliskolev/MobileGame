
using UnityEngine;
using UnityEngine.AI;

public class GuardianPatrol : MonoBehaviour {

    public enum GuardianAIStates
    {

        Idle,
        Patrolling

    }
    [HideInInspector]
    public Renderer GuardianRend;

    [HideInInspector]
    public Material RedMaterial;

    [HideInInspector]
    public Material BlackMaterial;

    [HideInInspector]
    public GameObject GuardianBody_ForRenderer;
    private NavMeshAgent guardian;
    private NavMeshPath navmeshPath;

    //[HideInInspector]
    public Transform[] DestinationPoints;
    private bool isGuardianTurnedOff;

    [HideInInspector]
    Material[] guardian_materials;
    private int destinationPoint = 0;
    private float GuardianAnimBlend = 0;
    private GameObject Player_reference;
    Animator Guardian_Animator;

    [HideInInspector]
    public Rigidbody[] OrbsRigidBodies;
    private int GuardianState;

    [HideInInspector]
    public GuardianOrbScript[] guardianorbScriptReference;

    [HideInInspector]
    public ParticleSystem[] OrbsParticles;
    private GameObject PuzzleMachine_reference;
    private bool isLevelCompleted;
    private bool DeactivateOnlyOnce;
    public GuardianAIStates CurrentAIState;

    [HideInInspector]
    public GameObject ballrotator;

    public float rotationSpeed;

    [HideInInspector]
    public AudioSource TurnOffGuardianAudioSource;

	void Start ()
    {
        
        InitializeGuardianProperties();
        
	}
	
    private void InitializeGuardianProperties()
    {
        
        navmeshPath = new NavMeshPath();
        isGuardianTurnedOff = false;
        guardian = GetComponent<NavMeshAgent>();
        Guardian_Animator = GetComponent<Animator>();
        guardian.autoBraking = false;
        GuardianRend = GuardianBody_ForRenderer.GetComponent<Renderer>();
        guardian_materials = GuardianRend.materials;
        Player_reference = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("CheckGuardianState", .5f, .5f);
        InvokeRepeating("CheckIfLevelCompleted", .5f, .5f);
        PuzzleMachine_reference = GameObject.Find("PuzzleEndPlatform");
        
        
    }

    private void CheckGuardianState()
    {
        if (CurrentAIState == GuardianAIStates.Idle)
        {
            GuardianState = 0;
        }

        if (CurrentAIState == GuardianAIStates.Patrolling)
        {
            GuardianState = 1;
        }
    }

    public void GuardianPoint()
    {



        if (DestinationPoints.Length == 0)
            return;



        else
        {


            guardian.destination = DestinationPoints[destinationPoint].position;


            destinationPoint = (destinationPoint + 1) % DestinationPoints.Length;
        }
    }

    void Update ()
    {
        if (isGuardianTurnedOff == false)
        {
            ballrotator.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }


        if (GuardianState == 1)
        {
            GuardianPoint();
        }
	}

    void CheckIfLevelCompleted()
    {
        if (PuzzleMachine_reference.GetComponent<PlatformPuzzleTypeOne>().StopEnemies == true &&  DeactivateOnlyOnce == false)
        {
            DeactivateOnlyOnce = true;

            guardian.isStopped = true;

            TurnOffGuardian();
            
        }
    }

    private void FixedUpdate()
    {
        GuardianBlendAnimation();
    }

    private void GuardianBlendAnimation()
    {
        GuardianAnimBlend = Vector3.Project(guardian.desiredVelocity, transform.forward).magnitude / guardian.speed;
        Guardian_Animator.SetFloat("GuardianBlend", GuardianAnimBlend);
    }

    private void TurnOffGuardian()
    {
        if (isGuardianTurnedOff == false)
        {
            guardian_materials[0] = BlackMaterial;
            guardian_materials[1] = BlackMaterial;
            GuardianRend.materials = guardian_materials;
            guardian.isStopped = true;
            isGuardianTurnedOff = true;
            TurnOffGuardianAudioSource.Play();

            foreach (Rigidbody orbrb in OrbsRigidBodies)
            {
                orbrb.useGravity = true;
                orbrb.isKinematic = false;

            }

            foreach (GuardianOrbScript GOrb_ref in guardianorbScriptReference)
            {
                GOrb_ref.ChangeOrbmaterial();
                GOrb_ref.canDoDamage = false;

            }

            foreach (ParticleSystem psys in OrbsParticles)
            {
                psys.Emit(1);
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Player_reference)
        {
            TurnOffGuardian();
            
        }
    }
}
