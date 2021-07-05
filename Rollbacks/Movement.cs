using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform[] TileList;
    public GameObject Board;
    public Vector3 HeightAboveTrack;
    public Vector3 Target;
    public Quaternion rotation;
    public int CurrentTile;
    public int RolledNumber;
    public float speed = 5;
    public bool move;
    public GameObject VideoPlayer;
    public int[] PlusTwoPoints = new int[]{12, 14, 64, 112, 118, 121, 130};
    public int[] PlusFourPoints = new int[]{7, 17, 24, 48, 61, 80, 89, 143, 159};
    public int[] MinusTwoPoints = new int[]{22, 29, 40, 49, 137, 163};
    public int[] MinusFourPoints = new int[]{75, 111};
    public bool touching;

    

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
                break;

            }
        }

        for (int i = 0; i < PlusFourPoints.Length; i++)
        {
            if(CurrentTile == PlusFourPoints[i] + 1)
            {
                Debug.Log("hit");
                StartCoroutine(MoveSpaces(4));
                break;

            }
        }

        for (int i = 0; i < MinusTwoPoints.Length; i++)
        {
            if(CurrentTile == MinusTwoPoints[i] + 1)
            {
                Debug.Log("hit");
                StartCoroutine(MoveSpaces(-2));
                break;

            }
        }

        for (int i = 0; i < MinusFourPoints.Length; i++)
        {
            if(CurrentTile == MinusFourPoints[i] + 1)
            {
                Debug.Log("hit");
                StartCoroutine(MoveSpaces(-4));
                break;

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
        rotation = new Quaternion(0, TileList[CurrentTile].transform.rotation.y, 0, 0);
        transform.rotation = rotation;
        StartCoroutine(Checker());
        
        
    }

    IEnumerator MoveSpaces(int spaces)
    {
        yield return new WaitForSeconds(2);
        Target = new Vector3(TileList[spaces + CurrentTile].position.x, TileList[spaces + CurrentTile].position.y + 6, TileList[spaces + CurrentTile].position.z);
        CurrentTile = CurrentTile + spaces;
        StartCoroutine(Delayer());
        VideoPlayer.GetComponent<DiceRoller>().NumberRolled = 0;
    }

    // Update is called once per frame
    void Update()
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
