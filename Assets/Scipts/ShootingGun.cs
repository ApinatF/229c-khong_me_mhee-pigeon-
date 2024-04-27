using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;


public class ShootingGun : MonoBehaviour
{
    [SerializeField] private GameObject gun;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;
    
    [SerializeField]
    private Transform shootpoint;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Rigidbody2D bulletPrefeb;

    private GameObject bulletPrefeb2;

    private GameObject bulletInst;

    void Update()
    {
        GunRotate();
        //GunShooting();
        
        FireBulletProjectile();
        
        
        target.transform.position = Input.mousePosition; // Set GameObj targetUi at mouse position
    }


    private void FireBulletProjectile()
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

            Vector2 Projectile = CalculateProjectileVelocity(shootpoint.position, hit.point, 0.5f);
            Rigidbody2D fireBullet = Instantiate(bulletPrefeb,shootpoint.position,Quaternion.identity);

            fireBullet.velocity = Projectile;
            
        }
            
    }
} //Code อาจารย์

    public Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float t) 
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / t;
        float velocityY = distance.y / t + 0.5f * Mathf.Abs(Physics2D.gravity.y * t);

        Vector2 result = new Vector2(velocityX, velocityY);

        return result;
    } //Code อาจารย์

    private void GunRotate()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(target.transform.position);
        direction = (worldPosition - (Vector2)gun.transform.position);
        gun.transform.right = direction;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 localScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }

        gun.transform.localScale = localScale;

    }
    
}
