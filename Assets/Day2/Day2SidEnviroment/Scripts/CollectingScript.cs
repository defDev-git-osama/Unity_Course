using UnityEngine;

public class CollectingScript : MonoBehaviour
{
    [SerializeField] private int collectablesCount;
    [SerializeField] private LayerMask collectingLayer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable" || collectingLayer == (collectingLayer | (1 << collision.gameObject.layer)))
        {
            collectablesCount++;
            Destroy(collision.gameObject);
            Debug.Log("Collectables: " + collectablesCount);
        }
    }
  

 
}
