using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionSystem : MonoBehaviour
{
    public TMP_Text QuestionText;
    public OptionButtonSystem OptionButtonSystem;
    public SubmitAnswer SubmitAnswer;
    public TMP_Text TimerText;
    public GameObject[] Children;
    public int CorrectAnswer;
    public int SelectedAnswer = 100000;
    public int[] Terms;
    public int[] OptionValues;
    public int CorrectID;
    public Coroutine TimerCo;


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
           GameObject.Find("Button" + (i+1) + "Text").GetComponent<TextMeshProUGUI>().text = "000000";
        }
        for (int i = 0; i < OptionButtonSystem.Buttons.Length; i++)
        {
           OptionButtonSystem.Buttons[i].GetComponent<Button>().interactable = true;
        }
        TimerCo = StartCoroutine(Timer(10));
        
    }

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

    public void Reset()
    {
        QuestionText.text = "";
        TimerText.text = "";

    }
    // Start is called before the first frame update
    void Start()
    {
        OptionButtonSystem = GameObject.Find("Option2Button").GetComponent<OptionButtonSystem>();
        SubmitAnswer = GameObject.Find("GoButton").GetComponent<SubmitAnswer>();
        Children = GameObject.FindGameObjectsWithTag("PopupTransformVariable");
        GenerateAddition(0, 5, 2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
