using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 direction;
    
    [SerializeField] private float speed;
    
    [SerializeField] private float jompForce = 5f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //rb.velocity = transform.right * speed;
        rb.AddForce(transform.right * speed);
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(speed, jompForce)  ;
            //transform.position = direction * Time.deltaTime;
            //rb.AddForce(transform.right * speed);
        }

        

    }


    /*private float inputX;

    [SerializeField] private float jumpf;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool isSwimming;
    public GameObject groundRayObj;
    
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            isJumping = false;
            isSwimming = false;

        }
    
    
        void Update()
        {
           
            Movement();
            Jump();

        }
    
        private void FixedUpdate()
        {
            inputX = Input.GetAxis("Horizontal");
            /*RaycastHit2D hitGround = Physics2D.Raycast(groundRayObj.transform.position, -Vector2.up);
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
                if (isJumping == false || isSwimming == true )
                {
                    rb.velocity = Vector2.up * jumpf;
                }
            }
        }*/

        private void OnCollisionEnter2D(Collision2D other)
        {
            
            if ((other.gameObject.CompareTag("Ground")))
            {
                //isJumping = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((other.gameObject.CompareTag("Water")))
            {
                //isSwimming = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                //isJumping = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((other.gameObject.CompareTag("Water")))
            {
                //isSwimming = false;
            }
        }
}
