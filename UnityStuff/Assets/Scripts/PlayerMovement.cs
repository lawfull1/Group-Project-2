using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    public int Jumps = 2;
    //Grounded Vars
    bool isGrounded = true;
    //Puffy involved stuff (how is this not orginized like what how about you get the brain cells to understand it)
    public int maxPuffyTime;
    private float puffyTime;
    public int puffySpeed;
    public int puffyDamage;
    public int puffyHealth;
    private bool isPuffy = false; //this one hard to understand?
    private float puffyCooldown;
    public float puffyCooldownSetters;
    //damage stuff
    private int damage;
    private int damageDone;
    private int maxHealth;
    private int currentHp;
    //when puffy is deactivated Im sorry you don't know what a prefix is
    public int prePuffyHealth;
    public int prePuffyDamage;
    public int prePuffySpeed;
    private bool isPuffyPrint;
    // Update is called once per frame
    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded == true && isPuffy == false && Jumps > 0)
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
            print(puffyTime);
        }
        managePuffy();
        hit();
        puffyTime += -Time.deltaTime;
        puffyCooldown += -Time.deltaTime;
    }
    void hit()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            damageDone = damage;
        }
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            damageDone = damage * 2;
        }
    }
    //Check if Grounded
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Ground")
        {
            isGrounded = true;
            Jumps = 2;
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
            maxHealth = puffyHealth;
            isPuffyPrint = false;
            print("puffy set");
        }
    }
    private void puffyDeActivated()
    {
        if (damage != prePuffyDamage)
        {
            damage = prePuffyDamage;
            speed = prePuffySpeed;
            maxHealth = prePuffyHealth;
            puffyCooldown = puffyCooldownSetters;
            print(puffyCooldown + "puffyCooldown");
        }
        if (isPuffyPrint == false)
        {
            print("puffy unset");
            isPuffyPrint = true;
        }
        print(puffyCooldown);
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
}
//Q is for using abilty done
//f light
//g heavy
// combos make bar go up
// douge-doubble click keys/hold run
// no jumping for big guy
// big guy dmg drc atk inc
// big guy is slower
//double jump because github desktop is annoying and I have to add all the crap at home for the 3rd time because github desktop keeps overidding it like the dumbass it is