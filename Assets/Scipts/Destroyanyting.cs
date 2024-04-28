using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyanyting : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player")))
        {
            Destroy(gameObject);
        }
    }
}
