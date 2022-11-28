using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //creates a variable called target that we can manipulate
    public Transform target;
    //Vector3 targetPosition is a class variable and EVERY INSTANCE of this specific object will have this variable

    public float lookAhead = 0;
    public float lookAbove = 0;
    //just creates a variable for us to control. zero just steps it 

    public float smoothing = 1f;
    //creates a smooth variable. DO NOT PUT ZERO OTHERWISE CAM NO MOVE
    //if decimal, put an f. if whole number, up to u

    // Update is called once per frame
    void Update()
    {
        //THIS SPECIFIC transform refers to object the script is attached to
        //local variable is justs something that is used and then thrown away aka temporary
        //Mathf.Sign is to give the DIRECTION of a number e.g. -20 obv heading to negative so convert to -1
        //vice versa for +20
        //Mathf.Sign only has 3 outputs 1,0,-1
        Vector3 targetPosition = new Vector3(target.position.x + lookAhead * Mathf.Sign(target.localScale.x),
                target.position.y + lookAbove, transform.position.z);

        //this line is for natural camera movement e.g. when player is far cam speeds up. when player is close,
        //cam moves slower
        //aka smoothly moves camera to the destination
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothing);


    }
}
