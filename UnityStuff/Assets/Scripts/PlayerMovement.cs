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
    public int prePuffySpeed = 10;
    private bool isPuffyPrint;
    //Animations and stuff for dumies
    public Animator ani;

    // Update is called once per frame
    void Update()
    {

        if (!Input.anyKeyDown)
        {
            ani.SetTrigger("idle");
        }


        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            
            if (isGrounded == true && isPuffy == false && Jumps > 0)
            {
                ani.SetInteger("Animation_Control", 3);
                rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                Jumps--;
                
           }
        }
        if (boogie == true)
        {
            flowie += speed;
        }
        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.D)))
        {
            ani.SetInteger("Animation_Control", 2);
        }
        moveVelocity = Input.GetAxisRaw("Horizontal") * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ani.SetInteger("Animation_Control", 6);
            puffyActivated();
            print(puffyTime);
            
        }
        managePuffy();
        hit();
        puffyTime += -Time.deltaTime;
        puffyCooldown += -Time.deltaTime;
        if (damage != prePuffyDamage)
        {
            damage = prePuffyDamage;
            speed = prePuffySpeed;
            maxHealth = prePuffyHealth;
            puffyCooldown = puffyCooldownSetters;
            print(puffyCooldown + "puffyCooldown");
        }
        
    }
    void hit()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            damageDone = damage;
            ani.SetInteger("Animation_Control", 4);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            damageDone = damage * 2;
            ani.SetInteger("Animation_Control", 8);
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
            ani.SetInteger("Animation_Control", 6);
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
        if (isPuffyPrint == false)
        {
            
            print("puffy unset");
            isPuffyPrint = true;
            ani.SetTrigger("puffy devc");
        }
        //print(puffyCooldown);
        
    }
    private void managePuffy()
    {
        if (puffyTime <= 0)
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
//g heavy
//f light
// combos make bar go up
// douge-doubble click keys/hold run
// no jumping for big guy
// big guy dmg drc atk inc
// big guy is slower
//double jump because github desktop is annoying and I have to add all the crap at home for the 3rd time because github desktop keeps overidding it like the dumbass it is