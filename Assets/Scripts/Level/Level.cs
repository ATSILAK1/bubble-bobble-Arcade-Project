using SDD.Events;

using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using STUDENT_NAME;


public class Level : MonoBehaviour , IEventHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Tooltip("GameObject that will hold the dark mode element ")]
    [SerializeField] private GameObject darkGamePbject;
    [Tooltip("GameObject that will hold the light mode element ")]
    [SerializeField] private GameObject lightGameObject;
    
    
    [SerializeField] private int levelNumber;
    [SerializeField] private int numberOfEnemy;
    [SerializeField] private Transform spawnPointOfLevel;
    private List<GameObject> lightPlatformHolder; 
    private List<GameObject> darkPlatformHolder;
    private void Awake()
    {
        SubscribeEvents();
        numberOfEnemy = FindObjectsByType<Enemy>(sortMode: FindObjectsSortMode.None).Length;
    }


    void Start()
    {
        GameObject.Find("Player").transform.position = spawnPointOfLevel.position;
        SwapModeFunction();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();   
    }
    public void SubscribeEvents()
    {
        EventManager.Instance.AddListener<ModeHasBeenChangedEvent>(ModeSwapCallBack);
        EventManager.Instance.AddListener<EnemyHasBeenHitEvent>(DecrementNumberEnemyCallBack);

    }

    public void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<ModeHasBeenChangedEvent>(ModeSwapCallBack);
        EventManager.Instance.RemoveListener<EnemyHasBeenHitEvent>(DecrementNumberEnemyCallBack);

    }

    //public void ActivateAndDesactivatePlatformFunction()
    //{
    //    if (GameManager.Instance.CurrentModeState == GlobalEnum.TypeOfElement.Light)
    //    {
    //        darkPlatform.ForEach(item => item.SetActive(false));
    //        lightPlatform.ForEach(item => item.SetActive(true));
    //    }
    //    else
    //    {
    //        lightPlatform.ForEach(item => item.SetActive(false));
    //        darkPlatform.ForEach(item => item.SetActive(true));
    //    }
    //}

    void SwapModeFunction()
    {
        if (GameManager.Instance.CurrentModeState == GlobalEnum.TypeOfElement.Light)
        {
            lightGameObject.SetActive(false);

            darkGamePbject.SetActive(true);
        }
        else
        {

            lightGameObject.SetActive(true);
            darkGamePbject.SetActive(false);
        }
    }

    #region CallBack Function 
    void ModeSwapCallBack(ModeHasBeenChangedEvent e)
    {
        SwapModeFunction();
    }
    void DecrementNumberEnemyCallBack(EnemyHasBeenHitEvent e)
    {
        numberOfEnemy--;
        if (numberOfEnemy == 0)
            EventManager.Instance.Raise(new GameVictoryEvent());
    }
    #endregion

    
    
    } 
    

