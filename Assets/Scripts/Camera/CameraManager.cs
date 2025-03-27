using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    [SerializeField] private Transform player; 
    [SerializeField] private float smoothSpeed = 0.125f; 
    [SerializeField] private Vector3 offset; 
    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not assigned to the camera.");
            return;
        }

      
        Vector3 desiredPosition = new Vector3(transform.position.x, player.position.y, 0) + offset;

        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}