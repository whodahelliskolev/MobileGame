
using UnityEngine;

public class TurnOnMusicStart : MonoBehaviour {

	
	void Start () {
		AudioListener.volume = 1.0f;
            PlayerPrefs.SetInt("SoundState", 1);
	}
	
	
}
