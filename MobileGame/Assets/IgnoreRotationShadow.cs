
using UnityEngine;

public class IgnoreRotationShadow : MonoBehaviour {
    public GameObject CubeReference;
    public Vector3 CubeLocation;


    private void Start()
    {

        
    }

    private void GetCubeLocation()
    {
        CubeLocation = new Vector3(CubeReference.transform.position.x, CubeReference.transform.position.y + 2, CubeReference.transform.position.z);
        gameObject.transform.position = CubeLocation;
    }



    void FixedUpdate () {
        GetCubeLocation();
	}
}
