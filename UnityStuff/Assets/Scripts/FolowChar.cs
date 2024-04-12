using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowChar : MonoBehaviour
{
    //what we are following
    public Transform target;

    //zeros out velocity
    Vector3 velocity = Vector3.zero;

    //time to follow target
    public float flowieTime;


    void FixedUpdate()
    {
        Vector3 targetPos = target.position;

        //align the camera and the target z position
        targetPos.z = -10;
        if(targetPos.x > -2 && transform.position.x < 57)
        {
            targetPos.x = target.position.x;
        }else if(targetPos.x < -2)
        {
            targetPos.x = -2;
        }else if (targetPos.x > 57)
        {
            targetPos.x = 57;
        }

            targetPos.y = 0;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, flowieTime);
    }
}
