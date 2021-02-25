using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float movementSpeed = 10;
    public float LastMoveX, LastMoveY;
    public float AttackTime, TimeToWalk;
    private float AttackCounter, TimeToWalkCounter;
    private Rigidbody2D Fizyka;
    private Vector2 LastMove;
    private Animator anim;
    private bool attacking;
    private bool Have_sword;
    private SFX sfx;
    // Use this for initialization
    void Start()
    {
        Fizyka = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sfx = FindObjectOfType<SFX>();
    }


    void Update()
    {
        if (!attacking)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                anim.SetBool("Is Moving", true);
                Fizyka.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, Fizyka.velocity.y);
                //LastMove = new Vector2(0f, Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("Last MoveX", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("Last MoveY", 0f);
                LastMoveX = Input.GetAxisRaw("Horizontal");
                LastMoveY = 0f;
                if (TimeToWalkCounter <= 0)
                {
                    sfx.Walk.Play();
                    TimeToWalkCounter = TimeToWalk;
                }
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                anim.SetBool("Is Moving", true);
                Fizyka.velocity = new Vector2(Fizyka.velocity.x, Input.GetAxisRaw("Vertical") * movementSpeed);
                anim.SetFloat("Last MoveY", Input.GetAxisRaw("Vertical"));
                anim.SetFloat("Last MoveX", 0f);
                LastMoveX = 0f;
                LastMoveY = Input.GetAxisRaw("Vertical");
                if (TimeToWalkCounter <= 0)
                {
                    sfx.Walk.Play();
                    TimeToWalkCounter = TimeToWalk;
                }
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
                Fizyka.velocity = new Vector2(Fizyka.velocity.x, 0f);
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
                Fizyka.velocity = new Vector2(0f, Fizyka.velocity.y);
            }
            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f && Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                anim.SetBool("Is Moving", false);
            }
            if (Input.GetKey("z"))
            {
                if (GetComponent<Interakcje>().Have_sword == true)
                {
                    AttackCounter = AttackTime;
                    anim.SetBool("Is Attacking", true);
                    Fizyka.velocity = Vector2.zero;
                    attacking = true;
                }
            }
            else
            {

                anim.SetBool("Is Attacking", false);

            }


        }
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
       if(AttackCounter>0)
        {
            AttackCounter -= Time.deltaTime;
        }
        if (TimeToWalkCounter > 0)
        {
            TimeToWalkCounter -= Time.deltaTime;
        }
        else
        {
            attacking = false;
            anim.SetBool("Is Attacking", false);
        }
    }
}
