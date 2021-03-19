using UnityEngine.UI;
using UnityEngine;




public class HideTutorialScript : MonoBehaviour {

    public GameObject HideTutorialPanel;


    public void HideTut() {

        HideTutorialPanel.SetActive(false);
        
    }


}
