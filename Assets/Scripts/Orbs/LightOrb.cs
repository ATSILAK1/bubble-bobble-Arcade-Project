using UnityEngine;

public class FireOrb : Orb
{
    private void Start()
    {
        InitOrb();
       base.Start();
    }

    private void Update()
    {
        base.Update();
        
        //transform.Translate(direction * speed * Time.deltaTime);
    }
    public override void DamageEnemyFunction()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
    public override void InitOrb()
    {
       orbType = GlobalEnum.TypeOfElement.Light;
    }
}
