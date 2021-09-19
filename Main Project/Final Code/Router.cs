using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Router : MonoBehaviour
{   
    //The router is the script that decides which game screen to load (1, 2, 3, 4, 5 or 6)
    public int YearLevelToLoad;
    public string SceneToLoad;
    public bool Played;
    
    //Gets the HasPlayed bool from the setup handler
    public void GetHasPlayed(){
        Played = GameObject.Find("Setup").GetComponent<SetupHandler>().HasPlayed;
        Debug.Log("Played = " + Played);
        /*Note that even if the input is invalid, the bool will log as false, as a bool cannot be empty, it must be true or false
        and false is the default*/
    }

    //Redirects the user to the scene respective to their year level
    public void Redirect(){
        if(Played == true)
        {
            if(GameObject.Find("Setup").GetComponent<SetupHandler>().NameEntered == true)
            {
                SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
                Debug.Log(SceneToLoad + " was loaded");
            }
            
            
        }
    }
    
    //Redirects the user from the how to play screen to the scene respective to their year level
    public void RedirectFromHTP(){
    
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
        Debug.Log(SceneToLoad + " was loaded");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //I am using the Start function to initialize the YearLevelToLoad variable and the SceneToLoad variable.

        YearLevelToLoad = GameObject.Find("YearHolder").GetComponent<SelectYear>().YearLevel;
        
        SceneToLoad = "GSY" + YearLevelToLoad;
        
        Played = GameObject.Find("Setup").GetComponent<SetupHandler>().HasPlayed;

        Debug.Log("YearLevelToLoad = " + YearLevelToLoad + ". SceneToLoad = " + SceneToLoad);
        
    }
        
    
}

