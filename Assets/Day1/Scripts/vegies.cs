using UnityEngine;

public class vegies : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 rand;
    [SerializeField] private Vector2 xcam;
    [SerializeField] private Vector2 ycam;
    



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.AddForce(rand, ForceMode2D.Impulse);

          
        }
    }
}
