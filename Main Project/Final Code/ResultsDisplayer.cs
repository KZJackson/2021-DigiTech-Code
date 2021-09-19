using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsDisplayer : MonoBehaviour
{

    public TMP_Text WinLose;
    public TMP_Text Year;
    public TMP_Text EnemyType;
    public TMP_Text Right;
    public TMP_Text Wrong;
    public Results Results;
    public string EnemyTypeString;


    // Start is called before the first frame update
    void Start()
    {
        Results = GameObject.Find("ResultsHolder").GetComponent<Results>();
        if(Results.PlayerWins == true)
        {
            WinLose.text = GameObject.Find("Setup").GetComponent<SetupHandler>().PlayerName + " Won!!";
            WinLose.GetComponent<TextMeshProUGUI>().color = new Color32(0, 217, 0, 255);
            Year.text = "You won Numeraquest, year " + GameObject.Find("YearHolder").GetComponent<SelectYear>().YearLevel.ToString();

        }
        else
        {
            WinLose.text = "You Lost...";
            WinLose.GetComponent<TextMeshProUGUI>().color = new Color32(217, 0, 0, 255);
            Year.text = "You lost Numeraquest, year " + GameObject.Find("YearHolder").GetComponent<SelectYear>().YearLevel.ToString();
        }
        if(GameObject.Find("DiffHolder").GetComponent<DiffSelect>().difficulty == 0)
        {
            EnemyTypeString = "easy";
        }
        else if(GameObject.Find("DiffHolder").GetComponent<DiffSelect>().difficulty == 1)
        {
            EnemyTypeString = "normal";
        }
        else if(GameObject.Find("DiffHolder").GetComponent<DiffSelect>().difficulty == 2)
        {
            EnemyTypeString = "hard";
        }
        EnemyType.text = "against the " + EnemyTypeString + " enemy";
        Right.text = "You got " + GameObject.Find("ResultsHolder").GetComponent<Results>().FinalRightCount + " questions right";
        if(GameObject.Find("ResultsHolder").GetComponent<Results>().FinalRightCount == 1)
        {
            Right.text = "You got " + GameObject.Find("ResultsHolder").GetComponent<Results>().FinalRightCount + " question right";
        }
        Wrong.text = "You got " + GameObject.Find("ResultsHolder").GetComponent<Results>().FinalWrongCount + " questions wrong";
        if(GameObject.Find("ResultsHolder").GetComponent<Results>().FinalWrongCount == 1)
        {
            Wrong.text = "You got " + GameObject.Find("ResultsHolder").GetComponent<Results>().FinalWrongCount + " question wrong";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
