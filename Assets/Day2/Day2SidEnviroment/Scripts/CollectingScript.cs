using UnityEngine;
using TMPro;
using System;



public class CollectingScript : MonoBehaviour
{
    [SerializeField] private int collectablesCount;
    [SerializeField] private LayerMask collectingLayer;
   



    public static Action<int> CollectableCountChange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable" || collectingLayer == (collectingLayer | (1 << collision.gameObject.layer)))
        {
            collectablesCount++;
            Destroy(collision.gameObject);
            CollectableCountChange?.Invoke(collectablesCount);
            
        }
    }
  

 
}
