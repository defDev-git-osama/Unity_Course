using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate = 2f;
    private float timer = 0f;
  
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            timer = 0f;
        }
        
    }
}
