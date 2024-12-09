using UnityEngine;
using TMPro; // Import this if using TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton for global access
    public TextMeshProUGUI scoreText; // Drag the ScoreText UI element here
    private int score = 0; // Keeps track of the score

    private void Awake()
    {
        // Ensure only one instance of ScoreManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the ScoreManager across scenes (optional)
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount; // Increase the score
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Update the UI
    }
}
