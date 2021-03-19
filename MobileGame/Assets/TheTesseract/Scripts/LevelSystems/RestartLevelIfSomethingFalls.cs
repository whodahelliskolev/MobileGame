
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class RestartLevelIfSomethingFalls : MonoBehaviour {


    private int RandomIntChance;

    public PlayerDataProgress PlayerDataProgressRef;

    private bool canRestart = true;
  

    public void RestartLevel()
    {
        RandomIntChance = Random.Range(1, 100);

        if (RandomIntChance == 2)
        {
          //  ShowRewardedAd();

        }
        else if (RandomIntChance != 2)
        {

            if (canRestart == true)
            {
                canRestart = false;
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

                IncrementRetries();
                canRestart = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PuzzlePiece") || other.CompareTag( "ImportantForLevel") || other.CompareTag ( "Player")) // Detects if objects with those tags fall off the level.Then Restarts if true.

        {


            RestartLevel();
             
    
        }

        
       

    }
    public void IncrementRetries()
    {
        if (PlayerPrefs.GetInt("Retries") == 10)
        {

        }
        else
        {
            PlayerPrefs.SetInt("Retries", PlayerPrefs.GetInt("Retries") + 1);
            Debug.Log(PlayerPrefs.GetInt("Retries"));
        }
        
    }
   
    
    
   /*
    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
            Debug.Log("reward is showing");
            
        }

        Debug.Log("reward is showing");
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");

                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
                 break;

            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;

            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
                break;
        }
    }
   */
}