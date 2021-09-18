using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApp : MonoBehaviour
{
    /*This script simply contains the function the quit button will execute. 
    The function is called from the button component on the exit button.
    The script is simply a source for the function  */
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Game has quit");
    }
}
