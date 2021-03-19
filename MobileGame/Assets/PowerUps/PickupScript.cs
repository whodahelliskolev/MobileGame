using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {
    [HideInInspector]
    public int PickupTypeInt;
    public enum PickupType
    {
        Invisible,
        Speed,

    }


    public PickupType CurrentPickupType;

    private void Start()
    {
        if (CurrentPickupType == PickupType.Invisible)
        {
            PickupTypeInt = 0;


        }

        if(CurrentPickupType == PickupType.Speed)
        {

            PickupTypeInt = 1;

        }


    }

}
