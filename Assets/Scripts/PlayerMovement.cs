using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //identify the Object
    public float speed;
    private Animator anim;
    private bool playerMove;
    private Vector2 lastMove;
    private Rigidbody2D rb;
    private static bool playerExist;
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;


    public LayerMask grasslayer;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if(!playerExist)
        {
            playerExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        playerMove = false;
        if(!attacking)
        {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime,0f,0f));
            rb.velocity = new Vector2 (Input.GetAxisRaw("Horizontal")* speed,rb.velocity.y);
            playerMove = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"),0f);
            CheckForEncounters();

        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * speed * Time.deltaTime,0f));
            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical")* speed);
            playerMove = true;
            lastMove = new Vector2(0f,Input.GetAxisRaw("Vertical"));
            CheckForEncounters();
        }
        
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            rb.velocity = new Vector2 (0f, rb.velocity.y);
            //CheckForEncounters();
        }
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            rb.velocity = new Vector2 (rb.velocity.x,0f);
            //CheckForEncounters();
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            attackTimeCounter= attackTime;
            attacking = true;
            rb.velocity = Vector2.zero;
            anim.SetBool("Attacking",true); 
        }
        }
        if(attackTimeCounter > 0)
        {
            attackTimeCounter-=Time.deltaTime;
        }
        if(attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attacking",false);
        }
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("moveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("IsMoving",playerMove);
        anim.SetFloat("idleMoveX",lastMove.x);
        anim.SetFloat("idleMoveY",lastMove.y);
        //CheckForEncounters();
    }
    private void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position,0.2f, grasslayer) != null)
        {
            if(Random.Range(1,101)<=10)
            {
                Debug.Log("Encountered a wild enemy");
            }
        }
    }
}
