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
        int year = GameObject.Find("YearHolder").GetComponent<SelectYear>().YearLevel;
        int randomizer = 0;
        if(year == 1)
        {
            GenerateAddition(0,5,2);
        }
        if(year == 2)
        {
            randomizer = Random.Range(0, 1);
            if(randomizer == 0)
            {
                GenerateAddition(0,7,3);
            }
            if(randomizer == 1)
            {
                GenerateSubtraction(5);
            }
        }
        if(year == 3)
        {
            randomizer = Random.Range(0, 2);
            if(randomizer == 0)
            {
                GenerateAddition(0,15,2);
            }
            if(randomizer == 1)
            {
                GenerateSubtraction(20);
            }
            if(randomizer == 2)
            {
                GenerateMultiplication(0,10,2);
            }
        }
        if(year == 4)
        {
            randomizer = Random.Range(0, 3);
            if(randomizer == 0)
            {
                GenerateAddition(0,15,3);
            }
            if(randomizer == 1)
            {
                GenerateSubtraction(50);
            }
            if(randomizer == 2)
            {
                GenerateMultiplication(0,12,2);
            }
            if(randomizer == 3)
            {
                GenerateDivision(0, 30);
            }
        }
        if(year == 5)
        {
            randomizer = Random.Range(0, 3);
            if(randomizer == 0)
            {
                GenerateAddition(0,50,2);
            }
            if(randomizer == 1)
            {
                GenerateSubtraction(70);
            }
            if(randomizer == 2)
            {
                GenerateMultiplication(0,12,2);
            }
            if(randomizer == 3)
            {
                GenerateDivision(0, 50);
            }
        }
        if(year == 6)
        {
            randomizer = Random.Range(0, 3);
            if(randomizer == 0)
            {
                GenerateAddition(0,100,2);
            }
            if(randomizer == 1)
            {
                GenerateSubtraction(100);
            }
            if(randomizer == 2)
            {
                GenerateMultiplication(0,12,2);
            }
            if(randomizer == 3)
            {
                GenerateDivision(0, 60);
            }
        }
        
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
        SubmitAnswer.Type = "Add";
    }
    public void GenerateSubtraction(int Midpoint)
    {
        QuestionText.text = "";
        Terms = new int[2];
        Terms[1] = Random.Range(0, Midpoint);
        Terms[0] = Random.Range(Midpoint, Midpoint * 2);
        CorrectAnswer = Terms[0] - Terms[1];
        for (int i = 0; i < 2; i++)
        {
            QuestionText.text = QuestionText.text + Terms[i].ToString();
            if(i < (2 - 1))
            {
                QuestionText.text = QuestionText.text + " - ";
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
        SubmitAnswer.Type = "Sub";
        
    }
    public void GenerateMultiplication(int Lower, int Upper, int QuestionLength)
    {
        CorrectAnswer = 1;
        QuestionText.text = "";
        Terms = new int[QuestionLength];
        for(int i = 0; i < Terms.Length; i++)
        {
            Terms[i] = Random.Range(Lower, Upper);
        }
        for (int i = 0; i < QuestionLength; i++)
        {
            CorrectAnswer = CorrectAnswer * Terms[i];
        }
        for (int i = 0; i < QuestionLength; i++)
        {
            QuestionText.text = QuestionText.text + Terms[i].ToString();
            if(i < (QuestionLength - 1))
            {
                QuestionText.text = QuestionText.text + " x ";
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
        SubmitAnswer.Type = "Mult";
    }
    public void GenerateDivision(int Lower, int Upper)
    {
        int Dividend = 0;
        int Divisor = 0;
        float Quotient = 0;
        do
        {
            Dividend = Random.Range(Lower, Upper);
            Divisor = Random.Range(Lower, Upper);
            while(Dividend == 0 && Divisor == 0)
            {
                Dividend = Random.Range(Lower, Upper);
                Divisor = Random.Range(Lower, Upper);
            }
            if((Dividend % Divisor) == 0)
            {
                Quotient = Dividend / Divisor;
            }
        }while ((Dividend % Divisor) != 0);
        QuestionText.text = "";
        Terms = new int[2];
        Terms[0] = Dividend;
        Terms[1] = Divisor;
        CorrectAnswer = Dividend / Divisor;
        for (int i = 0; i < 2; i++)
        {
            QuestionText.text = QuestionText.text + Terms[i].ToString();
            if(i < (2 - 1))
            {
                QuestionText.text = QuestionText.text + " ÷ ";
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
        SubmitAnswer.Type = "Div";
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
