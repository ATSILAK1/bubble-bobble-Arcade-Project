using UnityEngine;

public abstract class Orb : MonoBehaviour
{
    [SerializeField]
    protected float speed = 5.0f; 
    [SerializeField]
    protected int hitDamage; 

    protected Vector2 direction = Vector2.zero;
    public int  HitDamage 
    { 
        get { return hitDamage; } 
    }

    


    public abstract void InitOrb();
    public abstract void DamageEnemyFunction();

    

}
