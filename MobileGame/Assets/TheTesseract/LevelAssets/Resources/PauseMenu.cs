

using UnityEngine;




public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject IngameUi;
    public GameObject MobileInput;
    public Canvas levelComplete_Canvas;
    public GameObject TutorialHide;
    public  static bool CanSlideMenu;
    public GameObject Slider;


   

    public void Toggle()
    {


        ui.SetActive(!ui.activeSelf && IngameUi.activeSelf);
        Time.timeScale = 0.001f;
        CanSlideMenu = !CanSlideMenu;
        Slider.SetActive(false);


        if (levelComplete_Canvas != null)
        {
            if (levelComplete_Canvas.enabled == true)
            {
                levelComplete_Canvas.enabled = false;
            }

            else
            {
                levelComplete_Canvas.enabled = true;
            }
        }

        if (TutorialHide != null)
        {
            if (TutorialHide.GetComponent<Canvas>().enabled == true)
            {
                TutorialHide.GetComponent<Canvas>().enabled = false;
            }
            else

            {
                TutorialHide.GetComponent<Canvas>().enabled = true;
            }
        }




        if (MobileInput != null)

        {
            MobileInput.SetActive(false);


             if (MobileInput.activeSelf == false && !ui.activeSelf)

             {
                MobileInput.SetActive(true);
               Time.timeScale = 1;
                Slider.SetActive(true);
            }


           


        }
    }
}
