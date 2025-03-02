using SDD.Events;
using STUDENT_NAME;
using UnityEngine;

public class LightPlatforme :  MonoBehaviour, ILightElement,IEventHandler
{
    private void Start()
    {
        SubscribeEvents();
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

    void ModeHasChangedCallBack(ModeHasBeenChangedEvent e)
    {
        if (e == null) return;

        if (GameManager.Instance.CurrentModeState == GlobalEnum.TypeOfElement.Light) // hack need to be changed 
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}

 

