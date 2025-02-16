using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{

    private int maxHealth = 5;
    private int currenthealth = 0;




    // Start is called once before the first execution of Update after the MonoBehaviour is created



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        if (currenthealth < 0)  
            currenthealth = 0;
    }
    public void TakeHealth(int health)
    {
        currenthealth += health;
        if (currenthealth > maxHealth)
            currenthealth = maxHealth;
    }
}
