using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    public GameObject target;
    public float size = 10;
    public float scrollSpeed = 30;
    public float distance;

   
    private Camera cam;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        this.cam = (Camera)this.gameObject.GetComponent("Camera");
        
        

       
    }

    void Update()
    {
        this.cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;

       

        

        transform.position = Vector3.Lerp(transform.position, target.transform.position + new Vector3(-distance, distance, -distance), 2f * Time.deltaTime);
        
    }

    void OnGUI()
    {
       
    }
}

