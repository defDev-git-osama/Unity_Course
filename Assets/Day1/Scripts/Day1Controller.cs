using UnityEngine;

public class Day1Controller : MonoBehaviour
{
    [SerializeField] private GameObject stairs;
    [SerializeField] private GameObject envo;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stairs.SetActive(!stairs.activeSelf);
            envo.SetActive(!envo.activeSelf);
        }

        
    }
}
