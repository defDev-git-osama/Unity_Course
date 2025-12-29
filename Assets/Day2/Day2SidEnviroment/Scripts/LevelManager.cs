using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject    playerPrefab;
    [SerializeField] private Transform    spawnPoint;


    void Start()
    {
        Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
    }

  
}
