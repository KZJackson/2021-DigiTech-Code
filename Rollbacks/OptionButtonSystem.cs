using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionButtonSystem : MonoBehaviour
{
    public TMP_Text ThisButtonText;
    public QuestionSystem QuestionSystem;
    public GameObject[] Buttons;
    public int ThisOptionValue;
    public int Indicator;
    public int UpperBound;
    public int RandomValue;
    public bool HoldsCorrectAnswer;
    public bool HoldsSelectedAnswer;

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
        for (int i = 0; i < Buttons.Length; i++)
        {
            if(ThisOptionValue == Buttons[i].GetComponent<OptionButtonSystem>().ThisOptionValue && Indicator != i)
            {
                AssignValue();
            }
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

    // Update is called once per frame
    void Update()
    {   
        if(ThisButtonText.text == "000000")
        {
            AssignValue();
        }
    }
}
