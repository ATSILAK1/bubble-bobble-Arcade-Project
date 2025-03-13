using SDD.Events;
using STUDENT_NAME;
using UnityEngine;
using static GlobalEnum;

public abstract class Orb : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField]
    protected float speed = 5.0f; 
    [SerializeField]
    protected int hitDamage; 

    protected TypeOfElement orbType;

    protected Vector2 direction = Vector2.zero;

    protected float destroyTime = 5f; 
    public int  HitDamage 
    { 
        get { return hitDamage; } 
    }
    [SerializeField]
    // effect thats would be played for the contact of the orb with the enemy
    protected GameObject contactEffect;


    protected void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (transform.parent != null)
        {
            direction = transform.parent.right;
        }
        else
        {
            Debug.LogWarning("Orb has no parent. Defaulting to Vector2.right.");
            direction = Vector2.right;
        }
    }

    protected void Update()
    {


        transform.Translate(direction * speed * Time.deltaTime);
    }

    public abstract void InitOrb();
    public abstract void DamageEnemyFunction();

   
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with some element " + collision.gameObject.name);
        var gameObjectOfCollision = collision.gameObject;
       
        if (gameObjectOfCollision == null) return ;

        if (gameObjectOfCollision.CompareTag("PlatForme"))
        {
            Destroy(gameObject);
            return ;
        }
        if ( gameObjectOfCollision.GetComponent<Enemy>() != null  )
        { 
            EventManager.Instance.Raise(new EnemyHasBeenHitEvent() );
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        
        var effect = Instantiate(contactEffect, collision.contacts[0].point, Quaternion.identity );
        Destroy(effect, 0.5f);

    }
    
}
