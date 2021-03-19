using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardianOrbScript : MonoBehaviour {

    public Renderer orbRend;
    public Material RedMaterialOrb;
    public Material BlackMaterialOrb;
    Material[] orb_materials;
    private Rigidbody self_rigidbody;
    public AudioSource HitAudio;
    private bool AudioOnce = false;
    [HideInInspector]
    public bool canDoDamage = true ;
    private Slider PlayerHealthSlider;

    private CharacterMove CharMoveOrbReference;

    void Start () {
        canDoDamage = true;
        orbRend = gameObject.GetComponent<Renderer>();
        orb_materials = orbRend.materials;
        self_rigidbody = gameObject.GetComponent<Rigidbody>();
        PlayerHealthSlider = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Slider>();
        CharMoveOrbReference = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMove>();
    }
	
	public void ChangeOrbmaterial()
    {
        orb_materials[0] = BlackMaterialOrb;
        orb_materials[1] = BlackMaterialOrb;
        orbRend.materials = orb_materials;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player" && AudioOnce == false && canDoDamage == true)
        {
            AudioOnce = true;
            self_rigidbody.useGravity = true;
            self_rigidbody.isKinematic = false;
            gameObject.transform.parent = null;
            orb_materials[0] = BlackMaterialOrb;
            orb_materials[1] = BlackMaterialOrb;
            orbRend.materials = orb_materials;
            PlayerHealthSlider.value -= .5f;
            CharMoveOrbReference.HitBarColor();
            HitAudio.Play();
            gameObject.GetComponent<ParticleSystem>().Emit(1);

        }

       
    }

}
