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
    public TMP_Text TurnText;
    public TMP_Text BotQuestionText;
    public TMP_Text BotAnswerText;
    public TMP_Text BotTimerText;
    public RectTransform TurnTextRT;
    public RectTransform BotPopupParentRT;
    public GameObject BotRightMessage;
    public GameObject BotWrongMessage;
    public Coroutine BotTimerCo;

    public IEnumerator PassTurn()
    {
        
        BotTurn = !BotTurn;
        Debug.Log("BotTurn : " + BotTurn);
        if(BotTurn == true)
        {   TurnText.text = "Enemy's Turn";
            TurnTextRT.localPosition = new Vector2(0, 170);
            yield return new WaitForSeconds(3);
            TurnTextRT.localPosition = new Vector2(0, 300);
            if(PickedCorrectAnswer == true)
            {
                DiceRoller.OpenDiceRollScreen();
                DiceRoller.RollDice();
            }
            else
            {
                StartCoroutine(BotQuestion(0, 5, 2));
            }
              
        }
        if(BotTurn == false)
        {
            TurnText.text = "Your Turn";
            TurnTextRT.localPosition = new Vector2(0, 170);
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
    public IEnumerator BotQuestion(int Lower, int Upper, int QuestionLength)
    {
        BotAnswerText.text = "";
        CorrectAnswer = 0;
        BotRightMessage.GetComponent<RectTransform>().localPosition = new Vector2(0, -2100);
        BotWrongMessage.GetComponent<RectTransform>().localPosition = new Vector2(0, -2100);
        BotQuestionText.text = "";
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
        BotPopupParentRT.localPosition = new Vector2(0, 0);
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
