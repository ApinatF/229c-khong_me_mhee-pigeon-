using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGun : MonoBehaviour
{
    [SerializeField]
    private Transform shootpoint;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Rigidbody2D bulletPrefeb;


// Update is called once per frame

private void Start()
{
    Cursor.visible = false;
}

void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 10f );

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log($" X = {hit.point.x} , Y = {hit.point.y}");

                Vector2 Projectile = CalculateProjectileVelocity(shootpoint.position, hit.point, 1f);
                Rigidbody2D fireBullet = Instantiate(bulletPrefeb,shootpoint.position,Quaternion.identity);

                fireBullet.velocity = Projectile;
            
            }
            
        }
        
        target.transform.position = Input.mousePosition;
    }

    public Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float t) 
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / t;
        float velocityY = distance.y / t + 0.5f * Mathf.Abs(Physics2D.gravity.y * t);

        Vector2 result = new Vector2(velocityX, velocityY);

        return result;
    }
}
