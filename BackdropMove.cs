using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdropMove : MonoBehaviour
{ 
    public Vector2 NewPos;
    public Vector2 CurrentPos;
    public float speed;
    public float step;
    public float distance;
    

    //NewPos is the new position the backdrop should move to. CurrentPos is the current position of the gameObject.
    //Speed is a variable to change step size
    //Step is the distance to move each time the moveStep function is called (the variable is defined in the start function)
    //distance is the distance between CurrentPos and NewPos, and is defined in the moveStep function. moveStep is called in Update
    
    //This function moves the backdrop a small distance towards NewPos. The distance moved is the 'step' variable
    
    
    public void moveStep(){
        
        /*Gets the current position of the backdrop, moves towards NewPos by one 'step',
        gets the distance to NewPos, and checks if the distance is less than 2
        (checking if the distance was zero, i.e. exactly at NewPos caused bugs)
        if the distance is less then 2, NewPos is randomly reassigned */

       CurrentPos = transform.position;
       transform.position = Vector2.MoveTowards(CurrentPos, NewPos, step);
       distance = Vector2.Distance(CurrentPos, NewPos);
       if(distance < 2)
        {
            SetNewPos();
        }
    }

    public void SetNewPos(){
        //Assigns the NewPos variable a random position
        NewPos = new Vector2(Random.Range(-500,500) , Random.Range(-500,500));
    }





    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        step = speed * Time.deltaTime;
        CurrentPos = transform.position;
        SetNewPos();
    }
        
    

    // Update is called once per frame
    void Update()
    {
        moveStep();
    }
}
