using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
  
    public static GameManager instance;
    public TextMeshProUGUI ScoreText;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int points)
    {
        score += points;
        ScoreText.text = "Score: " + score;

    }



    public void ResetScore()
    {
        score = 0;
        ScoreText.text = "Score: " + 0;
    }
}

