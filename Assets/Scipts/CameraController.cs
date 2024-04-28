using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Followtarget;
    private void LateUpdate()
    {
        transform.position = new Vector3(Followtarget.transform.position.x + 10, 0, -10);
    }
}
