using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Results : MonoBehaviour
{

    public float FinalStarScore;
    public int FinalRightCount;
    public int FinalWrongCount;
    public bool PlayerWins;
    public UIHandler UIHandler;
    public SubmitAnswer SubmitAnswer; // Reference to a script

    // Function to collect the results of the game and bring them into one script for displaying in the next scene
    public void CollectResults(bool YouWin)
    {
        FinalStarScore = UIHandler.StarScore;
        FinalRightCount = SubmitAnswer.NumRightAnswers;
        FinalWrongCount = SubmitAnswer.NumWrongAnswers;
        PlayerWins = YouWin;
    }
}
