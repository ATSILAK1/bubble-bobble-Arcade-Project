using SDD.Events;
using STUDENT_NAME;
using UnityEngine;

public class DarkPlatforme : MonoBehaviour, IDarkElement, IEventHandler
{
    private void Start()
    {
        SubscribeEvents();
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
        if (GameManager.Instance.CurrentModeState == GlobalEnum.TypeOfElement.Dark) // hack need to be changed 
        {

            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }



    void ModeHasChangedCallBack(ModeHasBeenChangedEvent e)
    {
        if (e == null) return;

        SwapModeFunction();

    }
    
}
