using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using SDD.Events;
using UnityEngine;
using static GlobalEnum;


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
    [SerializeField]
    protected TypeOfElement enemyType; 

    public TypeOfElement EnemyType { get { return enemyType; }  set { enemyType = value; } }
    
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
        GetFacingDirectionFunction(transform);
        Vector2 moveDirection = Rigidbody2D.linearVelocity.normalized;
        if (moveDirection.x > 0)
        {
            Debug.Log("Facing Right");
        }
        else if (moveDirection.x < 0)
        {
            Debug.Log("Facing Left");
        }
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
        if(GetFacingDirectionFunction(transform) == Vector2.left)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

    }

    private Vector2 GetFacingDirectionFunction(Transform transform)
    {
        return transform.localScale.x > 0 ? Vector2.right : Vector2.left;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementScript>() != null) 
        {
            Debug.Log("il y a contact");
            EventManager.Instance.Raise(new PlayerHasBeenHitEvent());
        }
        Debug.Log("il Y a pas contact");
    }
    

}
