using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class FolowChar : MonoBehaviour
{
    //what we are following
    public Transform target;

    //zeros out velocity
    Vector3 velocity = Vector3.zero;

    //time to follow target
    public float flowieTime;

    private Scene curScn;
    public GameObject Enime;
    public GameObject player;
    private float dis;

    public PixelPerfectCamera pix;

    private void Start()
    {
        curScn = SceneManager.GetActiveScene();
        pix = GetComponent<PixelPerfectCamera>();
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
            float dis =  Mathf.Abs(Enime.transform.position.x - player.transform.position.x);
            Debug.Log(dis);
            pix.assetsPPU = Mathf.RoundToInt(-dis+53);
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
