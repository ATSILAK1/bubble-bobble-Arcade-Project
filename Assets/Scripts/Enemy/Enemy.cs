using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private int moveSpeed; 
    private List<Transform> pathTarget;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
