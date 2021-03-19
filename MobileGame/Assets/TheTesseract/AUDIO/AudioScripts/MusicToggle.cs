
using UnityEngine;
using UnityEngine.UI;



public class MusicToggle : MonoBehaviour
{



    [SerializeField]
    private AudioSource audioSource;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ToggleSound(bool newValue)
    {
        Debug.Log(AudioListener.volume);
        if (newValue == false)
        {
            AudioListener.volume = 0.0f;
            PlayerPrefs.SetInt("SoundState", 0);
        }


        if (newValue == true)
        {
            AudioListener.volume = 1.0f;
            PlayerPrefs.SetInt("SoundState", 1);
        }
    }



}
