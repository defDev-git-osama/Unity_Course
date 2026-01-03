using UnityEngine;

public class CameraContTopDown2d : MonoBehaviour
{
   [SerializeField] private Transform target;
   [SerializeField] private float smoothSpeed = 0.125f;
   [SerializeField] private Vector2 minMaxX;
   [SerializeField] private Vector2 minMaxY;
 

    
    void Update()
    {
        float targetX = target.position.x;
        float targetY = target.position.y;
        targetX = Mathf.Clamp(targetX, minMaxX.x, minMaxX.y); 
        targetY = Mathf.Clamp(targetY, minMaxY.x, minMaxY.y); 
        Vector3 targetPosition = new Vector3(targetX, targetY, transform.position.z); 
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        
    }
}
