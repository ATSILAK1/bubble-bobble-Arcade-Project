using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    [SerializeField]
    float angle =0; 
    [SerializeField]
    float frequency = 1.0f;
    
    [SerializeField] float amplitude = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime;
        transform.transform.position = new Vector3(transform.position.x, amplitude * Mathf.Sin(frequency *angle ), transform.position.z);
    }
}
