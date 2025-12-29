using UnityEngine;

public class RandomColorGen : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;
    
    void Start()
    {
        RandomColor();
    }


    private void RandomColor()
    {
        mesh.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
