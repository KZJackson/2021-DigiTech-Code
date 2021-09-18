using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{   
    // The managing script of the permanent UI

    public TMP_Text RightQuestionsCount;
    public TMP_Text WrongQuestionsCount;
    public TMP_Text BotPlacement;
    public TMP_Text BotPlacementLowerText;
    public Movement Player;
    public Movement Bot;
    public SubmitAnswer SubmitAnswer;
    public Transform[] Stars;
    public int SpacesDifference;
    public int TotalQuestions;
    public float StarScore;
    
    // Start is called before the first frame update
    void Start()
    {
        SubmitAnswer = GameObject.Find("GoButton").GetComponent<SubmitAnswer>();
        Player = GameObject.Find("Player").GetComponent<Movement>();
        Bot = GameObject.Find("Bot").GetComponent<Movement>();
        Stars = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Stars[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RightQuestionsCount.text = SubmitAnswer.NumRightAnswers.ToString();
        WrongQuestionsCount.text = SubmitAnswer.NumWrongAnswers.ToString();
        SpacesDifference = Player.CurrentTile - Bot.CurrentTile;
        if(SpacesDifference < 0)
        {
            BotPlacementLowerText.text = "Spaces Ahead Of You";
            SpacesDifference = SpacesDifference * -1;
            if(SpacesDifference == 1)
            {
                BotPlacementLowerText.text = "Space Ahead Of You";
            }
        }
        else
        {
            BotPlacementLowerText.text = "Spaces Behind You";
            if(SpacesDifference == 1)
            {
                BotPlacementLowerText.text = "Space Behind You";
            }
        }
        BotPlacement.text = SpacesDifference.ToString();
        TotalQuestions = SubmitAnswer.NumRightAnswers + SubmitAnswer.NumWrongAnswers;
        if(TotalQuestions == 0)
        {
            StarScore = 0;
        }
        else
        {
            StarScore = Mathf.Floor(((float)SubmitAnswer.NumRightAnswers / (float)TotalQuestions) * 10);
            for (int i = 0; i < transform.childCount; i++)
            {
                Stars[i].transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            for (int i = 0; i < StarScore; i++)
            {
               Stars[i].transform.GetComponent<Image>().color = new Color32(255, 255, 0, 255); 
            }
        }
        
    }
}
