using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitAnswer : MonoBehaviour
{
    public OptionButtonSystem OptionButtonSystem;
    public QuestionSystem QuestionSystem;
    public GameObject RightAnswerMessage;
    public GameObject WrongAnswerMessage;
    public bool IsAnswerCorrect;
    public int NumRightAnswers;
    public int NumWrongAnswers;


    public void SubmitSelection()
    {
        StopCoroutine(QuestionSystem.TimerCo);
        
        for (int i = 0; i < OptionButtonSystem.Buttons.Length; i++)
        {
           OptionButtonSystem.Buttons[i].GetComponent<Button>().interactable = false;
        }

        

        if(QuestionSystem.SelectedAnswer == QuestionSystem.CorrectAnswer)
        {
            IsAnswerCorrect = true;
            RightAnswerMessage.GetComponent<RectTransform>().localPosition = new Vector2(0, 185);
            for (int i = 0; i < OptionButtonSystem.Buttons.Length; i++)
            {
                if(OptionButtonSystem.Buttons[i].GetComponent<OptionButtonSystem>().HoldsCorrectAnswer == true)
                {
                    OptionButtonSystem.Buttons[i].GetComponent<Image>().color = new Color32(0, 217, 0, 255);
                }
            }
            NumRightAnswers++;
        }
        else
        {
            IsAnswerCorrect = false;
            WrongAnswerMessage.GetComponent<RectTransform>().localPosition = new Vector2(0, 185);
            for (int i = 0; i < OptionButtonSystem.Buttons.Length; i++)
            {
                if(OptionButtonSystem.Buttons[i].GetComponent<OptionButtonSystem>().HoldsCorrectAnswer == true)
                {
                    OptionButtonSystem.Buttons[i].GetComponent<Image>().color = new Color32(0, 217, 0, 255);
                }
                if(OptionButtonSystem.Buttons[i].GetComponent<OptionButtonSystem>().HoldsSelectedAnswer == true)
                {
                    OptionButtonSystem.Buttons[i].GetComponent<Image>().color = new Color32(217, 0, 0, 255);
                }
            }
            NumWrongAnswers++;
        }

        GameObject.Find("OkButton").GetComponent<Transform>().position = transform.position;
    }

    public void OkButton()
    {
        if(IsAnswerCorrect == true)
        {
            QuestionSystem.Reset();
        }
        if(IsAnswerCorrect == false)
        {
            GameObject.Find("SolveBoard").GetComponent<RectTransform>().position = GameObject.Find("Question Board").GetComponent<RectTransform>().position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        OptionButtonSystem = GameObject.Find("Option2Button").GetComponent<OptionButtonSystem>();
        QuestionSystem = GameObject.Find("PopupParent").GetComponent<QuestionSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
