using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    //The scene handler script contains a function to load each scene that may need to be loaded from a button
    //A function can be called from a button component if necessary, using the button (not scripting)

      public void TitleScreen(){
       SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
       Debug.Log("Title Screen Loaded");
    }
       
      public void YearSelectScreen(){
       SceneManager.LoadScene("YearSelect", LoadSceneMode.Single);
       Debug.Log("Year Selection Screen Loaded");
    }
      
      public void HowToPlayScreen(){
       SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
       Debug.Log("How To Play Screen Loaded");
    }
      public void DiffSelectScreen(){
        SceneManager.LoadScene("DiffSelect", LoadSceneMode.Single);
        Debug.Log("DiffSelect Screen Loaded");
    }


    public void PlayAgain()
    {
      SceneManager.LoadScene("GSY" + GameObject.Find("YearHolder").GetComponent<SelectYear>().YearLevel);
    }
   
}
