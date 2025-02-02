using System;
using UnityEngine;


enum OrbType { Fire_Orb , Water_Orb , Light_Orb }
public class PlayerAttackScript : MonoBehaviour
{
    [SerializeField]
    private GameObject orb;
    [SerializeField]
    private Transform sourceFireOrb;

    [SerializeField]
    private float fireRate = 1.0f;
    [SerializeField]
    private float nextTimeFire = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackWithOrbFunction();
    }


    public void AttackWithOrbFunction()
    {
         
        if (Input.GetButtonDown("Fire1")  && Time.time >= fireRate)
        {
            ShootFunction(orb);
            nextTimeFire = 0;
        }
        nextTimeFire = Time.deltaTime + fireRate;
    }

    public void ShootFunction(GameObject gameObject)
    {
     GameObject orb =   Instantiate(gameObject,sourceFireOrb.position , transform.rotation,sourceFireOrb);
        Vector2 direction  = Vector2.right;
        if (transform.localScale.x < 0)
        {
            
        }
    }
}
