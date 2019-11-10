using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D body;
    
    Vector2 direction;
    
    [SerializeField]
    private float speed = 4;
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
        
    
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        timerStopJump -= Time.deltaTime;
        if (Input.GetAxis("Jump") > 0.1f && canJump)
        {
            //Debug.Log("You try to jump");
            direction.y += 10;
            canJump = false;
            timerStopJump = timeStopJump;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (timerStopJump <= 0)
        {
           // Debug.Log("You touch ground");
            canJump = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("You leave ground");
        canJump = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jesus"))
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}