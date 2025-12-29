using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenue : MonoBehaviour
{
    [Header("Buttons")]
   [SerializeField] private Button day1Button;
   [SerializeField] private Button day2SideButton;
   [SerializeField] private Button day2FractalButton;
   [SerializeField] private Button day2TopDownButton;


 
   
  

    private void OnEnable()
    {
        day1Button.onClick.AddListener(() => SceneManager.LoadScene("Day1"));
        day2SideButton.onClick.AddListener(() => SceneManager.LoadScene("Day2Side"));
        day2FractalButton.onClick.AddListener(() => SceneManager.LoadScene("Day2Fractal"));
        day2TopDownButton.onClick.AddListener(() => SceneManager.LoadScene("Day2TopDown"));
    }

}

