using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfTwo : MonoBehaviour
{
    
    /* When the user clicks the back button to go back to another scene, if the scene contains a data holder, one is created on load
    However, the original holder that carries through scenes still exists, therefore there are now two copies of it*/
    //This script is reponsible for making sure there is only one holder per scene.
    


    public GameObject[] YearHolders;
    public GameObject[] DiffHolders;
    public GameObject[] Setups;
    
    public void DestroyYearHolders(){
        YearHolders = GameObject.FindGameObjectsWithTag("YearHolder");

        if(YearHolders.Length > 1)
        {
            Destroy(YearHolders[0]);
            YearHolders = GameObject.FindGameObjectsWithTag("YearHolder");
        }
    }

    public void DestroyDiffHolders(){
        DiffHolders = GameObject.FindGameObjectsWithTag("DiffHolder");

        if(DiffHolders.Length > 1)
        {
            Destroy(DiffHolders[0]);
            DiffHolders = GameObject.FindGameObjectsWithTag("DiffHolder");
        }
    }

    public void DestroySetups(){
        Setups = GameObject.FindGameObjectsWithTag("Setup");

        if(Setups.Length > 1)
        {
            Destroy(Setups[0]);
            Setups = GameObject.FindGameObjectsWithTag("Setup");
        }
    }
    void Awake()
    {
        DestroyYearHolders();
        DestroyDiffHolders();
        DestroySetups();
    }

}
