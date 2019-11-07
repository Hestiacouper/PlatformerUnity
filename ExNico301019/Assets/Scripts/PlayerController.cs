using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D body;
    
    Vector2 direction;
    
    [SerializeField]
    private float speed = 4;
    [SerializeField]
    private int money = 0;

    [SerializeField] bool isTop = false;
    [SerializeField] float timeStopJump = 0.1f;
    float timerStopJump = 0;
    bool canJump = true;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate() {
        body.velocity = direction;
    }
    
    // Update is called once per frame
    void Update() {
        if (isTop)
        {
            direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
            timerStopJump -= Time.deltaTime;
            if (Input.GetAxis("Jump") > 0.1f && canJump)
            {
                Debug.Log("You try to jump");
                direction.y += 10;

                canJump = false;
                timerStopJump = timeStopJump;
            }
        }

        /*if (direction.y > 15)
        {
            direction.y = 10;
        }*/
    }

    void OnTriggerStay2D(Collider2D other) {
        if (timerStopJump <= 0)
        {
            canJump = true;
            Debug.Log("You toutch ground");
        }
        else
        {
            canJump = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        canJump = false;
        Debug.Log("You leave ground");
    }
}