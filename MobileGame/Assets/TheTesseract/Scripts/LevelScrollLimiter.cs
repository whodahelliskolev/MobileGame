using UnityEngine;
using UnityEngine.UI;


public class LevelScrollLimiter : MonoBehaviour {



    public ScrollRect scrollbar;

    public float Limiter;
   
	
	void Start () {

        scrollbar.transform.localPosition = new Vector3(0, Limiter, 0f);

    }
	
	


   
}
