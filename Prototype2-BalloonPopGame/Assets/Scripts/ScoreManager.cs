using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int scoreAmount;
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScoreText(int amount)
    {
        scoreAmount += amount;//increase score by amount
        UpdateScoreText();
    }

    public void DecreaseScoreText(int amount)
    {
        scoreAmount -= amount;//increase score by amount
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreAmount;
    }
}
