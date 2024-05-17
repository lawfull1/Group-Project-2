using UnityEngine;
using UnityEngine.SceneManagement;

public class FolowChar : MonoBehaviour
{
    //what we are following
    public Transform target;

    //zeros out velocity
    Vector3 velocity = Vector3.zero;

    //time to follow target
    public float flowieTime;

    private Scene curScn;


    private void Start()
    {
        curScn = SceneManager.GetActiveScene();
    }

    void FixedUpdate()
    {
        Vector3 targetPos = target.position;
        //align the camera and the target z position

        if (curScn.buildIndex == 1)
        {
            targetPos.y = 0;
            targetPos.z = -10;
            if (targetPos.x > -2 && transform.position.x < 57)
            {
                targetPos.x = target.position.x;
            }
            else if (targetPos.x < -2)
            {
                targetPos.x = -2;
            }
            else if (targetPos.x > 57)
            {
                targetPos.x = 57;
            }


        }
        else if (curScn.buildIndex == 2)
        {
            targetPos.z = -10;
            if (targetPos.x > 2 && transform.position.x < 19)
            {
                targetPos.x = target.position.x;
            }
            else if (targetPos.x < 2)
            {
                targetPos.x = 2;
            }
            else if (targetPos.x > 19)
            {
                targetPos.x = 19;
            }
            if(targetPos.y < -3.5f)
            {
                targetPos.y = -3.5f;
            }else{
                targetPos.y = target.position.y;
            }

        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, flowieTime);
    }
}
