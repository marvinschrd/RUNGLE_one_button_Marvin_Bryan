using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Update()
    {
        scoreText.text = score.ToString();
    }
  
}
