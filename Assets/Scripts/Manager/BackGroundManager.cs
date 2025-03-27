using DG.Tweening;
using SDD.Events;
using UnityEngine;
using UnityEngine.Rendering;

public class BackGroundManager : MonoBehaviour
{

    [SerializeField]
    private GameObject lightBackGround;
    [SerializeField]
    private GameObject darkBackGround;

    private void Awake()
    {
        EventManager.Instance.AddListener<ModeHasBeenChangedEvent>(ModeChange);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        EventManager.Instance.RemoveListener<ModeHasBeenChangedEvent>(ModeChange);
    }

    void SwapModeState()
    {
       if(darkBackGround.activeSelf)
        {
            lightBackGround.SetActive(true);
            darkBackGround.SetActive(false);
        
        }

        else
        {
            lightBackGround.SetActive(false);
            darkBackGround.SetActive(true);
        }

    }



    #region CallBacks To Events Issued by Mode Changing 
    private void ModeChange(ModeHasBeenChangedEvent e)
    {
        SwapModeState();
    }
    #endregion
}
