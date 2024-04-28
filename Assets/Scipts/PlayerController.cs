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
        rb.velocity = new Vector2(speed, rb.velocity.y);
        
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(speed, jompForce)  ;
        }
        
    }
    

        private void OnCollisionEnter2D(Collision2D other)
        {
            
            if ((other.gameObject.CompareTag("killplayer")))
            {
                GameManager.instance.IsGameOver = true;
            }
            
            if ((other.gameObject.CompareTag("Goal")))
            {
                GameManager.instance.IsWin = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((other.gameObject.CompareTag("Scoring")))
            {
                GameManager.instance.AddCoin(5);
            }
            
            if ((other.gameObject.CompareTag("Ammo")) || (other.gameObject.CompareTag("Obstruction")) )
            {
                GameManager.instance.TakeDamege(1);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            
        }
}
