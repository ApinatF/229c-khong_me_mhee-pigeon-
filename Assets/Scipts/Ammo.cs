using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Ammo : MonoBehaviour
{
    private float timeCurren = 0f;

    private float timeMax = 3f;
    // Start is called before the first frame update
    void Awake()
    {
         timeCurren = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeCurren += Time.deltaTime;
        if (timeCurren >= timeMax)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Ammo")))
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
