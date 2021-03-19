
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataProgress : MonoBehaviour {

    public string[] LevelsUnlocked;
    public  int CurrentLevelIndex;
    public  int LastLevelReachedPrefs = 0;
    public bool isAttachedToPlayer = true;
    

   

    private void Start()
    {

        ContinueLastLevelMechanic();

     
        
      
    }


    


    public void ContinueLastLevelMechanic()
    {
        LastLevelReachedPrefs = PlayerPrefs.GetInt("LastLevelReached");
        if (isAttachedToPlayer == true)
        {
            LastLevelReachedPrefs = PlayerPrefs.GetInt("LastLevelReached");
            CurrentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            if (CurrentLevelIndex > LastLevelReachedPrefs)
            {

                PlayerPrefs.SetInt("LastLevelReached", CurrentLevelIndex);
               
            }

            else
            {
               
            }
        }
    }

}
