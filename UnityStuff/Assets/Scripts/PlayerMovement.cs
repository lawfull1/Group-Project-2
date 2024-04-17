using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //important
    private bool boogie = true;
    private float flowie = 10f;
    //Movement
    public float speed;
    public float jump;
    float moveVelocity;
    public Rigidbody2D rb;
    //Grounded Vars
    bool isGrounded = true;
    // Update is called once per frame
    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }
        if(boogie == true)
        {
            flowie += speed;
        }
        moveVelocity = Input.GetAxisRaw("Horizontal") * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }
    //Check if Grounded
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Ground")
        {
            isGrounded = true;
        }
        
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}

//Q is for using abilty
//f light
//g heavy
// combos make bar go up
// douge-doubble click keys/hold run
// no jumping for big guy
// big guy dmg drc atk inc
// big guy is slower
//