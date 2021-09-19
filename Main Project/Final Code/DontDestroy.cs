using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake(){
        //stops any object this script is attached to from destroying when a new scene is loaded.
        DontDestroyOnLoad(this.gameObject);
    }
}
