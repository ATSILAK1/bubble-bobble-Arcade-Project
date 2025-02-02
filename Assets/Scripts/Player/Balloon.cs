using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float speed ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * speed;
    }
}
