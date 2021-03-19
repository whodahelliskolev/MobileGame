
using UnityEngine;
using UnityEngine.UI;

public class ElectricFloor : MonoBehaviour {
    private CharacterMove CharMoveReferencee_;
    private Slider PHealthSlider;
    private bool isInTrigger;
    private bool AudioPlayed = false;
    private LerpHealthColor LerpHealthColor_reference;
    //[HideInInspector]
    public AudioSource ElectrictyAudio;
    
    
  
	void Start () {
        PHealthSlider = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Slider>();
        CharMoveReferencee_ = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMove>();
        LerpHealthColor_reference = GameObject.FindGameObjectWithTag("LerpHealthComponent").GetComponent<LerpHealthColor>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag== "Player")
        {
            LerpHealthColor_reference.RegainHealthBarColorTime = 1f;
            isInTrigger = true;


            if (AudioPlayed == false)
            {
                ElectrictyAudio.Play();
            }
           

            AudioPlayed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isInTrigger = false;
            LerpHealthColor_reference.RegainHealthBarColorTime = .11f;
            AudioPlayed = false;
        }
    }

    private void DoDamage()
    {
        PHealthSlider.value -= .01f;
        CharMoveReferencee_.HitBarColor();
    }

    private void FixedUpdate()
    {
        if (isInTrigger)
        {
            DoDamage();
        }
    }
}
