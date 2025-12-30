using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject spawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_prefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
