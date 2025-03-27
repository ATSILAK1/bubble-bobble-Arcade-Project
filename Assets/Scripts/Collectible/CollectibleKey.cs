using SDD.Events;
using UnityEngine;

public class CollectibleKey : MonoBehaviour , ICollectible
{
    public void Collect()
    {
        EventManager.Instance.Raise(new KeyHasBeenCollectedEvent());
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
