using SDD.Events;
using STUDENT_NAME;
using UnityEngine;
using static GlobalEnum;

public abstract class Orb : MonoBehaviour
{
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



    protected void Start()
    {
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
        
        
        if ( gameObjectOfCollision.GetComponent<Enemy>().EnemyType != orbType )
        { 
            EventManager.Instance.Raise(new EnemyHasBeenHitEvent() );
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if ( gameObjectOfCollision.GetComponent<Enemy>().EnemyType == orbType )
        {
            Destroy(gameObject);
            EventManager.Instance.Raise(new ModeHasBeenChangedEvent());
        }


        if (gameObjectOfCollision.tag == "PlatForme")
            Destroy(gameObject);

    }
    
}
