using System.Collections;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    private Rigidbody2D rb;

    float moveVelocity;
    private SpriteRenderer eniSpr;
    public Transform eni;
    public Vector2 speed;
    public float topSpeed;
    public float acceleration;
    private Vector2 velocity;
    public LayerMask payer;
    public BoxCollider2D Player;
    public BoxCollider2D PlayerPunc;
    RaycastHit2D rayCast1;
    RaycastHit2D rayCast;
    private PlayerMovement plrMov;
    public BoxCollider2D eniBox;
    public int Halth;
    // Start is called before the first frame update



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        PlayerPunc = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<BoxCollider2D>();
        eniSpr = GetComponentInChildren<SpriteRenderer>();
        eni = gameObject.transform;
        eniBox = eni.GetChild(0).GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawRay(transform.position+ (new Vector3(0, 0.5f)), transform.TransformDirection(-Vector2.right *10), Color.yellow);
        rayCast = Physics2D.Raycast(transform.position + (new Vector3(0, 0.5f)), -Vector2.right, 10, payer);
        rayCast1 = Physics2D.Raycast(transform.position + (new Vector3(0, 0.5f)), Vector2.right, 10, payer);
        if (rayCast.distance >= 1 || rayCast1.distance >= 1)
        {
            if (rayCast.collider == Player || rayCast.collider == Player)
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

    void OnCollision2D(Collision2D col)
    {
        if(eniBox ==  PlayerPunc)
        {
            Halth = Halth - 10;
            GameObject bar = GetComponentInChildren<GameObject>();
            bar.gameObject.transform.localScale = new Vector2(Halth / 100, 0.05f);
            Debug.Log("hit");
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
 * 9 = Recover
 * 10 = HardHit
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

