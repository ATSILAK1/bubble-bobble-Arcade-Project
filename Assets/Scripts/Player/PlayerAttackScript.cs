using System;
using STUDENT_NAME;
using UnityEngine;



public class PlayerAttackScript : MonoBehaviour
{
    [SerializeField]
    private GameObject lightOrb;
    [SerializeField]
    private GameObject darkOrb;
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
            Debug.Log(GameManager.Instance.CurrentModeState.ToString());
            if (GameManager.Instance.CurrentModeState == ModeState.Dark) 
                ShootFunction(darkOrb);
            if (GameManager.Instance.CurrentModeState== ModeState.Light)
                ShootFunction(lightOrb);
            nextTimeFire = Time.time + fireRate;
        }
        
    }

    public void ShootFunction(GameObject gameObject)
    {
        GameObject orb = Instantiate(gameObject, sourceFireOrb.position, transform.rotation, sourceFireOrb );
        orb.transform.SetParent(null);
     
    }
}
