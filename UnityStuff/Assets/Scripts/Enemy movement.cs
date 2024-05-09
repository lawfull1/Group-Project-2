using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    private Rigidbody2D rb;

    float moveVelocity;
    public Vector2 speed;
    public float topSpeed;
    public float acceleration;
    private Vector2 velocity;
    private int phase = 2;
    public LayerMask payer;
    public BoxCollider2D Player;
    RaycastHit2D rayCast1;
    RaycastHit2D rayCast;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position+ (new Vector3(0, 0.5f)), transform.TransformDirection(-Vector2.right *10), Color.yellow);
        rayCast = Physics2D.Raycast(transform.position + (new Vector3(0, 0.5f)), -Vector2.right, 10, payer);
        rayCast1 = Physics2D.Raycast(transform.position + (new Vector3(0, 0.5f)), Vector2.right, 10, payer);
        Debug.Log(rayCast.collider != null);
        if (phase == 1)
        {
            return;
        }
        if (phase == 2)
        {
            if (rayCast.collider == Player)
            {
                velocity += speed * acceleration * Time.deltaTime;
                velocity = Vector2.ClampMagnitude(velocity, topSpeed);
                rb.velocity = velocity;

            }else if(rayCast1.collider == Player)
            {
                velocity += speed * acceleration * Time.deltaTime;
                velocity = Vector2.ClampMagnitude(velocity, topSpeed);
                rb.velocity = -velocity;
            }
            else
            {
                rb.velocity = new Vector2(0,0);
            }
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

