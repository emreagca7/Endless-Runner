using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI yourScore;
    public int score;
    public void UptadeScore(int scoreToAdd)
    {
        score += scoreToAdd;     
        PlayerPrefs.SetInt(nameof(score), score);
        scoreText.text = "" + score;
    }
    public void tyrAgain()
    {
        SceneManager.LoadScene("Main");
    }
    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
  
}

