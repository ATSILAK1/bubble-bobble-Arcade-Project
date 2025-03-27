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

    [SerializeField]
    private GameObject inactiveSpirit;
    
    private GameObject inactiveSpiritInstance ;

    //[SerializeField]
    //private float waveAmplitude = 0.1f;
    //private float waveFrequency = 1f;

    public TypeOfElement EnemyType { get { return enemyType; }  set { enemyType = value; } }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        Destroy(inactiveSpiritInstance);

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

    private void OnDisable()
    {
        inactiveSpiritInstance = Instantiate(inactiveSpirit, transform.position, Quaternion.identity, transform.root);
    }
    protected void OnDestroy()
    {
        if (inactiveSpiritInstance != null)
        {
            
            Destroy(inactiveSpiritInstance);
        }
       // SfxManager.Instance.PlaySfx2D("EnemyDeath");
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

    protected void EnemyMoveFunction()
    {
       
        if (pathTarget == null || pathTarget.Count == 0) return;

        Vector3 targetPosition = pathTarget[pathListCurrentIndex].position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (moveDirection.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); 
        }
        else if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); 
        }

       
        if (Vector3.Distance(transform.position, targetPosition) < distanceOfDetection)
        {
            pathListCurrentIndex++;
            if (pathListCurrentIndex == pathTarget.Count) pathListCurrentIndex = 0;
        }

        //waveFrequency += Time.deltaTime;
        //transform.position = new Vector3(transform.position.x,Mathf.Sin(waveFrequency)*waveAmplitude, 0);
    }
    private Vector2 GetFacingDirectionFunction(Transform transform)
    {
        return transform.localScale.x > 0 ? Vector2.right : Vector2.left;
    }


  
    

}
