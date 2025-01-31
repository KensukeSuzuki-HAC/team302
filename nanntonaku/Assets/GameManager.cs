using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totalCoins;  // ÉQÅ[ÉÄì‡ÇÃÉRÉCÉìÇÃëçêî
    public int currentScore = 0;
    public int collectedCoins = 0;

    public Text scoreText;

    void Start()
    {
        UpdateScoreUI();
    }

    public void CollectCoin()
    {
        collectedCoins++;
        currentScore += 100;
        UpdateScoreUI();
    }

    public void ReachGoal()
    {
        if (collectedCoins == 0)
        {
            currentScore += totalCoins * 500;
        }
        UpdateScoreUI();
        Debug.Log("Game Clear! Final Score: " + currentScore);
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }
}
