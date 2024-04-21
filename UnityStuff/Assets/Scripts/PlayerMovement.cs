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
    //Grounded Vars
    bool isGrounded = true;
    //Puffy involved stuff (how is this not orginized like what how about you get the brain cells to understand it)
    public int maxPuffyTime;
    private int puffyTime;
    public int puffySpeed;
    public int puffyDamage;
    public int puffyHealth;
    private bool isPuffy; //this one hard to understand?
    //damage stuff
    private int damage;
    private int damageDone;
    private int maxHealth;
    private int currentHp;
    //when puffy is deactivated Im sorry you don't know what a prefix is
    public int prePuffyHealth;
    public int prePuffyDamage;
    public int prePuffySpeed;
    // Update is called once per frame
    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded == true && isPuffy ==  false)
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            puffyActivated();
        }
        managePuffy();
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
    private void puffyActivated() 
    {
        //sets puffyTime as needed
        if (puffyTime <= 0)
        {
            puffyTime = maxPuffyTime;
            isPuffy = true;
            damage = puffyDamage;
            speed = -1 * puffySpeed; //don't judge the -1 Im to lazy to double check if -puffySpeed would work when you get sprites back
            maxHealth = puffyHealth;
        }
    }
    private void puffyDeActivated()
    {
        damage = prePuffyDamage;
        speed = prePuffySpeed;
        maxHealth = prePuffyHealth;

    }
    private void managePuffy() 
    {
        if(puffyTime <= 0)
        {
            if (isPuffy == true)
            {
                isPuffy = false;
                print("isPuffy is false (for debugging you monkey)");
            }
            puffyDeActivated();
        }
    }
    void fixedUpdate()
    {
        puffyTime += -1;
        print(puffyTime);
        print("update");
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
//double jump because github desktop is annoying and I have to add all the crap at home for the 3rd time because github desktop keeps overidding it like the dumbass it is