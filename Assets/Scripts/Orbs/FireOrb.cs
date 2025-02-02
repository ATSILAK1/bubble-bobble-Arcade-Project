using UnityEngine;

public class FireOrb : Orb
{
    private void Start()
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

    private void Update()
    {
        
        
        transform.Translate(direction * speed * Time.deltaTime);
    }
    public override void DamageEnemyFunction()
    {
        
    }


    public override void InitOrb()
    {
        throw new System.NotImplementedException();
    }
}
