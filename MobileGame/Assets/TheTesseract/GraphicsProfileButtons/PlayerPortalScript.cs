
using UnityEngine;

    public class PlayerPortalScript : MonoBehaviour {

    public ParticleSystem player_Portal_Particle;
    public AudioSource portalAudio;
    private AudioClip audioclip;
	

    public void PlayerPortalEffect()
    {
        player_Portal_Particle.Emit(5);
        portalAudio.Play();
    }
    public void PortalSound()
    {
        portalAudio.Play();
    }

}

