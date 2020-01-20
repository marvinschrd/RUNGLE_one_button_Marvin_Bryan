using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score;

    // [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Start()
    {

    }
    void Update()
    {
        scoreText.text = score.ToString("F1");
    }
  
}
