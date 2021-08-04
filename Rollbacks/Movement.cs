using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Transform[] TileList;
    public GameObject Board;
    public Vector3 HeightAboveTrack;
    public Vector3 Target;
    public int CurrentTile;
    public int RolledNumber;
    public float speed = 5;
    public bool move;
    public bool TouchingNonQuestionSquare;
    public GameObject VideoPlayer;
    public int[] PlusTwoPoints = new int[]{12, 14, 64, 112, 118, 121, 130};
    public int[] PlusFourPoints = new int[]{7, 17, 24, 48, 61, 80, 89, 143, 159};
    public int[] MinusTwoPoints = new int[]{22, 29, 40, 49, 137, 163};
    public int[] MinusFourPoints = new int[]{75, 111};
    public QuestionSystem QuestionSystem;

    

    // Start is called before the first frame update
    void Start()
    {
        HeightAboveTrack = new Vector3(0, 6, 0);
        TileList = Board.GetComponent<GetTransformData>().DataArray;
        transform.position = TileList[0].position + HeightAboveTrack;
        
    }

    IEnumerator Checker()
    {
        for (int i = 0; i < PlusTwoPoints.Length; i++)
        {
            if(CurrentTile == PlusTwoPoints[i] + 1)
            {
                Debug.Log("hit");
                StartCoroutine(MoveSpaces(2));
                TouchingNonQuestionSquare = true;
                break;

            }
        }

        for (int i = 0; i < PlusFourPoints.Length; i++)
        {
            if(CurrentTile == PlusFourPoints[i] + 1)
            {
                Debug.Log("hit");
                StartCoroutine(MoveSpaces(4));
                TouchingNonQuestionSquare = true;
                break;

            }
        }

        for (int i = 0; i < MinusTwoPoints.Length; i++)
        {
            if(CurrentTile == MinusTwoPoints[i] + 1)
            {
                Debug.Log("hit");
                StartCoroutine(MoveSpaces(-2));
                TouchingNonQuestionSquare = true;
                break;

            }
        }

        for (int i = 0; i < MinusFourPoints.Length; i++)
        {
            if(CurrentTile == MinusFourPoints[i] + 1)
            {
                Debug.Log("hit");
                StartCoroutine(MoveSpaces(-4));
                TouchingNonQuestionSquare = true;
                break;

            }
        }
        if(CurrentTile + 1 == TileList.Length)
        {
            Debug.Log("Game Finished");
            if(gameObject.name == "Player")
            {
                Debug.Log("You win");
            }
            else
            {
                Debug.Log("Enemy wins");
            }
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("FinishScene", LoadSceneMode.Single);
            yield break;
            
        }
        if(gameObject.name == "Player")
        {
            if(TouchingNonQuestionSquare == false)
            {
                QuestionSystem.ShouldTrigger = true;
            }
            else
            {
                TouchingNonQuestionSquare = false;
            }
        }
        if(gameObject.name == "Bot")
        {
            
            if(TouchingNonQuestionSquare == false)
            {
                StartCoroutine(GameObject.Find("Bot").GetComponent<BotController>().BotQuestion(0,5,2));
            }
            else
            {
                TouchingNonQuestionSquare = false;
            }
        }
        
        
        yield return null;
    }
    
    IEnumerator Delayer()
    {
        
        while(Vector3.Distance(transform.position, Target) > 0.01f)
        {

            transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(Checker());
        
        
    }

    IEnumerator MoveSpaces(int spaces)
    {
        if(spaces + CurrentTile > TileList.Length)
        {
            Debug.Log("Extra spaces.");
            spaces = TileList.Length - CurrentTile - 1;
            
        }
        yield return new WaitForSeconds(2);
        Debug.Log("Spaces set to" + spaces);
        Target = new Vector3(TileList[spaces + CurrentTile].position.x, TileList[spaces + CurrentTile].position.y + 6, TileList[spaces + CurrentTile].position.z);
        CurrentTile = CurrentTile + spaces;
        StartCoroutine(Delayer());
        VideoPlayer.GetComponent<DiceRoller>().NumberRolled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "Player")
        {
            RolledNumber = VideoPlayer.GetComponent<DiceRoller>().NumberRolled;
            move = VideoPlayer.GetComponent<DiceRoller>().ShouldMove;
            if(move == true)
            {
                StartCoroutine(MoveSpaces(RolledNumber));
                VideoPlayer.GetComponent<DiceRoller>().ShouldMove = false;
            }
        }
        else if(gameObject.name == "Bot" && GameObject.Find("Bot").GetComponent<BotController>().BotTurn == true)
        {
           RolledNumber = VideoPlayer.GetComponent<DiceRoller>().NumberRolled;
            move = VideoPlayer.GetComponent<DiceRoller>().ShouldMove;
            if(move == true)
            {
                StartCoroutine(MoveSpaces(RolledNumber));
                VideoPlayer.GetComponent<DiceRoller>().ShouldMove = false;
            } 
        }
        
        
        
        
        

    }

    
}
