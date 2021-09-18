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
    

    //NewPos will be the new position the backdrop should move to. CurrentPos will be the current position of the gameObject.
    //Speed will be a variable to change step size
    //Step is the distance to move each time the moveStep function is called (step is defined in the start function)
    //distance is the distance between CurrentPos and NewPos, and is defined in the moveStep function. moveStep is called in Update


    
    //moveStep moves the backdrop a small distance towards NewPos. The distance moved is the 'step' variable
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

    //SetNewPos assigns the NewPos variable a random position
    public void SetNewPos(){
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
