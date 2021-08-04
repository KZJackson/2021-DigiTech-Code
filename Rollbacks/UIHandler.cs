using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{   
    public TMP_Text RightQuestionsCount;
    public TMP_Text WrongQuestionsCount;
    public TMP_Text BotPlacement;
    public TMP_Text BotPlacementLowerText;
    public Movement Player;
    public Movement Bot;
    public SubmitAnswer SubmitAnswer;
    public int SpacesDifference;
    // Start is called before the first frame update
    void Start()
    {
        SubmitAnswer = GameObject.Find("GoButton").GetComponent<SubmitAnswer>();
        Player = GameObject.Find("Player").GetComponent<Movement>();
        Bot = GameObject.Find("Bot").GetComponent<Movement>();
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
        }
        BotPlacement.text = SpacesDifference.ToString();
    }
}
