using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalPosition : MonoBehaviour
{
    // A script to do with resetting the question system. The script causes the object to reset its position when a condition is met.
    public Vector3 originalPosition;
    public QuestionSystem QuestionSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        QuestionSystem = GameObject.Find("PopupParent").GetComponent<QuestionSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(QuestionSystem.ShouldReset == true)
        {
            transform.position = originalPosition;
        }
    }
}
