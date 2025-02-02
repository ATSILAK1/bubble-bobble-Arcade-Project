using UnityEngine;

public class ColliderPosition : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y < transform.position.y +( GetComponent<Renderer>().bounds.size.y / 2 ))
        {
            GetComponent<BoxCollider2D>().enabled = false;

        }
        else { GetComponent<BoxCollider2D>().enabled = true; }
    }
}
