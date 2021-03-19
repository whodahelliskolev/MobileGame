using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nexPos;
    public float speed;
    [SerializeField]
    private Transform childTransform;
    [SerializeField]
    private Transform transformB;

    private void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;

    }


   

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        childTransform.transform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posA ? posA : posB;
    }
}
