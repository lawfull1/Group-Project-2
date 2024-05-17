using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atak : MonoBehaviour
{
    private SpriteRenderer eniSpr;
    RaycastHit2D rayCast1;
    RaycastHit2D rayCast;
    public Vector2 speed;
    public float topSpeed;
    public float acceleration;
    private Vector2 velocity;
    public LayerMask payer;
    public BoxCollider2D Player;
    public BoxCollider2D eniBox;
    private Rigidbody2D rb;
    public Transform eni;

    public BoxCollider2D PlayerPunc;
    public Transform punc;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        eniSpr = GetComponentInChildren<SpriteRenderer>();
        punc = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerPunc = punc.GetChild(0).GetComponent<BoxCollider2D>();
        eni = gameObject.transform;
        eniBox = eni.GetChild(0).GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        
        rayCast = Physics2D.Raycast(transform.position + (new Vector3(0, 0.5f)), -Vector2.right, 50, payer);
        rayCast1 = Physics2D.Raycast(transform.position + (new Vector3(0, 0.5f)), Vector2.right, 50, payer);
        Debug.DrawRay(transform.position + (new Vector3(0, 0.5f)), -Vector2.right * 100, Color.yellow);
        if (rayCast.distance >= 1 || rayCast1.distance >= 1)
        {
            
            if (rayCast.collider == Player || rayCast.collider == PlayerPunc)
            {
                velocity += speed * acceleration * Time.deltaTime;
                velocity = Vector2.ClampMagnitude(velocity, topSpeed);
                rb.velocity = velocity;
                eniSpr.flipX = false;
                eniBox.transform.localPosition = new Vector2(-1, 0);
                
            }
            else if (rayCast1.collider == Player || rayCast1.collider == PlayerPunc)
            {
                velocity += speed * acceleration * Time.deltaTime;
                velocity = Vector2.ClampMagnitude(velocity, topSpeed);
                rb.velocity = -velocity;
                eniSpr.flipX = true;
                eniBox.transform.localPosition = new Vector2(1, 0);
            }

        }
        else if (rayCast.distance <= 1 || rayCast1.distance <= 1)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

}
