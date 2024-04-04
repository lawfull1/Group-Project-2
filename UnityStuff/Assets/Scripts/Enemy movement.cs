using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    Rigidbody2D rb;

    float moveVelocity;
    public float speed;
    public float topSpeed;
    Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = transform.right * -speed;
        rb.AddForce(move * Time.deltaTime);
        velocity = Vector2.ClampMagnitude(topSpeed);
    }
    private void FixedUpdate()
    {
       
    }
}
