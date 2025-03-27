using System;
using SDD.Events;
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
        ChangeModeFunction();
    }


    public void AttackWithOrbFunction()
    {
        var currentState = GameManager.Instance.CurrentModeState; // need to change we dont need it anymore 
                                                                  // Double orb not our feature
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeFire)
        {

           
            Debug.Log(GameManager.Instance.CurrentModeState.ToString());

            SfxManager.Instance.PlaySfx2D("SpellCast");
            if (currentState == GlobalEnum.TypeOfElement.Dark) 
                ShootFunction(darkOrb);
            else
                ShootFunction(lightOrb);
            

            nextTimeFire = Time.time + fireRate;
        }
        
    }

    public void ShootFunction(GameObject gameObject)
    {
        GameObject orb = Instantiate(gameObject, sourceFireOrb.position, transform.rotation, sourceFireOrb );
        orb.transform.SetParent(null);
     
    }

    private void ChangeModeFunction()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            EventManager.Instance.Raise(new ModeHasBeenChangedEvent());
        }
    }
}
