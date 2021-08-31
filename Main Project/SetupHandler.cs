using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SetupHandler : MonoBehaviour
{
    /* The setup handler is a source for the function that gets the player's name.
    It is also a source for the function that gets their response about whether or not they have played before
    and the function that checks if that is a valid response.
    These functions are called from conditions attached to the input fields. */




    public string PlayerName;
    public string[] AcceptedResponses = {"Yes", "yes", "No", "no"}; //More values can be added if necessary
    public string YesNo;
    public bool IsAccepted;
    public bool HasPlayed;
    public bool NameEntered;
    public TMP_InputField PlayedBeforeResponse;
    public TMP_InputField NameBox;
    

    
    //Gets the text input from the name input field, and assigns it to the PlayerName variable
    //Function is called from the 'On Edit End' section in the input field, when the player clicks out of the input field
    public void GetNameInput(string NameInput){
        string spacesremoved = NameInput;
        if(spacesremoved.Replace(" ", "") == "")
        {
            NameBox.text = "Write your name";
            NameEntered  = false;
        }
        else
        {
            PlayerName = NameInput;
            Debug.Log("Your name is " + PlayerName);
            NameEntered = true;
        }
        
    }

    //Gets the text input from the Yes/No input field, and assigns it to the YesNo variable
    //Function is called from the 'On Edit End' component in the input field
    public void GetYesNoInput(string Input){
        YesNo = Input;
        Debug.Log(YesNo);
    }


    //Checks if the response to 'have you played numeraquest before' is a valid yes or no
    public void CheckInput(){
        for(int i = 0; i < AcceptedResponses.Length; i++)
        {
            if(YesNo == AcceptedResponses[i])
            {
                IsAccepted = true;
                break;
            }
        }

        if(IsAccepted == true)
        {
            if(YesNo == AcceptedResponses[0] || YesNo == AcceptedResponses[1])
            {
                
                Debug.Log("Response was " + YesNo + ". Response met expected values.");
                HasPlayed = true;
            }
            
            else
            {
                if(NameEntered == true)
                {
                    SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
                    Debug.Log("Response was " + YesNo + ". Response met expected values. How to Play screen loaded");
                    HasPlayed = false;
                }
                
                
            }
            
        }

        else
        {
            PlayedBeforeResponse.text = "Please say Yes or No";
        }

    }

}
