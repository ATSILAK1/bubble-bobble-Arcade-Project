using UnityEngine;

public class LightEnemy : Enemy , ILightElement
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyType = GlobalEnum.TypeOfElement.Light;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

   
}
