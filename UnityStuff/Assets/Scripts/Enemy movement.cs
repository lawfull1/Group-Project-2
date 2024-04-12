using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(phase == 1)
        {
            velocity += speed * acceleration * Time.deltaTime;
            velocity = Vector2.ClampMagnitude(velocity, topSpeed);
            rb.velocity = velocity;
        }
        if(phase == 2)
        {
            print("phase 2 activated");
        }
    }
    private void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector2.right), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector2.right) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector2.right) * 5, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
