using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionButtonSystem : MonoBehaviour
{
    // The script managing the multi-choice option buttons


    public TMP_Text ThisButtonText; //TMP text in scene
    public QuestionSystem QuestionSystem;
    public GameObject[] Buttons;
    public int ThisOptionValue;
    public int Indicator;
    public int UpperBound;
    public int RandomValue;
    public bool HoldsCorrectAnswer;
    public bool HoldsSelectedAnswer;
    public bool ShouldResetValue;

    //Function to pick the answer, called from button
    public void PickAnswer()
    {
        QuestionSystem.SelectedAnswer = ThisOptionValue;
        Debug.Log(gameObject.name + ": Selected answer is " + ThisOptionValue);
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].GetComponent<OptionButtonSystem>().HoldsSelectedAnswer = false;
        }
        HoldsSelectedAnswer = true;
    }

    // Assigns an indicator value to the buttons for later use in discerning the buttons from one another.
    public void AssignIndicator()
    {
        for (int i = 0; i < 4; i++)
        {
            if(gameObject.name == "Option" + (i+1) + "Button")
            {
                Indicator = i;
            }
        }
        

    }

    // Function to assign the display value of the buttons
    public void AssignValue()
    {

        
        UpperBound = QuestionSystem.CorrectAnswer + 5;

        if(QuestionSystem.OptionValues[Indicator] == QuestionSystem.CorrectAnswer)
        {
            ThisOptionValue = QuestionSystem.OptionValues[Indicator];
            HoldsCorrectAnswer = true;
        }
        else
        {
            ThisOptionValue = Random.Range(0, UpperBound);
            HoldsCorrectAnswer = false;
        }
        if(ThisOptionValue == QuestionSystem.CorrectAnswer && QuestionSystem.OptionValues[Indicator] != QuestionSystem.CorrectAnswer)
        {
            AssignValue();
            
        }
        
        ThisButtonText.text = ThisOptionValue.ToString();
    }
    // Start is called before the first frame update
    void Awake()
    {

        AssignIndicator();
        ThisButtonText = transform.GetChild(0).GetComponent<TMP_Text>();
        QuestionSystem = GameObject.Find("PopupParent").GetComponent<QuestionSystem>();
        Buttons = GameObject.FindGameObjectsWithTag("Option Button");
    }

}
