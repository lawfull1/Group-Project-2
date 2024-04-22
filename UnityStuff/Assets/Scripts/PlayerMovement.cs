using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //important
    private bool boogie = true;
    private float flowie = 10f;
    //Movement
    private float speed;
    public float jump;
    float moveVelocity;
    public Rigidbody2D rb;
    public float prePuffySpeed;
    public float puffySpeed;
    private int doubleJump;
    //Grounded Vars
    bool isGrounded = true;
    //damage stuff ig git gud
    public int damage;
    public int puffyDamage;
    public int prePuffyDamage;
    private float DamageDone;
    //Puffy stuff ig
    private int puffyTime;
    public int maxPuffyTime;
    public int puffyTimeSubtraction;
    private bool isPuffy;
    // Update is called once per frame
    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded == true && isPuffy != false && doubleJump < 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }
        if (boogie == true)
        {
            flowie += speed;
        }
        moveVelocity = Input.GetAxisRaw("Horizontal") * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (puffyTime > 0)
            {
                PuffyActivated();
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            DamageDone = damage;
            ICanCallThisWhateverIwantyk();
        }
       if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            DamageDone = damage * 2;
            ICanCallThisWhateverIwantyk();
        }
    }
    private void ICanCallThisWhateverIwantyk()
    {
        //add punch later ig (Idk what Im doing)
    }
    void PuffyActivated()
    {
            damage = puffyDamage;
            speed = puffySpeed;
    }
    //Check if Grounded
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Ground")
        {
            isGrounded = true;
            doubleJump = 2;
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
//Q is for using abilty U
//f light
//g heavy
// combos make bar go up
// douge-doubble click keys/hold run
// no jumping for big guy yes
// big guy dmg drc atk inc sadasdxzc
// big guy is slower sadasdsax
//double jumping :)
//
