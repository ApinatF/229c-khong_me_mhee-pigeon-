using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    
    [SerializeField] private Transform Followtarget;
    
    [SerializeField] private float animationSpeed = 1f;
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
    
    private void LateUpdate()
    {
        transform.position = new Vector2(Followtarget.transform.position.x, 0);
    }
}
