using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D rb;
    private bool moving;
    public float TimeBetweenMove;
    private float TimeBetweenMoveCounter;
    public float TimeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    public float waitToReload;
    private bool reloading;
    private GameObject Player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        TimeBetweenMoveCounter = TimeBetweenMove;
        timeToMoveCounter = TimeToMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            rb.velocity = moveDirection;
            if (timeToMoveCounter <0)
            {
                moving = false;
                TimeBetweenMoveCounter = TimeBetweenMove;
            }
        }
        else 
        {
            TimeBetweenMoveCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;
            if (TimeBetweenMoveCounter < 0)
            {
                moving = true;
                timeToMoveCounter = TimeToMove;

                moveDirection = new Vector3(Random.Range(-1f, 1f) * movementSpeed, Random.Range(-1f, 1f) * movementSpeed, 0f);
            }
        }
        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                Player.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
    /*
     if (other.gameObject.name == "Player")
        {
            other.gameObject.SetActive(false);
            reloading = true;
            Player = other.gameObject;
        }
        */
    }
    
}
