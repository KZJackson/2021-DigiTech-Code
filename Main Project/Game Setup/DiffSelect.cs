using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiffSelect : MonoBehaviour
{
    //int variable to hold difficulty (1 = easy, 2 = normal, 3 = hard)
    public int difficulty;
    
    //The below functions are called from their respective buttons, which don't use scripting to call them (it is built in to unity)
    

    //sets year level to easy
    public void PickEasy(){
        difficulty = 1;
        Debug.Log("Difficulty set to Easy");
        SceneManager.LoadScene("SetupScreen", LoadSceneMode.Single);
    }

    //sets year level to normal
    public void PickNormal(){
        difficulty = 2;
        Debug.Log("Difficulty set to Normal");
        SceneManager.LoadScene("SetupScreen", LoadSceneMode.Single);
    }

    //sets year level to hard
    public void PickHard(){
        difficulty = 3;
        Debug.Log("Difficulty set to Hard");
        SceneManager.LoadScene("SetupScreen", LoadSceneMode.Single);
    }
}
