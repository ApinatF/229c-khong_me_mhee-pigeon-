using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenyAttack : MonoBehaviour
{
    [SerializeField] private bool fireOn = false;
    
    [SerializeField]
    private Transform shootpoint;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Rigidbody2D bulletPrefeb;
    
    private float timeCurren = 0f;

    private float timeMax = 3f;
    
    void Awake()
    {
        timeCurren = 0f;
    }
    
    void FixedUpdate()
    {
        timeCurren += Time.deltaTime;
        Debug.Log(target);

        if (timeCurren >= timeMax && target != null && fireOn == true)
        {
            fireBullet(target);
            timeCurren = 0f;
        }
        
    }
    public Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float t) 
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / t;
        float velocityY = distance.y / t + 0.5f * Mathf.Abs(Physics2D.gravity.y * t);

        Vector2 result = new Vector2(velocityX, velocityY);

        return result;
    }

    public void fireBullet(GameObject ta)
    {
        Vector2 Projectile = CalculateProjectileVelocity(shootpoint.position, ta.transform.position, 1f);
        Rigidbody2D fireBullet = Instantiate(bulletPrefeb,shootpoint.position,Quaternion.identity);

        fireBullet.velocity = Projectile;
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player")))
        {
            fireOn = true;
            target = other.gameObject;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player")))
        {
            fireOn = false;
            target = null;
        }
    }
}
