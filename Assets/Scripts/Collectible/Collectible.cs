using SDD.Events;
using UnityEngine;

public class Collectible : MonoBehaviour , ICollectible
{
    [SerializeField]
    private int scoreGiven ; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    public void Collect()
    {
        Destroy(gameObject);
        EventManager.Instance.Raise(new ScoreItemEvent() { eScore = scoreGiven });
        SfxManager.Instance.PlaySfx2D("CoinPickUp");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null)
            return;

        if (other.gameObject.GetComponent<PlayerMovementScript>())
        {
            Collect();
        }
    }
}
