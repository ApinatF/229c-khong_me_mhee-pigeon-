using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float speed;
    
    private float inputX;

    [SerializeField] private float jumpf;
    [SerializeField] private bool isJumping; 
    public GameObject groundRayObj;
    
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            isJumping = false;

        }
    
    
        void Update()
        {
           
            Movement();
            Jump();

        }
    
        private void FixedUpdate()
        {
            inputX = Input.GetAxis("Horizontal");
            RaycastHit2D hitGround = Physics2D.Raycast(groundRayObj.transform.position, -Vector2.up);
            Debug.DrawRay (groundRayObj.transform.position, -Vector2.up * hitGround.distance , Color.red);

            if (hitGround.distance != null)
            {
                if (hitGround.distance <= 0.5)
                {
                    isJumping = false;
                }
                else
                {
                    isJumping = true;
                }
            }
        }
    
        private void Movement()
        {
            rb.velocity = new Vector2(inputX * speed , rb.velocity.y);
            if (inputX > 0f)
            {
                transform.eulerAngles = Vector2.zero;
            }
            else if (inputX < 0f)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
    
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isJumping == false)
                {
                    rb.velocity = Vector2.up * jumpf;
                }
            }
        }
}
