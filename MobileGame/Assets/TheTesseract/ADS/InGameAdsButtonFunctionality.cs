using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class InGameAdsButtonFunctionality : MonoBehaviour {

    private PlatformPuzzleTypeOne cubeplatform_scriptereference;
    public Button adbutton;
    public Image playAdButtonImage;
   
	// Use this for initialization
	void Start () {

        cubeplatform_scriptereference = GameObject.FindGameObjectWithTag("PuzzleMachine").GetComponent<PlatformPuzzleTypeOne>();
        if (PlayerPrefs.GetInt("Retries") == 10)
        {
           // StartCoroutine(FadeInButton());
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

    private IEnumerator FadeInButton()
    {
        adbutton.GetComponent<Image>().enabled = true;
        
        playAdButtonImage.GetComponent<Image>().enabled = true;


        yield return new WaitForSeconds(5);
        adbutton.GetComponent<Image>().enabled = false;
        
        playAdButtonImage.GetComponent<Image>().enabled = false;
        
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");

                cubeplatform_scriptereference.Increment();
                
                PlayerPrefs.SetString(SceneManager.GetActiveScene().name, "yes");
                PlayerPrefs.SetInt("Retries", 0);
                adbutton.GetComponent<Image>().enabled = false;
                
                playAdButtonImage.GetComponent<Image>().enabled = false;

                SceneManager.LoadScene("PuzzleScene");
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
