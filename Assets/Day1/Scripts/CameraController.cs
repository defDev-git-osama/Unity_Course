using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    
    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += dir * speed * Time.deltaTime;
    }

}
