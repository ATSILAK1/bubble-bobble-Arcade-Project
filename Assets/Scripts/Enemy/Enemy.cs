using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected List<Transform> pathTarget;
    [SerializeField] protected int pathListCurrentIndex = 0 ;

    [SerializeField]
    private float distanceOfDetection = 0.1f;
    protected Rigidbody2D Rigidbody2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    protected void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        EnemyMoveFunction();
    }

    protected void EnemyMoveFunction()
    {
        if (pathTarget == null || pathTarget.Count == 0) return;
        
        transform.position = Vector3.MoveTowards(transform.position, pathTarget[pathListCurrentIndex].position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance( transform.position,pathTarget[pathListCurrentIndex].position ) < distanceOfDetection)
        {
            pathListCurrentIndex++;
            if (pathListCurrentIndex == pathTarget.Count) pathListCurrentIndex = 0;
        }
        
    }

}
