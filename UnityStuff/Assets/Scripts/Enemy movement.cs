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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity += speed * acceleration * Time.deltaTime;
        velocity = Vector2.ClampMagnitude(velocity, topSpeed);
        rb.velocity = velocity;
    }
    private void FixedUpdate()
    {
       
    }
}
