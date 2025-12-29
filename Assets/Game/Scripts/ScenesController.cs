using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{

    //make singlton
    public static ScenesController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }



}