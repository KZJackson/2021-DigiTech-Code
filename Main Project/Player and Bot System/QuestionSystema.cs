using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionSystem : MonoBehaviour
{
    public TMP_Text QuestionText; // TMP text in the scene, value assigned in unity inspector
    public OptionButtonSystem OptionButtonSystem; //Reference to another script
    public SubmitAnswer SubmitAnswer; //Reference to another script
    public TMP_Text TimerText; // TMP text in the scene, value assigned in unity inspector
    public GameObject[] PopupTransformVariable;
    public int CorrectAnswer;
    public int SelectedAnswer = 100000; // The '100000' assignment is placeholder value.
    public int[] Terms;
    public int[] OptionValues;
    public int CorrectID;
    public bool ShouldReset;
    public bool ShouldTrigger;
    public Coroutine TimerCo;
    public Vector3 Center;

    // Function to open and trigger the question system
    public void TriggerQuestionSystem()
    {
        GetComponent<RectTransform>().localPosition = Center;
        GenerateAddition(0,5,2);
    }

    //Generate addition question and assist in displaying it
    public void GenerateAddition(int Lower, int Upper, int QuestionLength)
    {
        QuestionText.text = "";
        Terms = new int[QuestionLength];
        for(int i = 0; i < Terms.Length; i++)
        {
            Terms[i] = Random.Range(Lower, Upper);
        }
        for (int i = 0; i < QuestionLength; i++)
        {
            CorrectAnswer = CorrectAnswer + Terms[i];
        }
        for (int i = 0; i < QuestionLength; i++)
        {
            QuestionText.text = QuestionText.text + Terms[i].ToString();
            if(i < (QuestionLength - 1))
            {
                QuestionText.text = QuestionText.text + " + ";
            }
        }
        CorrectID = Random.Range(0, 3);
        OptionValues[CorrectID] = CorrectAnswer;
        for (int i = 0; i < OptionButtonSystem.Buttons.Length; i++)
        {
           
           OptionButtonSystem.Buttons[i].GetComponent<OptionButtonSystem>().AssignValue();
           
        }
        for (int i = 0; i < OptionButtonSystem.Buttons.Length; i++)
        {
           OptionButtonSystem.Buttons[i].GetComponent<Button>().interactable = true;
        }
        TimerCo = StartCoroutine(Timer(10));
        
    }

    //Question system timer
    public IEnumerator Timer(int time)
    {
        int Counter = time;
        TimerText.text = Counter.ToString() + " Seconds Left";
        Debug.Log(Counter + " Seconds Left");
        while(Counter > 0)
        {
            yield return new WaitForSeconds(1);
            Counter--;
            Debug.Log(Counter + " Seconds Left");
            TimerText.text = Counter.ToString() + " Seconds Left";
        }
        SubmitAnswer.SubmitSelection();
    }

    //Reset the question system
    public void Reset()
    {
        QuestionText.text = "";
        TimerText.text = "";
        for (int i = 0; i < PopupTransformVariable.Length; i++)
        {
            PopupTransformVariable[i].transform.position = PopupTransformVariable[i].GetComponent<OriginalPosition>().originalPosition;
        }
        ShouldReset = true;
        ShouldReset = false;
        GetComponent<RectTransform>().localPosition = new Vector2(0, -1000);
        SelectedAnswer = 100000;
        CorrectAnswer = 0;
        for (int i = 0; i < OptionButtonSystem.Buttons.Length; i++)
        {
            OptionButtonSystem.Buttons[i].GetComponent<Image>().color = new Color32(255,255,255,255);
        }
        SelectedAnswer = 100000;
        StartCoroutine(GameObject.Find("Bot").GetComponent<BotController>().PassTurn());

        
    }
    // Start is called before the first frame update
    void Start()
    {
        Center = new Vector2(0, 0);
        OptionButtonSystem = GameObject.Find("Option2Button").GetComponent<OptionButtonSystem>();
        SubmitAnswer = GameObject.Find("GoButton").GetComponent<SubmitAnswer>();
        PopupTransformVariable = GameObject.FindGameObjectsWithTag("PopupTransformVariable");
        for (int i = 0; i < PopupTransformVariable.Length; i++)
        {
            PopupTransformVariable[i].AddComponent<OriginalPosition>();
        }
        GetComponent<RectTransform>().localPosition = new Vector2(0, -1000);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldTrigger == true)
        {
            TriggerQuestionSystem();
            ShouldTrigger = false;
        }
    }
}
