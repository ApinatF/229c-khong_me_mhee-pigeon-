using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 move;
    [SerializeField] private float speed;

    private float inputX;
    private float inputY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        move = new Vector2(inputX, 0);
        rb.AddForce(move * speed * Time.deltaTime);
        
        
        if (move.x > 0f)
        {
            transform.eulerAngles = Vector2.zero;
        }
        else if (move.x < 0f)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

    }
}
