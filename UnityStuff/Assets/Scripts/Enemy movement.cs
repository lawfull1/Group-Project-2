using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.Build.Content;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    private Rigidbody2D rb;

    float moveVelocity;
    public Vector2 speed;
    public float topSpeed;
    public float acceleration;
    private Vector2 velocity;
    private int phase = 1;
    public LayerMask payer;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 1)
        {
            return;
        }
        if (phase == 2)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector2.right), out hit, 5, payer))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * hit.distance, Color.yellow);
                velocity += speed * acceleration * Time.deltaTime;
                velocity = Vector2.ClampMagnitude(velocity, topSpeed);
                rb.velocity = velocity;

            }
        }

    }
}
/*
 * Player Animations
 * 0 = idle
 * 1 = walk
 * 2 = run
 * 3 = jump
 * 4 = punch
 * 5 = dropkick
 * 6 = puffy_ACV
 * 7 = puffy_DACV
 * 8 = HPunch
 * 9
 * 10
 * 11
 * 12
 * 13
 * 14
 * 15
 * <------------------------->
 * Enemy Animations
 * 1
 * 2
 * 3
 * 4
 * 5
 * 6
 * 7
 * 8
 * 9
 * 10
 * 11
 * 12
 * 13
 * 14
 * 15
 * <Health Bar>
 * 
 * 
 * 
 */

