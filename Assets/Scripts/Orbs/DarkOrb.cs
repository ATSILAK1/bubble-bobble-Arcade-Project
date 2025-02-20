using UnityEngine;

public class DarkOrb : Orb
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitOrb();
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
       base.Update();
    }
    
    public override void InitOrb()
    {
        orbType = GlobalEnum.TypeOfElement.Dark;
        speed = 10.0f;
    }
    public override void DamageEnemyFunction()
    {
        throw new System.NotImplementedException();
    }

    
}
