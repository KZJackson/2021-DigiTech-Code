using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;


public class DiceRoller : MonoBehaviour
{
    public VideoClip[] Clips; //Array of dice roll animation clips
    public VideoPlayer VideoPlayer; //Reference to the VideoPlayer Object
    public GameObject RollDiceButton; //Reference to a button in the scene
    public GameObject OkReturnButton; //Reference to a button in the scene
    public RawImage VideoObject;
    public RenderTexture BlankTexture;
    public RenderTexture VideoTexture;
    public TMP_Text RollDisplay; //Reference to a text object in the scene
    public Vector2 CenterPos; //A coordinate set for the center position on the canvas
    public Vector2 OffScreenPos; //A coordinate set for a position off of the canvas
    public int RollCombination; //A variable to contain the dice combination number
    public int NumberRolled; //A variable to contain the number that was rolled
    public int[] Rolls = {2,3,4,5,6,7,3,4,5,6,7,8,4,5,6,7,8,9,5,6,7,8,9,10,6,7,8,9,10,11,7,8,9,10,11,12};
    public bool ShouldMove; //A bool to tell other script/s when to move a token
    
    
    
    //Hides and resets the Dice Roll screen
    public void HideScreen(){
        VideoPlayer.GetComponent<RectTransform>().localPosition = OffScreenPos;
        VideoPlayer.Stop();
        VideoPlayer.frame = 0;
        ShouldMove = true;
        RollDisplay.text = "";
        OkReturnButton.GetComponent<RectTransform>().localPosition = OffScreenPos;
        VideoObject.texture = BlankTexture;

    }


    public void OpenDiceRollScreen(){
        GetComponent<RectTransform>().localPosition = CenterPos;
        RollDiceButton.GetComponent<RectTransform>().localPosition = CenterPos;
    }
    
    //A coroutine to delay the rest of the code for three seconds while the animation finishes, then complete the system
    IEnumerator WaitTimer()
    {
        if(GameObject.Find("Bot").GetComponent<BotController>().BotTurn == false)
        {
            yield return new WaitForSeconds(4);
            Debug.Log("Timer Complete");
            if(NumberRolled == 8 || NumberRolled == 11)
            {
                RollDisplay.text = "You rolled an " + NumberRolled;
            }
            else
            {
                RollDisplay.text = "You rolled a " + NumberRolled;
            }
            Debug.Log("Roll Combination was " + RollCombination + ". Number rolled was " + NumberRolled);
            OkReturnButton.GetComponent<RectTransform>().localPosition = new Vector2(265, -180);
        }
        if(GameObject.Find("Bot").GetComponent<BotController>().BotTurn == true)
        {
            yield return new WaitForSeconds(4);
            Debug.Log("Timer Complete");
            if(NumberRolled == 8 || NumberRolled == 11)
            {
                RollDisplay.text = "Enemy rolled an " + NumberRolled;
            }
            else
            {
                RollDisplay.text = "Enemy rolled a " + NumberRolled;
            }
            Debug.Log("Roll Combination was " + RollCombination + ". Number rolled was " + NumberRolled);
            yield return new WaitForSeconds(2);
            HideScreen();
        }

    }

    //The function to 'roll the dice'
    //Called when the roll dice button is clicked
    /*Decides randomly which animation to play, then figures out which number that animation represents
    and displays that number with text on the screen*/

    public void RollDice(){
        VideoPlayer.frame = 0;
        OkReturnButton.GetComponent<RectTransform>().localPosition = OffScreenPos;
        RollDiceButton.GetComponent<RectTransform>().localPosition = OffScreenPos;
        RollCombination = Random.Range(0,36);
        VideoPlayer.clip = Clips[RollCombination];
        NumberRolled = Rolls[RollCombination];
        VideoPlayer.Play();
        StartCoroutine(WaitTimer());
        VideoObject.texture = VideoTexture;
        
        



        
    }

    
    //Start is called before the first frame update
    void Start()
    {
        VideoPlayer.clip = Clips[0];
        VideoPlayer.frame = 0;
        VideoPlayer.Stop();
        CenterPos = new Vector2(0,0);
        OffScreenPos = new Vector2(0,500);
        OkReturnButton.GetComponent<RectTransform>().localPosition = OffScreenPos;
        RollDiceButton.GetComponent<RectTransform>().localPosition = CenterPos;
        VideoObject.texture = BlankTexture;
        
    }

    
    
}
