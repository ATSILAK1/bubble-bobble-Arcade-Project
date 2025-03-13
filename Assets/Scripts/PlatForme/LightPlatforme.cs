using SDD.Events;
using STUDENT_NAME;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightPlatforme :  MonoBehaviour, ILightElement,IEventHandler
{
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private Collider2D collider;
    [SerializeField]
    private Color disabledColor;

    private Color oldColor;
    private void Awake()
    {
        SubscribeEvents();
        tilemap = GetComponent<Tilemap>();
        collider = GetComponent<Collider2D>();
        oldColor = tilemap.color;
    }
    private void Start()
    {
        SwapModeFunction();

       
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }
    public void SubscribeEvents()
    {
        EventManager.Instance.AddListener<ModeHasBeenChangedEvent>(ModeHasChangedCallBack);
    }

    public void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<ModeHasBeenChangedEvent>(ModeHasChangedCallBack);
    }
    
    void SwapModeFunction()
    {
        if (GameManager.Instance.CurrentModeState == GlobalEnum.TypeOfElement.Light){ // hack need to be changed 


            tilemap.color = oldColor;
            collider.enabled = true;
    }
        else
        {
            tilemap.color = disabledColor;
            collider.enabled = false;
        }
    }


    
    void ModeHasChangedCallBack(ModeHasBeenChangedEvent e)
    {
        if (e == null) return;

        SwapModeFunction();

    }
}

 

