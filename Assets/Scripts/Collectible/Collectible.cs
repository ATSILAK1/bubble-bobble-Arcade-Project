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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null)
            return; 

        if (collision.gameObject.GetComponent<PlayerMovementScript>() )
        {
            Collect();
        }
    }
}
