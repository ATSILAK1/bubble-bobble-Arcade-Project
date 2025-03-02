using SDD.Events;
using STUDENT_NAME;
using UnityEngine;

public class DarkPlatforme : MonoBehaviour, IDarkElement, IEventHandler
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

        Debug.Log("Platform DARK Is Changing Type " + e.typeOfElement);
        if (GameManager.Instance.CurrentModeState == GlobalEnum.TypeOfElement.Light) // Hack Need to Be changed 
        {
            gameObject.SetActive(false);

        }
        else
        {
            gameObject.SetActive(true);
        }

    }
}
