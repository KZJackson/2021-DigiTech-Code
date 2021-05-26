using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectYear : MonoBehaviour
{
    public int YearLevel;


    //The below functions are attached to their corresponding buttons in-game, and are called when their respective button is clicked
    public void PickYear1(){
        YearLevel = 1;
        SceneManager.LoadScene("DiffSelect",LoadSceneMode.Single);
        Debug.Log("Difficulty Selection Screen Loaded. Year level set to " + YearLevel);
        
    }

    public void PickYear2(){
        YearLevel = 2;
        SceneManager.LoadScene("DiffSelect",LoadSceneMode.Single);
        Debug.Log("Difficulty Selection Screen Loaded. Year level set to " + YearLevel);
    }

    public void PickYear3(){
        YearLevel = 3;
        SceneManager.LoadScene("DiffSelect",LoadSceneMode.Single);
        Debug.Log("Difficulty Selection Screen Loaded. Year level set to " + YearLevel);
    }

    public void PickYear4(){
        YearLevel = 4;
        SceneManager.LoadScene("DiffSelect",LoadSceneMode.Single);
        Debug.Log("Difficulty Selection Screen Loaded. Year level set to " + YearLevel);
    }
    public void PickYear5(){
        YearLevel = 5;
        SceneManager.LoadScene("DiffSelect",LoadSceneMode.Single);
        Debug.Log("Difficulty Selection Screen Loaded. Year level set to " + YearLevel);
    }

    public void PickYear6(){
        YearLevel = 6;
        SceneManager.LoadScene("DiffSelect",LoadSceneMode.Single);
        Debug.Log("Difficulty Selection Screen Loaded. Year level set to " + YearLevel);
    }




    //Sets the year level back to zero, which is effectively no value

    public void ResetYearLevel(){
        YearLevel = 0;
        Debug.Log("Year Level Reset");
    }
}
