using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTransformData : MonoBehaviour
{
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
        Debug.Log(DataArray[0].position + ", " + DataArray[2].position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
