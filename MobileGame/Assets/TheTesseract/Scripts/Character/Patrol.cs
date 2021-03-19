using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections;

public class Patrol : MonoBehaviour
{
    [Header("Patrol Points")]
    public Transform[] points;
    public float WaitTime = 1;
    private Vector3 startingScale;
    private Vector3 endingScale;
    [HideInInspector]
    public Renderer rend;
    Material[] mats;
    [HideInInspector]
    public Material MaterialStandart;
    [HideInInspector]
    public Material MaterialOne;
    [HideInInspector]
    public ParticleSystem SpawnEffect;
    [HideInInspector]
    public GameObject solidEnemy_reference;
    private bool isAgentWaiting = false;
    private NavMeshPath path;
    private NavMeshAgent agent;
    Animator enemyAnim;

    //[HideInInspector]
    public GameObject endingPuzzle;

    //[HideInInspector]
    public GameObject circle;

    [HideInInspector]
    public GameObject Player;

    [HideInInspector]
    public ParticleSystem HitParticle;
    private bool PlayerSeen;
    private bool StopEnemies_Reference;

    [HideInInspector]
    public AudioSource EnemyHitAudio_SRC;


    private float LerpTime = .25f;
    private float CurrentLerpTime = 0;

    [SerializeField]
    [Header("Enemy AI Modules")]
    public bool staticEnemy;
    private float speed = 0f;
    
    private int destPoint = 0;
    private CharacterMove CharacterMove_Reference;
    
    private Rigidbody self_Rigidbody;
    
    
    private Slider PlayerHealth;

    void Start()
    {
        InitializeEnemyProperties();    
    }

    public void InitializeEnemyProperties()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
        agent.autoBraking = false;
        rend = solidEnemy_reference.GetComponent<Renderer>();
        path = new NavMeshPath();
        GotoNextPoint();
        mats = rend.materials;
        startingScale = circle.transform.localScale;
        endingScale = new Vector3(0, 0, 0);
        CharacterMove_Reference = Player.GetComponent<CharacterMove>();
        self_Rigidbody = gameObject.GetComponent<Rigidbody>();
        InvokeRepeating("PlayerSeenFunctionality", .7f, .7f);
        InvokeRepeating("checkifLevelCompleted", 0.5f, 0.5f);
        PlayerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Slider>();
    }
   
    private void FixedUpdate()
    {
        StopEnemies_Reference = endingPuzzle.GetComponent<PlatformPuzzleTypeOne>().StopEnemies;
        LerpCircle();
        enemyBlendAnimation();
        

    }

    void GotoNextPoint()
    {



        if (points.Length == 0)
            return;

        
       
        else
        {

            if (isAgentWaiting)
            {
                return;
            }

            
            if (!isAgentWaiting)
            {
                isAgentWaiting = true;
                StartCoroutine(DelayBetweenPoints());
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            
            if (Player.GetComponent<CharacterMove>().isPlayer_StandingStill == false  && endingPuzzle.GetComponent<PlatformPuzzleTypeOne>().StopEnemies == false)
            {
                
                mats[2] = MaterialOne;
                mats[3] = MaterialOne;
                rend.materials = mats;
                PlayerSeen = true;
                if (endingPuzzle.GetComponent<PlatformPuzzleTypeOne>().StopEnemies == false)
                {
                    gameObject.GetComponent<AudioSource>().enabled = true;
                }
                


            }
            
        }

    }
    
    private void OnTriggerStay(Collider other)
        {
           if (other.gameObject == Player)
            {
            
            if (Player.GetComponent<CharacterMove>().isPlayer_StandingStill == false)
                {

                    mats[2] = MaterialOne;
                    mats[3] = MaterialOne;
                    rend.materials = mats;
                    PlayerSeen = true;
                
                if (endingPuzzle.GetComponent<PlatformPuzzleTypeOne>().StopEnemies == false)
                    {
                        gameObject.GetComponent<AudioSource>().enabled = true;
                    }
                }
                
            }

        }
        
    private void OnCollisionEnter(Collision other)
    {


        {
            if (other.gameObject == Player && endingPuzzle.GetComponent<PlatformPuzzleTypeOne>().StopEnemies == false)
            {

                if (endingPuzzle.GetComponent<PlatformPuzzleTypeOne>().StopEnemies == false)
                {
                    gameObject.GetComponent<AudioSource>().enabled = true;
                }
                mats[2] = MaterialOne;
                mats[3] = MaterialOne;
                rend.materials = mats;
                PlayerSeen = true;

                if (PlayerHealth.value == 0)

                {
                    //Do Nothing;
                }
                else if (PlayerHealth.value != 0) // Continue to drain player's health.

                { 
                    Player.GetComponent<CharacterMove>().HitBarColor();
                    PlayerHealth.value = PlayerHealth.value - .5f;
                    EnemyHitAudio_SRC.Play();
                    HitParticle.Emit(1);
                 }
            }
        }
    }

    private void enemyBlendAnimation()
    {
        speed = Vector3.Project(agent.desiredVelocity, transform.forward).magnitude / agent.speed;
        
        enemyAnim.SetFloat("Blend", speed);
    }

    private void PlayerSeenFunctionality()
    {
        if (PlayerSeen == true)
        {
  
            agent.destination = Player.transform.position;
         
            agent.speed = 6;

            

        }
    }

    private void checkifLevelCompleted()
    {
        if (StopEnemies_Reference == true)
        {



            agent.isStopped = true;

            mats[2] = MaterialStandart;
            mats[3] = MaterialStandart;
            rend.materials = mats;

            



        }
    }

    private void GoToNextPointIfPlayerIsNotSeen()
    {
        if (PlayerSeen == false && staticEnemy == false)
        {
            if (agent.remainingDistance < 0.5f)
            {
                
                GotoNextPoint();
            }
        }

        else if (PlayerSeen == false && staticEnemy == true)
        {
            //Do Nothing
        }

    }

    private void LerpCircle()
    {
        if (StopEnemies_Reference == true)
        {
            float Perc = CurrentLerpTime / LerpTime;
            CurrentLerpTime += Time.deltaTime;
            circle.transform.localScale = Vector3.Lerp(startingScale, endingScale, Perc);
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        }
        if (PlayerSeen == true)
        {

            float Perc = CurrentLerpTime / LerpTime;
            CurrentLerpTime += Time.deltaTime;
            circle.transform.localScale = Vector3.Lerp(startingScale, endingScale, Perc);
           
        }


    }
    
    private IEnumerator DelayBetweenPoints()
    {
        yield return new WaitForSeconds(WaitTime);
        agent.destination = points[destPoint].position;

        
        destPoint = (destPoint + 1) % points.Length;
        isAgentWaiting = false;
    }
    

    void Update()

    {

        
        GoToNextPointIfPlayerIsNotSeen();
       
    }
    
}
