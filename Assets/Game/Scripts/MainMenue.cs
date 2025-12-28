using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenue : MonoBehaviour
{
    [Header("Buttons")]
   [SerializeField] private Button day1Button;


 
   
  

    private void OnEnable()
    {
        day1Button.onClick.AddListener(() => SceneManager.LoadScene("Day1"));
    }

}
