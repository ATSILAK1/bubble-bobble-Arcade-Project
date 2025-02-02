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
    private float fireRate = 0.2f;
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
         
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeFire)
        {
            ShootFunction(orb);
            nextTimeFire = Time.time + fireRate;
        }
        
    }

    public void ShootFunction(GameObject gameObject)
    {
        GameObject orb = Instantiate(gameObject, sourceFireOrb.position, transform.rotation, sourceFireOrb);
        orb.transform.SetParent(null);
        //   Vector2 direction  = Vector2.right;
        //   if (transform.localScale.x < 0)
        //   {
        //       orb.transform.Translate(-direction * 10f );
        //   }
        //   else
        //   {
        //       orb.transform.Translate(direction * 10f);
        //   }
    }
}
