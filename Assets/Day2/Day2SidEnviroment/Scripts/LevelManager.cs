using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject    playerPrefab;
    [SerializeField] private Transform    spawnPoint;


    [SerializeField] private Vector3 camOffset;
    [SerializeField] private GameObject cameraa;
    private GameObject player;




    void Start()
    {
        Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        player = GameObject.FindWithTag("Player");
    }


    void FixedUpdate()
    {
        cameraa.transform.position = Vector3.Lerp(cameraa.transform.position,
        new Vector3(player.transform.position.x, cameraa.transform.position.y, cameraa.transform.position.z) + camOffset , 0.1f);
    }

}
