using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;



    void OnEnable()
    {
       CollectingScript.CollectableCountChange += UpdateScore;
    }
    void OnDisable()
    {
        CollectingScript.CollectableCountChange -= UpdateScore;
    }
    public void UpdateScore(int score)
    {
        scoreText.text = $"Gems: {score}";
    }

}