using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BotController : MonoBehaviour
{
    public bool BotTurn;
    public bool PickedCorrectAnswer;
    public int[] Terms;
    public float[] Frequencies;
    public float Randomizer;
    public int CorrectAnswer;
    public int BotAnswer;
    public int Difficulty;
    public int UpperBound;
    public DiceRoller DiceRoller;
    public TMP_Text TurnText; // Reference to TextMeshPro object in the scene. Value assigned in the Unity inspector 
    public TMP_Text BotQuestionText; // Reference to TextMeshPro object in the scene. Value assigned in the Unity inspector 
    public TMP_Text BotAnswerText; // Reference to TextMeshPro object in the scene. Value assigned in the Unity inspector 
    public TMP_Text BotTimerText; // Reference to TextMeshPro object in the scene. Value assigned in the Unity inspector 
    public RectTransform TurnTextRT;
    public RectTransform BotPopupParentRT;
    public GameObject BotRightMessage; //Reference to the message saying the bot got it right. Value assigned in the Unity inspector 
    public GameObject BotWrongMessage; //Reference to the message saying the bot got it wrong. Value assigned in the Unity inspector 
    public Coroutine BotTimerCo;

    //passes turn between player and bot (enemy)
    public IEnumerator PassTurn()
    {
        
        BotTurn = !BotTurn;
        Debug.Log("BotTurn : " + BotTurn);
        if(BotTurn == true)
        {   TurnText.text = "Enemy's Turn";
            TurnTextRT.localPosition = new Vector2(0, 155);
            yield return new WaitForSeconds(3);
            TurnTextRT.localPosition = new Vector2(0, 300);
            if(PickedCorrectAnswer == true)
            {
                DiceRoller.OpenDiceRollScreen();
                DiceRoller.RollDice();
            }
            else
            {
                StartCoroutine(BotQuestion());
            }
              
        }
        if(BotTurn == false)
        {
            TurnText.text = "Your Turn";
            TurnTextRT.localPosition = new Vector2(0, 155);
            yield return new WaitForSeconds(3);
            TurnTextRT.localPosition = new Vector2(0, 300);
            if(GameObject.Find("GoButton").GetComponent<SubmitAnswer>().IsAnswerCorrect == true)
            {
                DiceRoller.OpenDiceRollScreen();
            }
            else
            {
                GameObject.Find("PopupParent").GetComponent<QuestionSystem>().TriggerQuestionSystem();
            }
        }
    }
    
    // Generates an addition question for the enemy, decides if it will get it right or not, and manage the display
    public IEnumerator BotQuestion()
    {
        BotAnswerText.text = "";
        CorrectAnswer = 0;
        BotRightMessage.GetComponent<RectTransform>().localPosition = new Vector2(0, -2100);
        BotWrongMessage.GetComponent<RectTransform>().localPosition = new Vector2(0, -2100);
        BotQuestionText.text = "";
        BotPopupParentRT.localPosition = new Vector2(0, 0);
        int year = GameObject.Find("YearHolder").GetComponent<SelectYear>().YearLevel;
        int randomizer = 0;
        if(year == 1)
        {
            BotAdd(0,5,2);
        }
        if(year == 2)
        {
            randomizer = Random.Range(0, 1);
            if(randomizer == 0)
            {
                BotAdd(0,7,3);
            }
            if(randomizer == 1)
            {
                BotSub(5);
            }
        }
        if(year == 3)
        {
            randomizer = Random.Range(0, 2);
            if(randomizer == 0)
            {
                BotAdd(0,15,2);
            }
            if(randomizer == 1)
            {
                BotSub(20);
            }
            if(randomizer == 2)
            {
                BotMult(0,10,2);
            }
        }
        if(year == 4)
        {
            randomizer = Random.Range(0, 3);
            if(randomizer == 0)
            {
                BotAdd(0,15,3);
            }
            if(randomizer == 1)
            {
                BotSub(50);
            }
            if(randomizer == 2)
            {
                BotMult(0,12,2);
            }
            if(randomizer == 3)
            {
                BotDiv(0, 30);
            }
        }
        if(year == 5)
        {
            randomizer = Random.Range(0, 3);
            if(randomizer == 0)
            {
                BotAdd(0,50,2);
            }
            if(randomizer == 1)
            {
                BotSub(70);
            }
            if(randomizer == 2)
            {
                BotMult(0,12,2);
            }
            if(randomizer == 3)
            {
                BotDiv(0, 50);
            }
        }
        if(year == 6)
        {
            randomizer = Random.Range(0, 3);
            if(randomizer == 0)
            {
                BotAdd(0,100,2);
            }
            if(randomizer == 1)
            {
                BotSub(100);
            }
            if(randomizer == 2)
            {
                BotMult(0,12,2);
            }
            if(randomizer == 3)
            {
                BotDiv(0, 60);
            }
        }
        BotTimerCo = StartCoroutine(BotTimer(10));
        yield return new WaitForSeconds(Random.Range(3, 8));
        Randomizer = Random.Range(0, 100);
        if(Randomizer <= Frequencies[Difficulty])
        {
            BotAnswer = CorrectAnswer;
            PickedCorrectAnswer = true;
            StopCoroutine(BotTimerCo);
            BotRightMessage.GetComponent<RectTransform>().localPosition = new Vector2(0, 1530);

        }
        else
        {
            BotAnswer = Random.Range(0, UpperBound);
            while(BotAnswer == CorrectAnswer)
            {
                BotAnswer = Random.Range(0, UpperBound);
            }
            PickedCorrectAnswer = false;
            StopCoroutine(BotTimerCo);
            BotWrongMessage.GetComponent<RectTransform>().localPosition = new Vector2(0, 1530);
        }
        BotAnswerText.text = BotAnswer.ToString();
        yield return new WaitForSeconds(2);
        BotPopupParentRT.localPosition = new Vector2(0, 1000);
        StartCoroutine(PassTurn());
        

        yield return null;
    }

    public void BotAdd(int Lower, int Upper, int QuestionLength)
    {
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
            BotQuestionText.text = BotQuestionText.text + Terms[i].ToString();
            if(i < (QuestionLength - 1))
            {
                BotQuestionText.text = BotQuestionText.text + " + ";
            }
        }
        UpperBound = CorrectAnswer + 5;
    }
    public void BotSub(int Midpoint)
    {
        Terms = new int[2];
        Terms[1] = Random.Range(0, Midpoint);
        Terms[0] = Random.Range(Midpoint, Midpoint * 2);
        CorrectAnswer = Terms[0] - Terms[1];
        for (int i = 0; i < 2; i++)
        {
            BotQuestionText.text = BotQuestionText.text + Terms[i].ToString();
            if(i < (2 - 1))
            {
                BotQuestionText.text = BotQuestionText.text + " - ";
            }
        }
    }
    public void BotMult(int Lower, int Upper, int QuestionLength)
    {
        CorrectAnswer = 1;
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
            BotQuestionText.text = BotQuestionText.text + Terms[i].ToString();
            if(i < (QuestionLength - 1))
            {
                BotQuestionText.text = BotQuestionText.text + " x ";
            }
        }
    }
    public void BotDiv(int Lower, int Upper)
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
        Terms = new int[2];
        Terms[0] = Dividend;
        Terms[1] = Divisor;
        CorrectAnswer = Dividend / Divisor;
        for (int i = 0; i < 2; i++)
        {
            BotQuestionText.text = BotQuestionText.text + Terms[i].ToString();
            if(i < (2 - 1))
            {
                BotQuestionText.text = BotQuestionText.text + " ÷ ";
            }
        }
    }
    //Timer for the bot question system
    public IEnumerator BotTimer(int time)
    {
        int Counter = time;
        BotTimerText.text = Counter.ToString() + " Seconds Left";
        Debug.Log(Counter + " Seconds Left");
        while(Counter > 0)
        {
            yield return new WaitForSeconds(1);
            Counter--;
            Debug.Log(Counter + " Seconds Left");
            BotTimerText.text = Counter.ToString() + " Seconds Left";
        }
        
    }
        
    // Start is called before the first frame update
    void Start()
    {   
        // using start for variable assignment
        PickedCorrectAnswer = true;
        TurnTextRT = TurnText.GetComponent<RectTransform>();
        TurnTextRT.localPosition = new Vector2(0, 300);
        BotPopupParentRT = GameObject.Find("BotPopupParent").GetComponent<RectTransform>();
        BotPopupParentRT.localPosition = new Vector2(0, 1000);
        BotAnswerText.text = "";
        Difficulty = GameObject.Find("DiffHolder").GetComponent<DiffSelect>().difficulty;
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
