using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    [SerializeField] private Transform player; // Reference to the player's transform
    [SerializeField] private float smoothSpeed = 0.125f; // Smoothing speed
    [SerializeField] private Vector3 offset; // Offset from the player

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