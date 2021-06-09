using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectYear : MonoBehaviour
{
    // This script is a source for functions called when the user has entered a value into the input field
    //They are called from a component on the input field

    public int YearLevel;
    public int ConvertedInt;
    public string input;
    public TMP_InputField YearInputField;
    public TMP_Text ErrorPrompt;
    
    
    

    //Gets the input from the input field and converts it to an int
    public void GetYearInput(){
        input = YearInputField.text;
    }

    //Checks if response is valid
    public void CheckValid(){
        if(int.TryParse(YearInputField.text, out ConvertedInt))
        {
            Debug.Log("The converted input was " + ConvertedInt); 

            if(ConvertedInt < 7 && ConvertedInt > 0)
            {
                YearLevel = ConvertedInt;
                Debug.Log("Year Level set to " + YearLevel);
                SceneManager.LoadScene("DiffSelect", LoadSceneMode.Single);

            }

            else
            {
                ErrorPrompt.text = "Choose 1, 2, 3, 4, 5, or 6";
                Debug.Log("Number was not in range 1-6");
            }
        }
        else
        {
            ErrorPrompt.text = "Choose 1, 2, 3, 4, 5, or 6";
            Debug.Log("Invalid entry");
        }
        
        
    }

    //Clears the error prompt text
    //Error prompt is the text that shows up to tell the user that input was invalid and how to answer properly
    //Called when user starts typing in input field
    public void ClearErrorPrompt(){
        ErrorPrompt.text = "";
    }
}
