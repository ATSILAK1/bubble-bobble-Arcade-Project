using UnityEngine;

public class DarkEnemy : Enemy , IDarkElement
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyType = GlobalEnum.TypeOfElement.Dark;
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
