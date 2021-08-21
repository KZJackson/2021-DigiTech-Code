using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTransformData : MonoBehaviour
{
    // A script to get Transform Data of the board tiles and adds them to an array to be used by other scripts
    public Transform[] DataArray;
    public int length;


    void Awake()
    {
        DataArray = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            DataArray[i] = transform.GetChild(i);
        }
        length = DataArray.Length;
    }

}
